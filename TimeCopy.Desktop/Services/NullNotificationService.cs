namespace TimeCopy.Desktop.Services;

public sealed class NullNotificationService : INotificationService
{
    public void Notify(string title, string message)
    {
    }
}
