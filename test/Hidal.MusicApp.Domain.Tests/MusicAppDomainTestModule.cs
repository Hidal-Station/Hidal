using Hidal.MusicApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hidal.MusicApp;

[DependsOn(
    typeof(MusicAppEntityFrameworkCoreTestModule)
    )]
public class MusicAppDomainTestModule : AbpModule
{

}
