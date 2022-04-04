using Implementation2.Db;
using System.Linq;
using Xunit;

namespace Implementation2.Tests
{
    [Collection("Database")]
    public class InsertProcedureTest
    {
        I2Context Context { get; }

        public InsertProcedureTest(DatabaseFixture fixture)
        {
            Context = fixture.Context;
        }

        [Fact]
        public void TestEmptyTable()
        {
            Assert.Equal(0, Context.Results.Count());
        }

        [Theory]
        [InlineData(1, 20, "first", "last")]
        public void TestInsertion(int start, int end, string first, string last)
        {
            var reference = new string[] { "1", "2", first, "4", last, first, "7", "8", first, last, "11", first, "13", "14", $"{first} {last}", "16", "17", first, "19", last };
            var result = Context.InsertAndReturnResults(start, end, first, last).AsEnumerable().OrderBy(f => f.Id);
            var selected = result.Select(f => f.Value).ToArray();

            Assert.Equal(reference, selected);
        }
    }
}
