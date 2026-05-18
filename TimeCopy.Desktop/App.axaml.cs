using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.Input;
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
            var notificationService = CreateNotificationService(mainWindow);

            var viewModel = new MainWindowViewModel(
                clipboardService,
                notificationService,
                () => DateTimeOffset.Now)
            {
                RequestExit = () => ShutdownApplication(desktop, mainWindow),
            };

            mainWindow.DataContext = viewModel;
            desktop.MainWindow = mainWindow;

            var showWindowCommand = new RelayCommand(() =>
            {
                if (!mainWindow.IsVisible)
                {
                    mainWindow.Show();
                }
                mainWindow.WindowState = WindowState.Normal;
                mainWindow.Activate();
            });

            ConfigureTrayIcon(viewModel, showWindowCommand);
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static INotificationService CreateNotificationService(MainWindow mainWindow)
    {
        // macOS native notifications via osascript require Script Editor
        // notification permission, which is off by default. The MacOs path is
        // kept in code (MacOsNotificationService) but will be wired only once
        // the app ships as a .app bundle in Phase 7. Until then everyone uses
        // the in-window toast.
        return new WindowNotificationService(
            new WindowNotificationManager(mainWindow)
            {
                Position = NotificationPosition.BottomRight,
                MaxItems = 3,
            });
    }

    private void ShutdownApplication(IClassicDesktopStyleApplicationLifetime desktop, MainWindow mainWindow)
    {
        TrayIcon.SetIcons(this, []);
        mainWindow.IsClosingForReal = true;
        desktop.Shutdown();
    }

    private void ConfigureTrayIcon(MainWindowViewModel viewModel, ICommand showWindowCommand)
    {
        var icon = LoadTrayIcon();

        var trayIcon = new TrayIcon
        {
            Icon = icon,
            ToolTipText = "TimeCopy",
            Menu = BuildTrayMenu(viewModel, showWindowCommand),
            IsVisible = true,
        };

        // Avoid wiring Clicked: macOS shows the menu on primary click and
        // suppresses the event, while on Windows it would race with the
        // context-menu interaction. All actions are reachable from the menu.
        TrayIcon.SetIcons(this, [trayIcon]);
    }

    private static WindowIcon LoadTrayIcon()
    {
        using var stream = AssetLoader.Open(new Uri("avares://TimeCopy.Desktop/Assets/stopwatch.png"));
        return new WindowIcon(stream);
    }

    private static NativeMenu BuildTrayMenu(MainWindowViewModel viewModel, ICommand showWindowCommand)
    {
        var menu = new NativeMenu();
        menu.Items.Add(new NativeMenuItem("ウィンドウを表示") { Command = showWindowCommand });
        menu.Items.Add(new NativeMenuItemSeparator());
        menu.Items.Add(new NativeMenuItem("AnnounceP") { Command = viewModel.AnnouncePCommand });
        menu.Items.Add(new NativeMenuItemSeparator());
        menu.Items.Add(new NativeMenuItem("UnixTime値をコピー") { Command = viewModel.CopyUnixTimeCommand });
        menu.Items.Add(new NativeMenuItem("Y/m/d H:i:sをコピー") { Command = viewModel.CopyYmdSlashCommand });
        menu.Items.Add(new NativeMenuItem("YmdHisをコピー") { Command = viewModel.CopyYmdCompactCommand });
        menu.Items.Add(new NativeMenuItemSeparator());
        menu.Items.Add(new NativeMenuItem("終了") { Command = viewModel.ExitCommand });
        return menu;
    }
}
