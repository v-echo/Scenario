using Implementation2.Db;
using Xunit;

namespace Implementation2.Tests
{
    [Collection("Database")]
    public class DivideFunctionTest
    {
        I2Context Context { get; }
        readonly string first, last;

        public DivideFunctionTest(DatabaseFixture fixture)
        {
            Context = fixture.Context;
            first = "first";
            last = "last";
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
        [InlineData(1)]
        [InlineData(11)]
        [InlineData(22)]
        public void TestDivideByOther(int value)
        {
            var result = Context.TestDivide(value, first, last);
            Assert.Equal(value.ToString(), result);
        }
    }
}
