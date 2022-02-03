using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JasonPereira84.AppSettings.Tests
{
    namespace Extensions
    {
        [TestClass]
        public class Test_DatetimeOffset
        {
            [TestMethod]
            public void AsDateTime()
            {
                {
                    var datetime = new Datetime
                    {
                        Year = 1,
                        Month = 1,
                        Day = 1,
                        Hour = 1,
                        Minute = 1,
                        Second = 1,
                        Millisecond = 1,
                        Kind = "Utc"
                    };

                    Assert.AreEqual(
                        expected: new DateTime(1, 1, 1, 1, 1, 1, 1, DateTimeKind.Utc),
                        actual: datetime.AsDateTime());
                }

                {
                    {
                        var datetime = new Datetime
                        {
                            Year = 1,
                            Month = 1,
                            Day = 1,
                            Hour = 1,
                            Minute = 1,
                            Second = 1,
                            Millisecond = 1,
                            Kind = default(String)
                        };

                        Assert.AreEqual(
                            expected: DateTimeKind.Unspecified,
                            actual: datetime.AsDateTime().Kind);
                    }

                    {
                        var datetime = new Datetime
                        {
                            Year = 1,
                            Month = 1,
                            Day = 1,
                            Hour = 1,
                            Minute = 1,
                            Second = 1,
                            Millisecond = 1,
                            Kind = ""
                        };

                        Assert.AreEqual(
                            expected: DateTimeKind.Unspecified,
                            actual: datetime.AsDateTime().Kind);
                    }

                    {
                        var datetime = new Datetime
                        {
                            Year = 1,
                            Month = 1,
                            Day = 1,
                            Hour = 1,
                            Minute = 1,
                            Second = 1,
                            Millisecond = 1,
                            Kind = " "
                        };

                        Assert.AreEqual(
                            expected: DateTimeKind.Unspecified,
                            actual: datetime.AsDateTime().Kind);
                    }

                    {
                        var datetime = new Datetime
                        {
                            Year = 1,
                            Month = 1,
                            Day = 1,
                            Hour = 1,
                            Minute = 1,
                            Second = 1,
                            Millisecond = 1,
                            Kind = "utc"
                        };

                        Assert.AreEqual(
                            expected: DateTimeKind.Utc,
                            actual: datetime.AsDateTime().Kind);
                    }

                }
            }

            [TestMethod]
            public void AsDateTimeOffset()
            {
                {
                    var datetimeOffset = new DatetimeOffset
                    {
                        Year = 1,
                        Month = 1,
                        Day = 1,
                        Hour = 1,
                        Minute = 1,
                        Second = 1,
                        Millisecond = 1,
                        Offset = new Timespan
                        {
                            Days = 0,
                            Hours = 1,
                            Minutes = 0,
                            Seconds = 0,
                            Milliseconds = 0,
                        }
                    };

                    Assert.AreEqual(
                        expected: new DateTimeOffset(1, 1, 1, 1, 1, 1, 1, TimeSpan.FromHours(1)),
                        actual: datetimeOffset.AsDateTimeOffset());
                }

                {
                    var datetimeOffset = new DatetimeOffset
                    {
                        Year = 1,
                        Month = 1,
                        Day = 1,
                        Hour = 1,
                        Minute = 1,
                        Second = 1,
                        Millisecond = 1,
                    };

                    Assert.AreEqual(
                        expected: new DateTimeOffset(1, 1, 1, 1, 1, 1, 1, TimeSpan.Zero),
                        actual: datetimeOffset.AsDateTimeOffset());
                }

            }

        }
    }
}
