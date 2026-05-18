namespace TimeCopy.Core;

public static class TimeFormatter
{
    public static string ToUnixTimeSecondsString(DateTimeOffset value)
        => value.ToUnixTimeSeconds().ToString();

    public static string ToYmdSlash(DateTimeOffset value)
        => value.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");

    public static string ToYmdCompact(DateTimeOffset value)
        => value.LocalDateTime.ToString("yyyyMMddHHmmss");

    public static string ToIso8601WithOffset(DateTimeOffset value)
        => value.ToString("yyyy-MM-ddTHH:mm:ss") + value.ToString("zzz").Replace(":", "");

    public static string FromUnixTimeSecondsToLocalString(long unixTimeSeconds)
        => DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");

    public static string FromUnixTimeMillisecondsToLocalString(long unixTimeMilliseconds)
        => DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");

    public static bool TryParseUnixTimeString(string text, out long unixTimeSeconds, out string localDateString)
    {
        unixTimeSeconds = 0;
        localDateString = string.Empty;

        var trimmed = text?.Trim() ?? string.Empty;
        if (!long.TryParse(trimmed, out var parsed))
        {
            return false;
        }

        unixTimeSeconds = parsed;
        localDateString = trimmed.Length == 13
            ? FromUnixTimeMillisecondsToLocalString(parsed)
            : FromUnixTimeSecondsToLocalString(parsed);
        return true;
    }

    public static bool TryParseIso8601ToUnixSeconds(string text, out long unixTimeSeconds, out string localDateString)
    {
        unixTimeSeconds = 0;
        localDateString = string.Empty;

        if (!DateTimeOffset.TryParse(text, out var dto))
        {
            return false;
        }

        unixTimeSeconds = dto.ToUnixTimeSeconds();
        localDateString = FromUnixTimeSecondsToLocalString(unixTimeSeconds);
        return true;
    }
}
