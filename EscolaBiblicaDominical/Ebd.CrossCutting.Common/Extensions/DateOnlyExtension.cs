using System;

namespace Ebd.CrossCutting.Common.Extensions
{
    public static class DateOnlyExtension
    {
        public static bool EhMaiorOuIgual18Anos(this DateOnly dataNascimento)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);
            int age = currentDate.Year - dataNascimento.Year;

            if (currentDate.Month < dataNascimento.Month || (currentDate.Month == dataNascimento.Month && currentDate.Day < dataNascimento.Day))
            {
                age--;
            }

            return age >= 18;
        }
    }
}
