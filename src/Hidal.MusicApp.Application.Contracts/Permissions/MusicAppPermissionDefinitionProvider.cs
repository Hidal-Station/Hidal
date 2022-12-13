using Hidal.MusicApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hidal.MusicApp.Permissions;

public class MusicAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MusicAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MusicAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MusicAppResource>(name);
    }
}
