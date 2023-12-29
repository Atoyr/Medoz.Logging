using Microsoft.Extensions.Logging;

namespace Medoz.Logging;

public class FileLogger : ILogger
{
    private readonly FileLoggerSettings _settings;
    private readonly object _lock = new object();

    public FileLogger(FileLoggerSettings settings)
    {
        _settings = settings;
    }

    public IDisposable BeginScope<TState>(TState state) => default;

    public bool IsEnabled(LogLevel logLevel)
    {
        if (logLevel == LogLevel.None)
        {
            return false;
        }
        return logLevel >= _settings.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var message = formatter(state, exception);
        var logMessage = $"{DateTime.Now}: {logLevel} - {message}";
        WriteTextToFile(logMessage);
    }

    private void WriteTextToFile(string message)
    {
        lock (_lock)
        {
            var fullPath = Path.Combine(_settings.FolderPath, _settings.FileName);
            File.AppendAllText(fullPath, message + Environment.NewLine);
        }
    }
}