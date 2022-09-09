
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ShipMenuTabWidget : TabWidget
{
	 
	//onready var factionIndicator = $WidgetDetail/Body/ShipMenu/MarginContainer/FactionIndicator
	 TextureRect factionIndicator;
	
	public void _Ready()
	{
		factionIndicator = FindNode("FactionIndicator") as TextureRect;
		if(Engine.IsEditorHint())
		{
			return;
	
		}
		factionIndicator.Texture = Global.FACTIONFlags[(int)Global.faction];
	
	
	}
	
	
	
}