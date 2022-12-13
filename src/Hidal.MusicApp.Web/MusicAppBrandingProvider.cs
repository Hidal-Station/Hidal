using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Hidal.MusicApp.Web;

[Dependency(ReplaceServices = true)]
public class MusicAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MusicApp";
}
