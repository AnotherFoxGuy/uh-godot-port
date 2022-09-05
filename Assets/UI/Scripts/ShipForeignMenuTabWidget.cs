
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ShipForeignMenuTabWidget : TabWidget
{
	 
	//onready var factionIndicator = $WidgetDetail/Body/ShipMenu/MarginContainer/FactionIndicator
	onready var factionIndicator = FindNode("FactionIndicator");
	
	public void _Ready()
	{  
		if(Engine.IsEditorHint())
		{
			return;
	
		}
		factionIndicator.texture = Global.FACTION_FLAGS[Global.faction];
	
	}
	
	public void UpdateData(Dictionary contextData)
	{  
		foreach(var data in contextData)
		{
			GD.PrintS("data:", data) ;// TownName
			var node = FindNode(data);
	
			if(node is Label)
			{
				node.text = contextData[data];
	
			}
			if(data == "FactionIndicator")
			{
				factionIndicator.texture = contextData[data];
	
	
			}
		}
	}
	
	
	
}