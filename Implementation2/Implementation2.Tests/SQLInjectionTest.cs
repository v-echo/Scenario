using Implementation2.Db;
using System.Linq;
using Xunit;

namespace Implementation2.Tests
{
    [Collection("Database")]
    public class SQLInjectionTest
    {
        I2Context Context { get; }
        readonly string first, last;

        public SQLInjectionTest(DatabaseFixture fixture)
        {
            Context = fixture.Context;
            first = ";THROW 52000, 'This shouldn't actually throw an exception', 1;GO";
            last = ";THROW 53000, 'This shouldn't actually throw an exception', 1;GO";
        }

        [Theory]
        [InlineData(6)]
        public void TestDivideBy3(int value)
        {
            var result = Context.TestDivide(value, first, last);
            Assert.Equal(first, result);
        }

        [Theory]
        [InlineData(10)]
        public void TestDivideBy5(int value)
        {
            var result = Context.TestDivide(value, first, last);
            Assert.Equal(last, result);
        }

        [Theory]
        [InlineData(15)]
        public void TestDivideBy3And5(int value)
        {
            var result = Context.TestDivide(value, first, last);
            Assert.Equal($"{first} {last}", result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(13)]
        [InlineData(17)]
        public void TestDivideByOther(int value)
        {
            var result = Context.TestDivide(value, first, last);
            Assert.Equal(value.ToString(), result);
        }

        [Theory]
        [InlineData(1, 20)]
        public void TestIteration(int start, int end)
        {
            var reference = new string[] { "1", "2", first, "4", last, first, "7", "8", first, last, "11", first, "13", "14", $"{first} {last}", "16", "17", first, "19", last };
            var result = Context.Iterate(start, end, first, last);
            var selected = result.Select(f => f.Result).ToArray();

            Assert.Equal(reference, selected);
        }
    }
}
