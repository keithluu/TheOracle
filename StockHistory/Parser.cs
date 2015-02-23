using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockHistory
{
    public static class Parser
    {
        public static List<StockDailyRecord> ParseFile(string filename, bool skippedEmptyLine = true)
        {
            List<StockDailyRecord> dailyRecords = new List<StockDailyRecord>();
            bool skippedHeader = false;
            foreach (var dailyStockRecordLine in File.ReadAllLines(filename))
            {
                if (!skippedHeader)
                {
                    skippedHeader = true;
                    continue;
                }

                if (dailyStockRecordLine.Trim() == string.Empty && skippedEmptyLine)
                {
                    continue;
                }

                dailyRecords.Add(StockDailyRecord.ParseLine(dailyStockRecordLine));
            }

            return dailyRecords;
        }
    }
}
