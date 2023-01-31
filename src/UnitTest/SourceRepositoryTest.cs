using FinalProjectLibrary.Repository.TypeRepository;
using System.Text.Json;

namespace UnitTest
{
    public class SourceRepositoryTest : IClassFixture<TestDatabaseFixture>
    {
        public SourceRepositoryTest(TestDatabaseFixture fixture)
            => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }

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

                case "GetSource":
                    allData.Add(new object[] { "1234", "1234" });
                    allData.Add(new object[] { "4321", "FALSE" });
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
        [MemberData(nameof(GetData), parameters: "GetSource")]
        public async void GetSource(string input, string expectedId)
        {
            using var context = Fixture.CreateContext();
            var repository = new SourceRepository(context);

            var foundResult = await repository.GetByIdIncludeTargets(input);

            String foundId = foundResult != null ? foundResult.UniqueId : "FALSE";

            Assert.Equal(expectedId, foundId);
        }
    }


}
