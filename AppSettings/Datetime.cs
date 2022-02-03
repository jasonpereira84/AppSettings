using System;

namespace JasonPereira84.AppSettings
{
    public abstract class _Datetime
    {
        public Int32 Year { get; set; }

        public Int32 Month { get; set; }

        public Int32 Day { get; set; }

        public Int32 Hour { get; set; }

        public Int32 Minute { get; set; }

        public Int32 Second { get; set; }

        public Int32 Millisecond { get; set; }
    }

    public class Datetime : _Datetime
    {
        public String Kind { get; set; }
    }

    public class DatetimeOffset : _Datetime
    {
        public Timespan Offset { get; set; }
    }
}
