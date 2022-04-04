using Implementation2.Db;
using System.Linq;
using Xunit;

namespace Implementation2.Tests
{
    public class SQLInjectionTestNoCollection : IClassFixture<DatabaseFixture>
    {
        I2Context Context { get; }
        readonly string first, last;

        public SQLInjectionTestNoCollection(DatabaseFixture fixture)
        {
            Context = fixture.Context;
            first = ";THROW 52000, 'This shouldn't actually throw an exception', 1;GO";
            last = ";THROW 53000, 'This shouldn't actually throw an exception', 1;GO";
        }

        [Theory]
        [InlineData(1, 20)]
        public void TestInsertion(int start, int end)
        {
            var reference = new string[] { "1", "2", first, "4", last, first, "7", "8", first, last, "11", first, "13", "14", $"{first} {last}", "16", "17", first, "19", last };
            var result = Context.InsertAndReturnResults(start, end, first, last).AsEnumerable().OrderBy(f => f.Id);
            var selected = result.Select(f => f.Value).ToArray();

            Assert.Equal(reference, selected);
        }
    }
}
