using Microsoft.Extensions.Logging;

namespace Medoz.Logging;

public static class FileLoggerExtensions
{
    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, FileLoggerSettings settings)
    {
        builder.AddProvider(new FileLoggerProvider(settings));
        return builder;
    }

    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string folderName)
    {
        builder.AddProvider(new FileLoggerProvider(new FileLoggerSettings(folderName)));
        return builder;
    }
}