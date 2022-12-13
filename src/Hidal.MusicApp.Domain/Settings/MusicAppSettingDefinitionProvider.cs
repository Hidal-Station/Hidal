using Volo.Abp.Settings;

namespace Hidal.MusicApp.Settings;

public class MusicAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MusicAppSettings.MySetting1));
    }
}
