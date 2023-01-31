using FinalProjectLibrary.Helpers;
using FinalProjectLibrary.Models;
using FinalProjectLibrary.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RawDataManager.Handlers
{
    public class RawDataHandler : IRawDataHandler
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IColdUnitOfWork coldUnitOfWork;

        public RawDataHandler(IUnitOfWork unitOfWork, IColdUnitOfWork coldUnitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.coldUnitOfWork = coldUnitOfWork;
        }

        /// <summary>
        /// Reads a Json document, validate the source and saves the data
        /// </summary>
        /// <param name="json">The Raw Data recieved from the source</param>
        /// <returns></returns>
        public async Task<IActionResult> NewMeasurement(JsonDocument json)
        {
            //Finds the Sensor Id in the raw data
            var sensorId = SourceHelper.FindSourceID(json);
            if (sensorId == null)
            {
                return new BadRequestObjectResult("No matching ID has been found in the raw data");
            }

            //Validate the sensor
            var source = await unitOfWork.Source.GetByIdIncludeTargets(sensorId);

            if (source == null)
            {
                return new BadRequestObjectResult("No matching ID has been found on the database.");
            }

            // EntryTime for correlation between warm and cold storage
            DateTime entryTime = DateTime.UtcNow;

            var resultCold = await SaveToCold(json, source, entryTime);

            var resultWarm = await SaveToWarm(json, source, entryTime);

            return new OkObjectResult(resultCold + Environment.NewLine + Environment.NewLine + resultWarm);
        }

        /// <summary>
        /// Saves data to the cold data store
        /// </summary>
        /// <param name="json"> The raw data</param>
        /// <param name="source">The source from which the data originates</param>
        /// <returns>A message of success or not</returns>
        private async Task<String> SaveToCold(JsonDocument json, Source source, DateTime entryTime)
        {
            try
            {
                await coldUnitOfWork.ColdMeasurement.InsertRaw(json.RootElement.ToString(), source, entryTime);
                await coldUnitOfWork.Save();
                return ("Data saved to cold storage succesfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Unsuccesful save to cold storage - Exception message: " +
                        Environment.NewLine + ex.ToString());
            }
        }

        /// <summary>
        /// Creates measurements for warm storage based on the type of source
        /// and saves it to warm storage.
        /// </summary>
        /// <param name="json"> The raw data</param>
        /// <param name="source">The source from which the data originates</param>
        /// <returns>A message of success or not</returns>
        private async Task<String> SaveToWarm(JsonDocument json, Source source, DateTime entryTime)
        {
            try
            {
                // Create Measurements based on the logic found in the source object
                var sourceEntry = source.CreateMeasurement(json, entryTime);

                if (sourceEntry == null)
                {
                    return ("Unsuccesful save to warm storage -" +
                            "The source is not configured to save to warm storage " +
                            "or the raw data is in the wrong format");
                }

                foreach (var measurement in sourceEntry.Measurements)
                {
                    measurement.Target.UpdateValues(measurement);
                }

                await unitOfWork.SourceEntry.Add(sourceEntry);

                //Commiting all the changes to WarmStorage if none of the actions failed
                await unitOfWork.Save();
                return ("Data saved to warm storage succesfully");
            }
            catch (Exception ex)
            {
                //Exception message is added for dev purposes only - to remove in production
                return ("Unsuccesful save to warm storage - Exception message: " +
                        Environment.NewLine + ex.ToString());
            }
        }
    }
}
