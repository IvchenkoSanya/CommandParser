using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CommandParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComandParser
{
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void TestParse()
        {
            var parser = new Program();
            var inValues = new List<string>() {"FirstEl", "SecondElement", "Third"};
            Assert.AreEqual(parser.ValuesToLine(inValues) , "FirstEl - SecondElement\nThird - null\n");
        }
        [TestMethod]
        public void TestParseSecond()
        {
            var parser = new Program();
            var inValues = new List<string>() { "FirstEl", "2", "Third" };
            Assert.AreEqual(parser.ValuesToLine(inValues), "FirstEl - 2\nThird - null\n");
        }
        [TestMethod]
        public void TestParseThird()
        {
            var parser = new Program();
            var inValues = new List<string>() { "1", "2", "3" };
            Assert.AreEqual(parser.ValuesToLine(inValues), "1 - 2\n3 - null\n");
        }
    }
}
