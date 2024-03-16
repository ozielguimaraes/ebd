using System;
using System.Globalization;
using System.Linq;

namespace Ebd.CrossCutting.Common.Extensions
{
    public static class StringExtension
    {
        public static string NumbersOnly(this string input)
        {
            var digits = input.Where(c => char.IsDigit(c)).ToArray();

            return digits.Length > 0 ? new string(digits) : string.Empty;
        }

        public static string DigitsOnly(this string input) => input.NumbersOnly();

        public static string GetFirstName(this string input) => input.Substring(0, input.IndexOf(' ')).ToLower().FirstCharacterToUpper();

        public static string FirstCharacterToUpper(this string input)
            => input.Length <= 1 ? input : input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();

        public static string ToTitleCase(this string input) => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());

        public static DateTime ToDateTime(this string input)
        {
            DateTime.TryParse(input, out var date);

            return date;
        }
    }
}
