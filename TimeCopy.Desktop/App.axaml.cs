using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using TimeCopy.Desktop.Services;
using TimeCopy.Desktop.ViewModels;
using TimeCopy.Desktop.Views;

namespace TimeCopy.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow();

            var clipboardService = new AvaloniaClipboardService(() => mainWindow.Clipboard);
            var notificationService = new WindowNotificationService(
                new WindowNotificationManager(mainWindow)
                {
                    Position = NotificationPosition.BottomRight,
                    MaxItems = 3,
                });

            var viewModel = new MainWindowViewModel(
                clipboardService,
                notificationService,
                () => DateTimeOffset.Now)
            {
                RequestExit = () => desktop.Shutdown(),
            };

            mainWindow.DataContext = viewModel;
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
