
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Huker : Ship
{
	 
	onready Sprite3D factionColor = FindNode("FactionColor") as Sprite3D;
	
	public void UpdateFactionColor()
	{  
		if(factionColor != null)
		{
			factionColor.modulate = Global.FACTION_COLORS[faction];
	
			// Match rotation of the ship's color outline with the main texture rotation
			factionColor.frame = _billboard.frame;
	
	
		}
	}
	
	
	
}