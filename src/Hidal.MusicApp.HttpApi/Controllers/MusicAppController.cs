using Hidal.MusicApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Hidal.MusicApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MusicAppController : AbpControllerBase
{
    protected MusicAppController()
    {
        LocalizationResource = typeof(MusicAppResource);
    }
}
