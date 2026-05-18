using System;
using System.Diagnostics;

namespace TimeCopy.Desktop.Services;

public sealed class MacOsNotificationService : INotificationService
{
    public void Notify(string title, string message)
    {
        try
        {
            var script = $"display notification \"{Escape(message)}\" with title \"{Escape(title)}\"";
            var psi = new ProcessStartInfo("osascript")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };
            psi.ArgumentList.Add("-e");
            psi.ArgumentList.Add(script);

            using var process = Process.Start(psi);
        }
        catch
        {
            // Notifications are best-effort: a missing osascript binary or a
            // sandbox restriction should not crash the application.
        }
    }

    private static string Escape(string value)
        => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
