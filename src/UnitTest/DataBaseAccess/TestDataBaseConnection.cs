namespace UnitTest.DataBaseAccess
{
    public class TestDataBaseConnection : IClassFixture<TestDatabaseFixture>
    {
        public TestDataBaseConnection(TestDatabaseFixture fixture)
            => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }

        /// <summary>
        /// Testing that there is a connection to the database that
        /// the system is using in development. Not the database used for testing
        /// </summary>
        [Fact]
        public void DatabaseConnection()
        {

            using var context = Fixture.CreateContext();
            Assert.NotNull(context);
        }
    }
}