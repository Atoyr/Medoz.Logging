using Microsoft.Extensions.Logging;

namespace Medoz.Logging;

public class FileLoggerSettings
{
    public string FolderPath { get; set; } = null!;

    public string FileName { get; set; } = "log.txt";

    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public FileLoggerSettings(string folderPath)
    {
        FolderPath = folderPath;
    }
}