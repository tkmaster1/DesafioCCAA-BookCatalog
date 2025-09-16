using Microsoft.Extensions.Logging;

namespace BookCatalog.Common.Util.Configuration;

public class CustomLoggerProviderConfiguration
{
    public LogLevel LogLevel { get; set; } = LogLevel.Error;

    public int EventId { get; set; } = 0;

    public string Path { get; set; }

    public string NomeArquivo { get; set; }
}