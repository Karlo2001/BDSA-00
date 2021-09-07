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
}
