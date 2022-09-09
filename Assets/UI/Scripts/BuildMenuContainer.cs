using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BuildMenuContainer : GridContainer
{
    public void _Notification(int what)
    {
        switch (what)
        {
            case NotificationReady:
                var theme = GD.Load(ProjectSettings.GetSetting("gui/theme/custom") as string) as Theme;

                if (!HasConstantOverride("vseparation"))
                {
                    AddConstantOverride("vseparation", theme.GetConstant("buildmenu_vseparation", "GridContainer"));
                }

                break;
        }
    }
}