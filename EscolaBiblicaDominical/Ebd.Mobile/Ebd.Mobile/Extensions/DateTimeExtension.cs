using System;
using System.Collections.Generic;
using System.Text;

namespace Ebd.Mobile.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ObterDataAtual()
        {
            var aas = new DateTimeWithZone();
            return aas.LocalTime;
        }

        public static int ObterTrimestreAtual()
            => ObterDataAtual().ObterTrimestre();

        public static int ObterTrimestre(this DateTime date)
        {
            if (date.Month >= 1 && date.Month <= 3) return 1;
            else if (date.Month >= 4 && date.Month <= 6) return 2;
            else if (date.Month >= 7 && date.Month <= 9) return 3;
            else return 4;
        }
    }
    public struct DateTimeWithZone
    {
        private readonly DateTime utcDateTime;
        private readonly TimeZoneInfo timeZone;

        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
            this.timeZone = timeZone;
        }

        public DateTime UniversalTime => utcDateTime;
        public TimeZoneInfo TimeZone => timeZone;
        public DateTime LocalTime => TimeZoneInfo.ConvertTime(utcDateTime, timeZone);
    }
}
