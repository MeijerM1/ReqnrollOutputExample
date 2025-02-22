using Microsoft.Extensions.Logging;
using Reqnroll;

namespace ReqnrollOutputExample.Specs;

public class ReqnrollLogger(IReqnrollOutputHelper reqnrollOutput) : ILogger
{
    private readonly string _logPrefix = "Application log: ";
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        var message = _logPrefix;
        if (formatter != null)
        {
            message += formatter(state, exception);
        }
        reqnrollOutput.WriteLine(message);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}
