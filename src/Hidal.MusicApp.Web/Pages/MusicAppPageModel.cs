using Hidal.MusicApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hidal.MusicApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MusicAppPageModel : AbpPageModel
{
    protected MusicAppPageModel()
    {
        LocalizationResourceType = typeof(MusicAppResource);
    }
}
