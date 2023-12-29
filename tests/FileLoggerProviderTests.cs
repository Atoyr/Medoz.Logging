using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Xunit;

namespace Medoz.Logging.Tests;

public class FileLoggerProviderTests
{
    [Fact]
    public void CreatesFileLoggerInstance()
    {
        // Arrange
        string path = "test.log";
        var provider = new FileLoggerProvider(new FileLoggerSettings(Path.GetDirectoryName(path) ?? "")
        {
            FileName = path,
        });

        // Act
        var logger = provider.CreateLogger("TestCategory");

        // Assert
        Assert.IsType<FileLogger>(logger);

    }
}