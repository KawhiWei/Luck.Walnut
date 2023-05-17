using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hoyo.WebCore;
public class SystemTextJsonConvert
{
    private const string DateFormat = "yyyy-MM-dd";
    private const string TimeFormat = "HH:mm:ss";
    private const string DateTimeFormat = $"{DateFormat} {TimeFormat}";

    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType == JsonTokenType.Number ? reader.GetDecimal() : decimal.Parse(reader.GetString()!);
        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public class DecimalNullConverter : JsonConverter<decimal?>
    {
        public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Number
                ? reader.GetDecimal()
                : string.IsNullOrEmpty(reader.GetString())
                ? default(decimal?)
                : decimal.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options) => writer.WriteStringValue(value?.ToString());
    }

    public class IntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Number
                ? reader.GetInt32()
                : string.IsNullOrEmpty(reader.GetString()) ? default : int.Parse(reader.GetString()!);
        }
        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) => writer.WriteNumberValue(value);
    }

    public class IntNullConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Number
                ? reader.GetInt32()
                : string.IsNullOrEmpty(reader.GetString()) ? default(int?) : int.Parse(reader.GetString()!);
        }
        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            if (value is not null) writer.WriteNumberValue(value.Value);
            else writer.WriteNullValue();
        }
    }

    public class BoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType is JsonTokenType.True or JsonTokenType.False
                ? reader.GetBoolean()
                : reader.TokenType == JsonTokenType.String
                ? bool.Parse(reader.GetString()!)
                : reader.TokenType == JsonTokenType.Number
                ? reader.GetDouble() > 0
                : throw new NotImplementedException($"un processed tokentype {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) => writer.WriteBooleanValue(value);
    }

    public class BoolNullConverter : JsonConverter<bool?>
    {
        public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType is JsonTokenType.True or JsonTokenType.False
                ? reader.GetBoolean()
                : reader.TokenType == JsonTokenType.Null
                ? null
                : reader.TokenType == JsonTokenType.String
                ? bool.Parse(reader.GetString()!)
                : reader.TokenType == JsonTokenType.Number
                ? reader.GetDouble() > 0
                : throw new NotImplementedException($"un processed tokentype {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
        {
            if (value != null) writer.WriteBooleanValue(value.Value);
            else writer.WriteNullValue();
        }
    }

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Convert.ToDateTime(reader.GetString());

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(DateTimeFormat));
    }
    public class DateTimeNullConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => string.IsNullOrEmpty(reader.GetString()) ? null : Convert.ToDateTime(reader.GetString());

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) => writer.WriteStringValue(value?.ToString(DateTimeFormat));
    }
    public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => TimeSpan.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(TimeFormat));
    }

#if !NETSTANDARD
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => TimeOnly.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(TimeFormat));
    }
    public class TimeOnlyNullJsonConverter : JsonConverter<TimeOnly?>
    {
        public override TimeOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => string.IsNullOrWhiteSpace(reader.GetString()) ? null : TimeOnly.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, TimeOnly? value, JsonSerializerOptions options) => writer.WriteStringValue(value?.ToString(TimeFormat));
    }
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateOnly.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString(DateFormat));
    }
    public class DateOnlyNullJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => string.IsNullOrWhiteSpace(reader.GetString()) ? null : DateOnly.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options) => writer.WriteStringValue(value?.ToString(DateFormat));
    }
#endif
}