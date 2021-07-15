using System;

namespace JasonPereira84.AppSettings
{
    public abstract class _Datetime
    {
        public Int32 Year { get; set; } = default(Int32);

        public Int32 Month { get; set; } = default(Int32);

        public Int32 Day { get; set; } = default(Int32);

        public Int32 Hour { get; set; } = default(Int32);

        public Int32 Minute { get; set; } = default(Int32);

        public Int32 Second { get; set; } = default(Int32);

        public Int32 Millisecond { get; set; } = default(Int32);
    }

    public class Datetime : _Datetime
    {
        public DateTimeKind DateTimeKind { get; set; } = default(DateTimeKind);
    }

    public class DatetimeOffset : _Datetime
    {
        public Timespan Offset { get; set; } = new Timespan ();
    }
}
