using System;

namespace Ebd.CrossCutting.Common
{
    public readonly struct DateTimeWithZone
    {
        private static readonly TimeZoneInfo _defaultTimeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;

        public DateTimeWithZone(DateTime dateTime)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, _defaultTimeZone);
            timeZone = _defaultTimeZone;
        }

        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
            this.timeZone = timeZone;
        }

        public readonly DateTime UniversalTime => utcDateTime;
        public readonly TimeZoneInfo TimeZone => timeZone ?? _defaultTimeZone;
        public readonly DateTime LocalTime => TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
    }
}
