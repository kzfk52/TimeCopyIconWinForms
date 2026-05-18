using System.Threading.Tasks;

namespace TimeCopy.Desktop.Services;

public interface IClipboardService
{
    Task SetTextAsync(string text);

    Task<string?> GetTextAsync();
}
