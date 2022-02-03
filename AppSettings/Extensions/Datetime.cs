using System;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static DateTime AsDateTime(this Datetime datetime, DateTimeKind defaultDateTimeKind = default(DateTimeKind))
            => new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond, Enum.TryParse(datetime.Kind, true, out DateTimeKind parsedDateTimeKind) ? parsedDateTimeKind : defaultDateTimeKind);

        public static DateTimeOffset AsDateTimeOffset(this DatetimeOffset datetimeOffset)
            => new DateTimeOffset(datetimeOffset.Year, datetimeOffset.Month, datetimeOffset.Day, datetimeOffset.Hour, datetimeOffset.Minute, datetimeOffset.Second, datetimeOffset.Millisecond, datetimeOffset.Offset?.AsTimeSpan() ?? TimeSpan.Zero);

    }
}