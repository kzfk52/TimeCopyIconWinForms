using System.Threading.Tasks;

namespace TimeCopy.Desktop.Services;

public sealed class NullClipboardService : IClipboardService
{
    public Task SetTextAsync(string text) => Task.CompletedTask;

    public Task<string?> GetTextAsync() => Task.FromResult<string?>(null);
}
