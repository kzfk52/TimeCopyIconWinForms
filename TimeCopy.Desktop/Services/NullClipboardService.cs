using System.Threading.Tasks;

namespace TimeCopy.Desktop.Services;

public sealed class NullClipboardService : IClipboardService
{
    public Task SetTextAsync(string text) => Task.CompletedTask;
}
