
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BuildMenuContainer : GridContainer
{
	 
	public void _Notification(int what)
	{  
		switch( what)
		{
			case NOTIFICATIONReady:
				var theme  = GD.Load(ProjectSettings.GetSetting("gui/theme/custom")) as Theme;
	
				if(!has_constant_override("vseparation"))
				{
					AddConstantOverride("vseparation", theme.GetConstant("buildmenu_vseparation", "GridContainer"));
	
	
				}
				break;
		}
	}
	
	
	
}