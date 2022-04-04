using Xunit;

namespace Implementation2.Tests
{
    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
