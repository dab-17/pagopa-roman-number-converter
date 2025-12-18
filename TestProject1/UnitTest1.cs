using ConsoleApp1;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("XIV", 14)]
        [InlineData("LX", 60)]
        [InlineData("CDXLIV", 444)]
        [InlineData("MMXXIV", 2024)]
        [InlineData("MMMCMXCIX", 3999)]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        public void Test1(string input, int expected)
        {
            // Act
            var result = RomanNumberConverter.ToDecimal(input);
            // Assert
            Assert.Equal(expected, result);

        }
    }
}
