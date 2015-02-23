using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockHistory;

namespace StockHistory.Test
{
    [TestClass]
    public class StockDailyRecordTest
    {
        [TestMethod]
        [ExpectedException(typeof(StockDailyRecordNullException))]
        public void TestNullParseLine()
        {
            StockDailyRecord.ParseLine(null);
        }

        [TestMethod]
        [ExpectedException(typeof(StockDailyRecordEmptyException))]
        public void TestEmptyParseLine()
        {
            StockDailyRecord.ParseLine("");
        }

        [TestMethod]
        [ExpectedException(typeof(StockDailyRecordEmptyException))]
        public void TestWhitespaceParseLine()
        {
            StockDailyRecord.ParseLine("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(StockDailyRecordFormatException))]
        public void TestInvalidNumberOfFielsInParseLine()
        {
            StockDailyRecord.ParseLine("wrong,number,of,fields");
        }

        [TestMethod]
        public void TestValidParseLine()
        {
            var stockRecord = StockDailyRecord.ParseLine("2015-02-20,14.42,14.64,14.29,14.40,2102800,14.40");
            Assert.AreEqual(DateTime.Parse("2015-02-20"), stockRecord.Date);
            Assert.AreEqual(double.Parse("14.42"), stockRecord.Open);
            Assert.AreEqual(double.Parse("14.64"), stockRecord.High);
            Assert.AreEqual(double.Parse("14.29"), stockRecord.Low);
            Assert.AreEqual(double.Parse("14.40"), stockRecord.Close);
            Assert.AreEqual(double.Parse("14.40"), stockRecord.AdjustedClose);
            Assert.AreEqual(long.Parse("2102800"), stockRecord.Volume);
        }
    }
}
