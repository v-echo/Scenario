using Implementation2.Db;
using System.Linq;
using Xunit;

namespace Implementation2.Tests
{
    [Collection("Database")]
    public class GenerateFunctionTest
    {
        I2Context Context { get; }

        public GenerateFunctionTest(DatabaseFixture fixture)
        {
            Context = fixture.Context;
        }

        [Theory]
        [InlineData(1, 1000)]
        public void TestGeneration(int start, int end)
        {
            var reference = Enumerable.Range(start, end).Select(f => (long)f).ToArray();
            var result = Context.GenerateIntegers(start, end);
            var selected = result.Select(f => f.Value).ToArray();

            Assert.Equal(reference, selected);
        }
    }
}
