using System;
using Xunit;
using System.IO;

namespace BDSA_00.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            Program.Main(new string[0]);
            var result = writer.GetStringBuilder().ToString().Trim();

            Assert.Equal("Hello World!", result);
        }
    }

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
    }
}
