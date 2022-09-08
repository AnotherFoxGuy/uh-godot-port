
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Huker : Ship
{
	private Sprite3D factionColor;
	
	public new void _Ready()
	{
		factionColor= FindNode("FactionColor") as Sprite3D;
	}
	public void UpdateFactionColor()
	{  
		if(factionColor != null)
		{
			factionColor.Modulate = Global.FACTIONColors[(int)faction];
	
			// Match rotation of the ship's color outline with the main texture rotation
			factionColor.Frame = _billboard.Frame;
	
	
		}
	}
	
	
	
}