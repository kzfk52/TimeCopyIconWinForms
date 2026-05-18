using Avalonia.Controls.Notifications;

namespace TimeCopy.Desktop.Services;

public sealed class WindowNotificationService : INotificationService
{
    private readonly WindowNotificationManager _manager;

    public WindowNotificationService(WindowNotificationManager manager)
    {
        _manager = manager;
    }

    public void Notify(string title, string message)
    {
        _manager.Show(new Notification(title, message, NotificationType.Information));
    }
}
