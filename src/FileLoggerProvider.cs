using Microsoft.Extensions.Logging;

namespace Medoz.Logging;

public class FileLoggerProvider: ILoggerProvider
{
    internal readonly FileLoggerSettings _settings;

    public FileLoggerProvider(FileLoggerSettings settings)
    {
        _settings = settings;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(_settings);
    }

    public void Dispose() { }
}