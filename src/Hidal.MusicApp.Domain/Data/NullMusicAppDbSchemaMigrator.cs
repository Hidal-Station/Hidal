using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Hidal.MusicApp.Data;

/* This is used if database provider does't define
 * IMusicAppDbSchemaMigrator implementation.
 */
public class NullMusicAppDbSchemaMigrator : IMusicAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
