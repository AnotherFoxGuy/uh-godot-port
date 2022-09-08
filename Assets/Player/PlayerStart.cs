
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class PlayerStart : Spatial
{

	public void _Ready()
	{  
		Global.PlayerStart = this;
	
		// GetNode("VisualMarker").Get("material/0").Set("albedo_color", new Color(1, 1, 1, 0));
		//
		// foreach(var ship in ships)
		// {
		// 	ship.direction = GD.Randi() % Ship.RotationDegree.Size();
		//
		// }
	}
	
}