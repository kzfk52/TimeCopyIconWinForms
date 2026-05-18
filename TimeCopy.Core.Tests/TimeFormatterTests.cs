using TimeCopy.Core;

namespace TimeCopy.Core.Tests;

public class TimeFormatterTests
{
    private static readonly DateTimeOffset Sample =
        new(2021, 2, 16, 9, 30, 33, TimeSpan.FromHours(9));

    [Fact]
    public void ToUnixTimeSecondsString_ReturnsExpected()
    {
        Assert.Equal("1613435433", TimeFormatter.ToUnixTimeSecondsString(Sample));
    }

    [Fact]
    public void ToYmdSlash_ReturnsLocalFormatted()
    {
        var expected = Sample.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
        Assert.Equal(expected, TimeFormatter.ToYmdSlash(Sample));
    }

    [Fact]
    public void ToYmdCompact_ReturnsCompactLocal()
    {
        var expected = Sample.LocalDateTime.ToString("yyyyMMddHHmmss");
        Assert.Equal(expected, TimeFormatter.ToYmdCompact(Sample));
    }

    [Fact]
    public void ToIso8601WithOffset_StripsColonFromOffset()
    {
        var result = TimeFormatter.ToIso8601WithOffset(Sample);
        Assert.Equal("2021-02-16T09:30:33+0900", result);
    }

    [Fact]
    public void FromUnixTimeSecondsToLocalString_RoundTrips()
    {
        var unix = Sample.ToUnixTimeSeconds();
        var expected = DateTimeOffset.FromUnixTimeSeconds(unix).LocalDateTime
            .ToString("yyyy/MM/dd HH:mm:ss");
        Assert.Equal(expected, TimeFormatter.FromUnixTimeSecondsToLocalString(unix));
    }

    [Fact]
    public void FromUnixTimeMillisecondsToLocalString_RoundTrips()
    {
        var unixMs = Sample.ToUnixTimeMilliseconds();
        var expected = DateTimeOffset.FromUnixTimeMilliseconds(unixMs).LocalDateTime
            .ToString("yyyy/MM/dd HH:mm:ss");
        Assert.Equal(expected, TimeFormatter.FromUnixTimeMillisecondsToLocalString(unixMs));
    }

    [Fact]
    public void TryParseUnixTimeString_TenDigits_TreatedAsSeconds()
    {
        var ok = TimeFormatter.TryParseUnixTimeString("1613435433", out var unix, out var local);
        Assert.True(ok);
        Assert.Equal(1613435433L, unix);
        Assert.Equal(
            DateTimeOffset.FromUnixTimeSeconds(1613435433).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
            local);
    }

    [Fact]
    public void TryParseUnixTimeString_ThirteenDigits_TreatedAsMilliseconds()
    {
        var ok = TimeFormatter.TryParseUnixTimeString("1613440233000", out var unix, out var local);
        Assert.True(ok);
        Assert.Equal(1613440233000L, unix);
        Assert.Equal(
            DateTimeOffset.FromUnixTimeMilliseconds(1613440233000).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
            local);
    }

    [Fact]
    public void TryParseUnixTimeString_InvalidText_ReturnsFalse()
    {
        var ok = TimeFormatter.TryParseUnixTimeString("not-a-number", out var unix, out var local);
        Assert.False(ok);
        Assert.Equal(0, unix);
        Assert.Equal(string.Empty, local);
    }

    [Fact]
    public void TryParseIso8601ToUnixSeconds_Valid_ReturnsTrue()
    {
        var ok = TimeFormatter.TryParseIso8601ToUnixSeconds("2021-02-16T09:30:33+0900", out var unix, out var local);
        Assert.True(ok);
        Assert.Equal(1613435433L, unix);
        Assert.NotEqual(string.Empty, local);
    }

    [Fact]
    public void TryParseIso8601ToUnixSeconds_Invalid_ReturnsFalse()
    {
        var ok = TimeFormatter.TryParseIso8601ToUnixSeconds("garbage", out var unix, out var local);
        Assert.False(ok);
        Assert.Equal(0, unix);
        Assert.Equal(string.Empty, local);
    }
}
