using Implementation2.Db;
using System.Linq;
using Xunit;

namespace Implementation2.Tests
{
    [Collection("Database")]
    public class IterateFunctionTest
    {
        I2Context Context { get; }

        public IterateFunctionTest(DatabaseFixture fixture)
        {
            Context = fixture.Context;
        }

        [Theory]
        [InlineData(1, 20, "first", "last")]
        public void TestIteration(int start, int end, string first, string last)
        {
            var reference = new string[] { "1", "2", first, "4", last, first, "7", "8", first, last, "11", first, "13", "14", $"{first} {last}", "16", "17", first, "19", last };
            var result = Context.Iterate(start, end, first, last);
            var selected = result.Select(f => f.Result).ToArray();

            Assert.Equal(reference, selected);
        }
    }
}
