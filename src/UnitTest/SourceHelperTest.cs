using FinalProjectLibrary.Helpers;
using System.Text.Json;

namespace UnitTest
{
    public class SourceHelperTest
    {

        public static IEnumerable<object[]> GetData(string nameOfCaller)
        {
            //Create Item test objects
            //TODO add more test cases
            JsonDocument json1 = JsonDocument.Parse("{ \"EUI\":\"1234\",\"LastName\":\"Trivedi\" }");
            JsonDocument json2 = JsonDocument.Parse("{ \"FirstName\":\"Jignesh\",\"LastName\":\"Trivedi\" }");

            //adding test objects to list
            var allData = new List<object[]>();
            switch (nameOfCaller)
            {

                case "FindId":
                    allData.Add(new object[] { json1, "1234" });
                    allData.Add(new object[] { json2, null });
                    break;
                //Add more testcase data here
                case "CreateOccupancyMeasurement":
                    //allData.Add(new object[] { item2, true });
                    //allData.Add(new object[] { item3, false });
                    break;
                default:
                    break;
            }
            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: "FindId")]

        public void FindIdInJson(JsonDocument input, string id)
        {
            var foundId = SourceHelper.FindSourceID(input);

            Assert.Equal(id, foundId);
        }
    }
}
