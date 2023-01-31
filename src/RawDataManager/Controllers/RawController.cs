using FinalProjectLibrary.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using RawDataManager.Handlers;
using System.Text.Json;

namespace RawDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColdUnitOfWork _coldUnitOfWork;
        private readonly IRawDataHandler _rawDataHandler;

        public RawController(IUnitOfWork unitOfWork, IColdUnitOfWork coldUnitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._coldUnitOfWork = coldUnitOfWork;
            this._rawDataHandler = new RawDataHandler(unitOfWork, coldUnitOfWork);
        }

        /// <summary>
        /// Recieves the HTTP request body
        /// and passes it onto the handler for persistence to warm and cold storage
        /// </summary>
        /// <param name="body">The raw data as json</param>
        /// <returns></returns>
        [HttpPost("newmeasurement")]
        [Consumes("application/json")]
        public async Task<IActionResult> NewMeasurement(JsonDocument body)
        {
            return await _rawDataHandler.NewMeasurement(body);
        }
    }
}
