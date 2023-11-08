using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ebd.Application.Converters
{
    public class DateTimeToDateOnlyConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();
            if (DateTimeOffset.TryParse(dateString, out DateTimeOffset dateTimeOffset))
            {
                return DateOnly.FromDateTime(dateTimeOffset.DateTime);
            }

            throw new JsonException("Invalid date format");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}