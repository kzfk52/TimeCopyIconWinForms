using System;
using System.Threading.Tasks;
using Avalonia.Input.Platform;

namespace TimeCopy.Desktop.Services;

public sealed class AvaloniaClipboardService : IClipboardService
{
    private readonly Func<IClipboard?> _resolveClipboard;

    public AvaloniaClipboardService(Func<IClipboard?> resolveClipboard)
    {
        _resolveClipboard = resolveClipboard;
    }

    public async Task SetTextAsync(string text)
    {
        var clipboard = _resolveClipboard();
        if (clipboard is null)
        {
            return;
        }

        await clipboard.SetTextAsync(text);
    }

    public async Task<string?> GetTextAsync()
    {
        var clipboard = _resolveClipboard();
        if (clipboard is null)
        {
            return null;
        }

        return await clipboard.TryGetTextAsync();
    }
}
