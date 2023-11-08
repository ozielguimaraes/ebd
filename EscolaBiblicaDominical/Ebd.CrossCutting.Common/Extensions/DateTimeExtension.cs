using System;

namespace Ebd.CrossCutting.Common.Extensions
{
    public static class DateTimeExtension
    {
        public static bool EhMaiorOuIgual18Anos(this DateTime dataNascimento)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - dataNascimento.Year;

            if (currentDate.Month < dataNascimento.Month || (currentDate.Month == dataNascimento.Month && currentDate.Day < dataNascimento.Day))
            {
                age--;
            }

            return age >= 18;
        }

        public static string ToDateOnly(this DateTime dateTime)
            => dateTime.ToString("dd/MM/yyyy");

        public static DateTime ObterDataAtual()
            => ObterDataLocal(DateTime.Now);

        public static DateTime ObterDataLocal(this DateTime dateTime)
        {
            var dateTimeWithZone = new DateTimeWithZone(dateTime);
            return dateTimeWithZone.LocalTime;
        }

        public static int ObterTrimestreAtual()
            => ObterDataAtual().ObterTrimestre();

        public static string ObterTrimestreAtualComoString(this DateTime dateTime)
            => dateTime.ObterTrimestre().ToString().PadLeft(2, '0');

        public static int ObterTrimestre(this DateTime date)
        {
            if (date.Month >= 1 && date.Month <= 3) return 1;
            else if (date.Month >= 4 && date.Month <= 6) return 2;
            else if (date.Month >= 7 && date.Month <= 9) return 3;
            else return 4;
        }
    }
}
