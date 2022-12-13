using System;
using System.Collections.Generic;
using System.Text;
using Hidal.MusicApp.Localization;
using Volo.Abp.Application.Services;

namespace Hidal.MusicApp;

/* Inherit your application services from this class.
 */
public abstract class MusicAppAppService : ApplicationService
{
    protected MusicAppAppService()
    {
        LocalizationResource = typeof(MusicAppResource);
    }
}
