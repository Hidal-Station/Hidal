using Hidal.MusicApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Hidal.MusicApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MusicAppEntityFrameworkCoreModule),
    typeof(MusicAppApplicationContractsModule)
    )]
public class MusicAppDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
