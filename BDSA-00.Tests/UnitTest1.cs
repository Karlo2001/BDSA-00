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
        [InlineData("2000", "yay")]
        [InlineData("1584", "yay")]
        [InlineData("2000", "yay")]
        [InlineData("1582", "nay")]
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

        [Theory]
        [InlineData("4", Program.ERROR_INPUT_YEAR_BELOW_1582)]
        [InlineData("100", Program.ERROR_INPUT_YEAR_BELOW_1582)]
        [InlineData("string", Program.ERROR_INPUT_CANT_CONVERT)]
        [InlineData("", Program.ERROR_INPUT_YEAR_BELOW_1582)]
        [InlineData("0A1B2", Program.ERROR_INPUT_CANT_CONVERT)]
        [InlineData("2147483648", Program.ERROR_INPUT_OVERFLOW)]
        public void Check_Leap_Year_With_Faulty_User_Input(string input, string expected)
        {
            Console.SetIn(new StringReader(input));
            var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main(new string[0]);
            var result = writer.GetStringBuilder().ToString().Trim();
            char[] delims = new[] { '\r', '\n' };
            string[] strings = result.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            if(strings.Length == 1)
            {
                strings = strings[0].Split(':', StringSplitOptions.RemoveEmptyEntries);
            }

            Assert.Equal(expected, strings[strings.Length-1].Trim());
        }
    }
}
