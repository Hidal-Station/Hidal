using Volo.Abp.Modularity;

namespace Hidal.MusicApp;

[DependsOn(
    typeof(MusicAppApplicationModule),
    typeof(MusicAppDomainTestModule)
    )]
public class MusicAppApplicationTestModule : AbpModule
{

}
