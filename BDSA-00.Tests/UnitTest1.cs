using System;
using Xunit;
using System.IO;

namespace BDSA_00.Tests
{
    public class Leap_Year_Tests
    {
        [Theory]
        [InlineData(4, true)]
        [InlineData(100, false)]
        [InlineData(200, false)]
        [InlineData(204, true)]
        [InlineData(400, true)]
        [InlineData(1800, false)]
        [InlineData(1600, true)]
        public void Check_Leap_Year(int year, bool expected)
        {
            Assert.Equal(expected, Program.IsLeapYear(year));
        }
        [Theory]
        [InlineData("4", "yay")]
        [InlineData("100", "nay")]
        [InlineData("200", "nay")]
        [InlineData("204", "yay")]
        [InlineData("400", "yay")]
        [InlineData("1800", "nay")]
        [InlineData("1600", "yay")]
        public void Check_Leap_Year_With_User_Input(string input, string expected)
        {
            Console.SetIn(new StringReader(input));
            var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main(new string[0]);
            var result = writer.GetStringBuilder().ToString().Trim();

            Assert.Equal(expected, result.Substring(result.Length - 3));
        }
    }
}
