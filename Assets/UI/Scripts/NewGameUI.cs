
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class NewGameUI : BookMenu
{
	 
	onready var playerName  = FindNode("PlayerName") as LineEditEx;
	
	public void _Ready()
	{  
		// Deactivate everything irrelevant for the time being
		Dictionary nodes = new Dictionary(){
			{"Scenario", null},
			{"RandomMap", null},
			{"ResourceDensitySlider", null},
			{"Disasters", null},
		};
	
		FindNodes(GetTree().GetRoot(), nodes);
		nodes["Scenario"].check_box.disabled = true;
		nodes["RandomMap"].check_box.disabled = true;
		nodes["ResourceDensitySlider"].editable = false;
		nodes["Disasters"].disabled = true;
	
		if(Engine.IsEditorHint())
		{
			return;
	
		}
		playerName.text = Config.player_name;
	
	}
	
	public void FindNodes(Node rootNode, Dictionary nodesToBeFound)
	{  
		foreach(var n in rootNode.GetChildren())
		{
			if(n.GetChildCount() > 0)
			{
				FindNodes(n, nodesToBeFound);
	
			}
			if(n.name in nodesToBeFound)
			{
				nodesToBeFound[n.name] = n;
	
			}
		}
	}
	
	public void _OnCancelButtonPressed()
	{  
		base._OnCancelButtonPressed()
	
	}
	
	public void _OnOKButtonPressed()
	{  
		if(Global.map)
		{
			QueueFree();
			//warning-ignore:returnValueDiscarded
			GetTree().ChangeSceneTo(Global.map);
		}
		else
		{
			Audio.PlaySndFail();
	
	
		}
	}
	
	
	
}