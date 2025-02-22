using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reqnroll;

namespace ReqnrollOutputExample.Specs;

public class ApiWebApplicationFactory<TProgram>(IReqnrollOutputHelper reqnrollOutputHelper) : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureTestServices(serviceCollection =>
            {
                serviceCollection.AddLogging(configure =>
                {
                    configure.AddProvider(new ReqnrollLoggerProvider(reqnrollOutputHelper));
                });
            });
    }
}
