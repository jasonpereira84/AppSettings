using System;
using System.Linq;
using System.Text;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static DateTime AsDateTime(this Datetime datetime)
            => new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond, datetime.DateTimeKind);

        public static DateTime AsDateTime<TDatetime>(this TDatetime datetime)
            where TDatetime : _Datetime
            => new DateTime(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond, default(DateTimeKind));

        public static DateTimeOffset AsDateTimeOffset(this DatetimeOffset datetimeOffset)
            => new DateTimeOffset(datetimeOffset.Year, datetimeOffset.Month, datetimeOffset.Day, datetimeOffset.Hour, datetimeOffset.Minute, datetimeOffset.Second, datetimeOffset.Millisecond, datetimeOffset.Offset.AsTimeSpan());

        public static DateTimeOffset AsDateTimeOffset<TDatetime>(this TDatetime datetime)
            where TDatetime : _Datetime
            => new DateTimeOffset(datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond, default(TimeSpan));

    }
}