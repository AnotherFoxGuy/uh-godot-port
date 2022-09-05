
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ShipMenuTabWidget : TabWidget
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
	
	
	
}