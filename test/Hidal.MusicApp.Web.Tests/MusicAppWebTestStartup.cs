using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Hidal.MusicApp;

public class MusicAppWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MusicAppWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
