using System;
using System.IO;
using System.Text;

namespace TimeCopy.Desktop;

public sealed class SingleInstanceLock : IDisposable
{
    private readonly string _path;
    private FileStream? _stream;

    public SingleInstanceLock(string applicationName)
    {
        var directory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            applicationName);
        Directory.CreateDirectory(directory);
        _path = Path.Combine(directory, "instance.lock");
    }

    public bool TryAcquire()
    {
        try
        {
            _stream = new FileStream(
                _path,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.None);

            _stream.SetLength(0);
            var pid = Encoding.UTF8.GetBytes(Environment.ProcessId.ToString());
            _stream.Write(pid, 0, pid.Length);
            _stream.Flush();
            return true;
        }
        catch (IOException)
        {
            _stream = null;
            return false;
        }
    }

    public void Dispose()
    {
        _stream?.Dispose();
        _stream = null;
    }
}
