using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hidal.MusicApp.Data;
using Volo.Abp.DependencyInjection;

namespace Hidal.MusicApp.EntityFrameworkCore;

public class EntityFrameworkCoreMusicAppDbSchemaMigrator
    : IMusicAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMusicAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MusicAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MusicAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
