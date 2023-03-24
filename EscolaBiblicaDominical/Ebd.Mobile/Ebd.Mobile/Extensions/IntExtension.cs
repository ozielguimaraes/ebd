﻿namespace Ebd.Mobile.Extensions
{
    public static class IntExtension
    {
        public static int OrZero(this int? value) => value is null ? 0 : value.Value;
    }
}