using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeCopy.Core;
using TimeCopy.Desktop.Services;

namespace TimeCopy.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IClipboardService _clipboard;
    private readonly INotificationService _notifications;
    private readonly Func<DateTimeOffset> _now;

    [ObservableProperty]
    private string _iso8601Example = string.Empty;

    [ObservableProperty]
    private string _unixTimeInput = string.Empty;

    [ObservableProperty]
    private string _unixTimeAsLocalDate = string.Empty;

    [ObservableProperty]
    private string _iso8601Input = string.Empty;

    [ObservableProperty]
    private string _iso8601AsUnixTime = string.Empty;

    [ObservableProperty]
    private string _conversionMessage = string.Empty;

    public Action? RequestExit { get; set; }

    public MainWindowViewModel()
        : this(new NullClipboardService(), new NullNotificationService(), () => DateTimeOffset.Now)
    {
    }

    public MainWindowViewModel(
        IClipboardService clipboard,
        INotificationService notifications,
        Func<DateTimeOffset> nowProvider)
    {
        _clipboard = clipboard;
        _notifications = notifications;
        _now = nowProvider;
        Iso8601Example = TimeFormatter.ToIso8601WithOffset(_now());
    }

    [RelayCommand]
    private async Task CopyUnixTimeAsync()
    {
        var value = TimeFormatter.ToUnixTimeSecondsString(_now());
        await _clipboard.SetTextAsync(value);
        _notifications.Notify("現在時刻 unixtime", $"{value} をコピーしました");
    }

    [RelayCommand]
    private async Task CopyYmdSlashAsync()
    {
        var value = TimeFormatter.ToYmdSlash(_now());
        await _clipboard.SetTextAsync(value);
        _notifications.Notify("現在時刻 Y/m/d H:i:s", $"{value} をコピーしました");
    }

    [RelayCommand]
    private async Task CopyYmdCompactAsync()
    {
        var value = TimeFormatter.ToYmdCompact(_now());
        await _clipboard.SetTextAsync(value);
        _notifications.Notify("現在時刻 YmdHis", $"{value} をコピーしました");
    }

    [RelayCommand]
    private async Task CopyIso8601ExampleAsync()
    {
        await _clipboard.SetTextAsync(Iso8601Example);
        const string message = "サンプル日付けをコピーしました。";
        _notifications.Notify("ISO8601", message);
        ConversionMessage = message;
    }

    [RelayCommand]
    private void Exit() => RequestExit?.Invoke();

    partial void OnUnixTimeInputChanged(string value)
    {
        UnixTimeAsLocalDate = TimeFormatter.TryParseUnixTimeString(value, out _, out var local)
            ? local
            : string.Empty;
    }

    partial void OnIso8601InputChanged(string value)
    {
        if (TimeFormatter.TryParseIso8601ToUnixSeconds(value, out var unix, out var local))
        {
            Iso8601AsUnixTime = unix.ToString();
            ConversionMessage = $"変換しました。日付けは{Environment.NewLine}{local}";
        }
        else
        {
            Iso8601AsUnixTime = string.Empty;
            ConversionMessage = string.IsNullOrEmpty(value) ? string.Empty : "変換出来ませんでした";
        }
    }
}
