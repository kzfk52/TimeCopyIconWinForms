using System;
using Avalonia;

namespace TimeCopy.Desktop;

sealed class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        using var instanceLock = new SingleInstanceLock("TimeCopy");
        if (!instanceLock.TryAcquire())
        {
            Console.Error.WriteLine("TimeCopy is already running.");
            return 1;
        }

        return BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}
