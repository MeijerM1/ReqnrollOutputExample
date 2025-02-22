using Microsoft.Extensions.Logging;
using Reqnroll;

namespace ReqnrollOutputExample.Specs;

public class ReqnrollLoggerProvider(IReqnrollOutputHelper reqnrollOutput) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {                
        return new ReqnrollLogger(reqnrollOutput);
    }

    public void Dispose()
    {
    }

}
