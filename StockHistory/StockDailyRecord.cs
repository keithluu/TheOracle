using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockHistory
{
    [Serializable]
    public class StockDailyRecordNullException : Exception 
    {
        public StockDailyRecordNullException(string message) : base(message) { }
    }

    [Serializable]
    public class StockDailyRecordEmptyException : Exception 
    {
        public StockDailyRecordEmptyException(string message) : base(message) { }
    }

    [Serializable]
    public class StockDailyRecordFormatException : FormatException 
    {
        public StockDailyRecordFormatException(string message) : base(message) { }
    }

    public class StockDailyRecord
    {
        public DateTime Date {get;set;}
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double AdjustedClose { get; set; }
        public long Volume { get; set; }

        private const int expectedFields = 7;
        
        public static StockDailyRecord ParseLine(string dailyStockRecordLine)
        {
            if (dailyStockRecordLine == null)
            {
                throw new StockDailyRecordNullException("dailyStockRecordLine can not be null");
            }

            if (dailyStockRecordLine.Trim() == string.Empty)
            {
                throw new StockDailyRecordEmptyException("dailyStockRecordLine can not be empty");
            }

            var fields = dailyStockRecordLine.Split(',');
            if (fields.Length != expectedFields)
            {
                throw new StockDailyRecordFormatException(string.Format("Expected {0} fields but has only {1} fields [{2}]", expectedFields, fields.Length, dailyStockRecordLine));
            }

            return new StockDailyRecord()
            {
                Date = DateTime.Parse(fields[0]),
                Open = double.Parse(fields[1]),
                High = double.Parse(fields[2]),
                Low = double.Parse(fields[3]),
                Close = double.Parse(fields[4]),
                Volume = long.Parse(fields[5]),
                AdjustedClose = double.Parse(fields[6]),
            };
        }
    }
}
