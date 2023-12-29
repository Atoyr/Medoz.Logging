using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Xunit;

namespace Medoz.Logging.Tests;

public class FileLoggerTests
{
    [Fact]
    public void LogsMessageToFile()
    {
        // Arrange
        string path = "test.log";
        var logger = new FileLogger(new FileLoggerSettings(Path.GetDirectoryName(path) ?? "")
        {
            FileName = path,
        });

        // Act
        logger.LogInformation("Test message");

        // Assert
        string content = File.ReadAllText(path);
        Assert.Contains("Test message", content);

        // Cleanup
        File.Delete(path);
    }
}