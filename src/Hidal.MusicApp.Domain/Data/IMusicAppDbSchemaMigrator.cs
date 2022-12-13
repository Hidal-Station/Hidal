using System.Threading.Tasks;

namespace Hidal.MusicApp.Data;

public interface IMusicAppDbSchemaMigrator
{
    Task MigrateAsync();
}
