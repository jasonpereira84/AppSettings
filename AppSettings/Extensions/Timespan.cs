using System;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static TimeSpan AsTimeSpan(this Timespan timespan)
            => new TimeSpan(timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

    }
}