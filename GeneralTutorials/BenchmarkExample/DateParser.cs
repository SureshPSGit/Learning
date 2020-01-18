using System;

namespace BenchmarkExample
{
    //2019-12-13T16:33:06Z
    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var dateTime = DateTime.Parse(dateTimeAsString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHyphen = dateTimeAsString.Split('-');
            return int.Parse(splitOnHyphen[0]);
        }

        public int GetYearFromSubstring(string dateTimeAsString)
        {
            var indexOfHyphen = dateTimeAsString.IndexOf('-');
            return int.Parse(dateTimeAsString.Substring(0, indexOfHyphen));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
            return int.Parse(dateTimeAsSpan.Slice(0, indexOfHyphen));
        }
        
        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
            var yearAsASpan = dateTimeAsSpan.Slice(0, indexOfHyphen);

            var temp = 0;
            for (int i = 0; i < yearAsASpan.Length; i++)
            {
                temp = temp * 10 + (yearAsASpan[i] - '0');
            }

            return temp;
        }
    }
}