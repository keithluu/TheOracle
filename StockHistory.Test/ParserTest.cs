using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockHistory;

namespace StockHistory.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullFilename()
        {
            Parser.ParseFile(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestNotExistFile()
        {
            Parser.ParseFile("filedoesnotexists");
        }

        [TestMethod]
        public void TestEmptyParseFile()
        {
            var stockDailyRecords = Parser.ParseFile(@"TestFiles\ZU_Empty.csv");

            Assert.AreEqual(0, stockDailyRecords.Count);
        }

        [TestMethod]
        public void TestValidParseFile()
        {
            var stockDailyRecords = Parser.ParseFile(@"TestFiles\ZU.csv");

            Assert.AreEqual(6, stockDailyRecords.Count);
        }

        [TestMethod]
        public void TestValidParseFileContainEmptyLines()
        {
            var stockDailyRecords = Parser.ParseFile(@"TestFiles\ZU_WithEmptyLines.csv");

            Assert.AreEqual(6, stockDailyRecords.Count);
        }
    }
}
