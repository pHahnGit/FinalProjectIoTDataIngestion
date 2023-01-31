using FinalProjectLibrary.Models;
using FinalProjectLibrary.Models.DomainSpecifcSources;
using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using FinalProjectLibrary.Models.DomainSpecificTargets;
using System.Text.Json;

namespace UnitTest.DomainMeasurements
{
    public class DomainSourceCreateMeasurementTest
    {

        public static IEnumerable<object[]> GetData(string nameOfCaller)
        {

            // Json For Sensade v2 sensor test
            JsonDocument sensadeSensorV2JsonOK = JsonDocument.Parse("{\r\n    \"dr\": \"SF12 BW125 4/5\",\r\n    \"ts\": 1661602740271,\r\n    \"EUI\": \"70B3D56380000B80\",\r\n    \"_id\": \"630a0bb4d9d2b18de3be2cef\",\r\n    \"ack\": false,\r\n    \"bat\": 0,\r\n    \"cmd\": \"gw\",\r\n    \"gws\": [\r\n        {\r\n            \"ts\": 1661602740271,\r\n            \"ant\": 0,\r\n            \"lat\": 56.18982699999999,\r\n            \"lon\": 10.185263,\r\n            \"snr\": -15,\r\n            \"rssi\": -115,\r\n            \"time\": \"2022-08-27T12:19:00.207199565Z\",\r\n            \"gweui\": \"024B08FFFF0E0CEA\"\r\n        }\r\n    ],\r\n    \"toa\": 1318,\r\n    \"data\": {\r\n                \"time\": \"2022-08-27T12:19:00.207199565Z\",\r\n                \"occupied\": true,\r\n                \"temperature\": 16,\r\n                \"tempUnit\": \"celsius\"\r\n            },\r\n    \"fcnt\": 31711,\r\n    \"freq\": 867300000,\r\n    \"port\": 2,\r\n    \"seqno\": 171825\r\n}");
            JsonDocument sensadeSensorV2JsonMissingData = JsonDocument.Parse("{\r\n    \"dr\": \"SF12 BW125 4/5\",\r\n    \"ts\": 1661602740271,\r\n    \"EUI\": \"70B3D56380000B80\",\r\n    \"_id\": \"630a0bb4d9d2b18de3be2cef\",\r\n    \"ack\": false,\r\n    \"bat\": 0,\r\n    \"cmd\": \"gw\",\r\n    \"gws\": [\r\n        {\r\n            \"ts\": 1661602740271,\r\n            \"ant\": 0,\r\n            \"lat\": 56.18982699999999,\r\n            \"lon\": 10.185263,\r\n            \"snr\": -15,\r\n            \"rssi\": -115,\r\n            \"time\": \"2022-08-27T12:19:00.207199565Z\",\r\n            \"gweui\": \"024B08FFFF0E0CEA\"\r\n        }\r\n    ],\r\n    \"toa\": 1318,\r\n    \"fcnt\": 31711,\r\n    \"freq\": 867300000,\r\n    \"port\": 2,\r\n    \"seqno\": 171825\r\n}");
            JsonDocument sensadeSensorV2JsonWrong = JsonDocument.Parse("{ \"FirstName\":\"Jignesh\",\"LastName\":\"Trivedi\" }");
            // Json For Sensade v1 sensor test
            JsonDocument sensadeSensorV1JsonOK = JsonDocument.Parse("{\r\n    \"dr\": \"SF12 BW125 4/5\",\r\n    \"ts\": 1661602740271,\r\n    \"EUI\": \"70B3D56380000B80\",\r\n    \"_id\": \"630a0bb4d9d2b18de3be2cef\",\r\n    \"ack\": false,\r\n    \"bat\": 0,\r\n    \"cmd\": \"gw\",\r\n   \"time\": \"2022-08-27T12:19:00.207199565Z\",\r\n  \"gws\": [\r\n        {\r\n            \"ts\": 1661602740271,\r\n            \"ant\": 0,\r\n            \"lat\": 56.18982699999999,\r\n            \"lon\": 10.185263,\r\n            \"snr\": -15,\r\n            \"rssi\": -115,\r\n                       \"gweui\": \"024B08FFFF0E0CEA\"\r\n        }\r\n    ],\r\n    \"toa\": 1318,\r\n    \"data\": \"01BBEF4AFD3CFDC700280000\",\r\n    \"fcnt\": 31711,\r\n    \"freq\": 867300000,\r\n    \"port\": 2,\r\n    \"seqno\": 171825\r\n}");
            JsonDocument sensadeSensorV1JsonMissingData = JsonDocument.Parse("{\r\n    \"dr\": \"SF12 BW125 4/5\",\r\n    \"ts\": 1661602740271,\r\n    \"EUI\": \"70B3D56380000B80\",\r\n    \"_id\": \"630a0bb4d9d2b18de3be2cef\",\r\n    \"ack\": false,\r\n    \"bat\": 0,\r\n    \"cmd\": \"gw\",\r\n    \"gws\": [\r\n        {\r\n            \"ts\": 1661602740271,\r\n            \"ant\": 0,\r\n            \"lat\": 56.18982699999999,\r\n            \"lon\": 10.185263,\r\n            \"snr\": -15,\r\n            \"rssi\": -115,\r\n            \"time\": \"2022-08-27T12:19:00.207199565Z\",\r\n            \"gweui\": \"024B08FFFF0E0CEA\"\r\n        }\r\n    ],\r\n    \"toa\": 1318,\r\n    \"fcnt\": 31711,\r\n    \"freq\": 867300000,\r\n    \"port\": 2,\r\n    \"seqno\": 171825\r\n}");
            JsonDocument sensadeSensorV1JsonWrong = JsonDocument.Parse("{ \"FirstName\":\"Jignesh\",\"LastName\":\"Trivedi\" }");

            // Json For SilkeborgEntryExit sensor test
            JsonDocument silkeborgJsonOk = JsonDocument.Parse("{\r\n    \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid\",\r\n    \"type\": \"FeatureCollection\",\r\n    \"features\": [\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2617\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Banegård - vest\",\r\n                \"longitude\": \"9.542103786283377\",\r\n                \"latitude\": \"56.16421440019126\",\r\n                \"parkingcapacity\": 62,\r\n                \"parkingfree\": 8\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2616\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Bindslevs Plads, p-kælder + nord + kantsten\",\r\n                \"longitude\": \"9.54802474290604\",\r\n                \"latitude\": \"56.16620493532808\",\r\n                \"parkingcapacity\": 216,\r\n                \"parkingfree\": 77\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2615\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Bios Gård\",\r\n                \"longitude\": \"9.5460672535546\",\r\n                \"latitude\": \"56.16758780307408\",\r\n                \"parkingcapacity\": 114,\r\n                \"parkingfree\": 7\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2614\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Estrups Gård\",\r\n                \"longitude\": \"9.543318507661457\",\r\n                \"latitude\": \"56.16532997872286\",\r\n                \"parkingcapacity\": 151,\r\n                \"parkingfree\": 173\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2613\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Jyske Banks parkering\",\r\n                \"longitude\": \"9.544880005769299\",\r\n                \"latitude\": \"56.16906103336498\",\r\n                \"parkingcapacity\": 700,\r\n                \"parkingfree\": 630\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2612\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Kornmods Gård\",\r\n                \"longitude\": \"9.542492713961307\",\r\n                \"latitude\": \"56.16692168906478\",\r\n                \"parkingcapacity\": 107,\r\n                \"parkingfree\": 20\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2611\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Mejerigården\",\r\n                \"longitude\": \"9.548572156271362\",\r\n                \"latitude\": \"56.168095306548814\",\r\n                \"parkingcapacity\": 32,\r\n                \"parkingfree\": 5\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-2610\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Rådhus - øst\",\r\n                \"longitude\": \"9.55186130195464\",\r\n                \"latitude\": \"56.17158992205811\",\r\n                \"parkingcapacity\": 83,\r\n                \"parkingfree\": 0\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-260f\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Rådhus - vest\",\r\n                \"longitude\": \"9.548263426697968\",\r\n                \"latitude\": \"56.170536028489416\",\r\n                \"parkingcapacity\": 229,\r\n                \"parkingfree\": 12\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-260e\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Søgade\",\r\n                \"longitude\": \"9.545859445476617\",\r\n                \"latitude\": \"56.16982217157348\",\r\n                \"parkingcapacity\": 107,\r\n                \"parkingfree\": 84\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-260d\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Torvet, p-kælder\",\r\n                \"longitude\": \"9.549705394544905\",\r\n                \"latitude\": \"56.16945073716191\",\r\n                \"parkingcapacity\": 226,\r\n                \"parkingfree\": 124\r\n            }\r\n        },\r\n        {\r\n            \"type\": \"Feature\",\r\n            \"id\": \"SWARCO_Parkeringspladser_frie_geom.fid-1fe8528b_185847225a3_-260c\",\r\n            \"geometry\": null,\r\n            \"properties\": {\r\n                \"name\": \"Torvecenteret\",\r\n                \"longitude\": \"9.55172748521035\",\r\n                \"latitude\": \"56.16920009115607\",\r\n                \"parkingcapacity\": 400,\r\n                \"parkingfree\": 256\r\n            }\r\n        }\r\n    ],\r\n    \"totalFeatures\": 12,\r\n    \"numberMatched\": 12,\r\n    \"numberReturned\": 12,\r\n    \"timeStamp\": \"2023-01-06T10:04:18.394Z\",\r\n    \"crs\": null\r\n}");

            // Json For C02 sensor test
            JsonDocument c02JsonOk = JsonDocument.Parse("{\r\n    \"probe_id\": \"c02sensor\",\r\n    \"probe_type\": 26, \r\n \"status\": [1],\r\n \"value\": 568 }");

            // TODO: Json For Sensade v1 sensor test



            //adding test objects to list
            var allData = new List<object[]>();
            switch (nameOfCaller)
            {

                case "SensorV2":
                    allData.Add(new object[] { sensadeSensorV2JsonOK, true, "16", "1.3.1", false });
                    allData.Add(new object[] { sensadeSensorV2JsonMissingData, null, null, "1.3.1", true });
                    allData.Add(new object[] { sensadeSensorV2JsonWrong, null, null, "1.3.1", true });
                    //Testing it will not create a measurement with a software version that isn't recognized
                    allData.Add(new object[] { sensadeSensorV2JsonOK, null, null, "2", true });
                    break;

                case "SensorV1":
                    allData.Add(new object[] { sensadeSensorV1JsonOK, 2.25m, false });
                    allData.Add(new object[] { sensadeSensorV1JsonMissingData, null, true });
                    allData.Add(new object[] { sensadeSensorV1JsonWrong, null, true });
                    break;

                case "Silkeborg":
                    allData.Add(new object[] { silkeborgJsonOk,
                        new List<int>() { 8, 77, 7, 173, 630, 20, 5, 0, 12, 84, 124, 256 }
                    , false});
                    break;

                case "C02":
                    allData.Add(new object[] { c02JsonOk, 568, false });
                    break;

                case "SensorV1Heartbeat":
                    //TODO
                    break;

                default:
                    break;
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "Silkeborg")]
        public void SilkeborgCreateMeasurementTest(JsonDocument json, List<int> expectedResults, bool? shouldFail)
        {
            CoilEntryExit source = new CoilEntryExit()
            {
                UniqueId = "SWARCO_Parkeringspladser_frie_geom.fid",
                Targets = new List<Target>()
                {
                    new ParkingLot() { UniqueId = new Guid("060af6e4-0aa5-46ff-a567-a111d7a1f0fc"), Name = "Banegård - vest" },
                    new ParkingLot() { UniqueId = new Guid("bbbe8963-4b35-4296-b65c-b59dc56d9ce4"), Name = "Bindslevs Plads, p-kælder + nord + kantsten" },
                    new ParkingLot() { UniqueId = new Guid("d6a9d08d-89de-494c-9407-bfb41c127326"), Name = "Bios Gård" },
                    new ParkingLot() { UniqueId = new Guid("5b6ad768-f117-4479-961f-e3b1ac78a551"), Name = "Estrups Gård" },
                    new ParkingLot() { UniqueId = new Guid("9786c861-8af0-430f-9fc1-a0ae5414680b"), Name = "Jyske Banks parkering" },
                    new ParkingLot() { UniqueId = new Guid("b195d8f5-10ee-4929-ae20-2c321572095c"), Name = "Kornmods Gård" },
                    new ParkingLot() { UniqueId = new Guid("8fc01bc7-0167-432e-9249-a84165eeaa59"), Name = "Mejerigården" },
                    new ParkingLot() { UniqueId = new Guid("eaec4d67-1df5-49a7-8b05-0762b074317a"), Name = "Rådhus - øst" },
                    new ParkingLot() { UniqueId = new Guid("644a17ab-3272-4f64-baeb-e0c4d6cb148c"), Name = "Rådhus - vest" },
                    new ParkingLot() { UniqueId = new Guid("69da3b5b-8112-49d6-a8e9-c8d5ebf7b61a"), Name = "Søgade" },
                    new ParkingLot() { UniqueId = new Guid("e19b29bd-5902-48b8-b62a-94f248e85dac"), Name = "Torvet, p-kælder" },
                    new ParkingLot() { UniqueId = new Guid("78bd5e26-d9e2-46b0-9cb0-3ec9d8c7875b"), Name = "Torvecenteret", Latitude = 12.33m, Longitude = 33.2m }
                }
            };

            //Used to move through the expected result list
            int counter = 0;

            SourceEntry sourceEntry = (SourceEntry)source.CreateMeasurement(json, DateTime.UtcNow);

            foreach (CapacityMeasurement measurement in sourceEntry.Measurements)
            {
                Assert.Equal(expectedResults[counter], measurement.Available);
                counter++;
            }

        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "C02")]
        public void C02CreateMeasurementTest(JsonDocument json, int value, bool? shouldFail)
        {
            C02Sensor source = new C02Sensor()
            {
                UniqueId = "c02sensor",
                Targets = new List<Target>()
                {
                    new ParkingLot() { UniqueId = new Guid("e19b29bd-5902-48b8-b62a-94f248e85dac"), Name = "Torvet, p-kælder" },
                }
            };

            var sourceEntry = source.CreateMeasurement(json, DateTime.UtcNow);

            if (sourceEntry != null)
            {

                foreach (var measurement in sourceEntry.Measurements)
                {
                    if (measurement is C02Measurement c02Test)
                    {
                        Assert.Equal(value, c02Test.Value);

                    }
                }

            }

            else
            {
                Assert.True(shouldFail);
            }
        }





    }
}
