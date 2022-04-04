using SharedLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Implementation1.Tests
{
    public class TestDivision
    {
        IDivider Divider { get; }
        readonly string firstName = "TestFirst";
        readonly string lastName = "TestLast";

        public TestDivision()
        {
            var dictionary = new Dictionary<int, string>()
            {
                { 15, $"{firstName} {lastName}" },
                { 3, firstName },
                { 5, lastName }
            };
            Divider = new GeneralDivider(new ReadOnlyDictionary<int, string>(dictionary));
        }

        [Theory]
        [InlineData(6)]
        public void TestDivideBy3(int value)
        {
            var result = Divider.Divide(value);
            Assert.Equal(result, firstName);
        }

        [Theory]
        [InlineData(10)]
        public void TestDivideBy5(int value)
        {
            var result = Divider.Divide(value);
            Assert.Equal(result, lastName);
        }

        [Theory]
        [InlineData(15)]
        public void TestDivideBy3And5(int value)
        {
            var result = Divider.Divide(value);
            Assert.Equal(result, $"{firstName} {lastName}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(11)]
        [InlineData(22)]
        public void TestDivideByOther(int value)
        {
            var result = Divider.Divide(value);
            Assert.Equal(result, value.ToString());
        }
    }
}