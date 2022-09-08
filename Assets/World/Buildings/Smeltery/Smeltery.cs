
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Smeltery : Building
{
	 
	Texture SMELTERYIdle = GD.Load("res://Assets/World/Buildings/Smeltery/Sprites/Smeltery_idle.png");
	
	Texture SMELTERYWorkAnim = GD.Load("res://Assets/World/Buildings/Smeltery/Sprites/Smeltery_work.png");
	public static readonly Array SMELTERYWorkAnimRegionY = new Array(){
		155*0, 155*1, 155*2, 155*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = SMELTERYIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 512, 310);
				_billboard.RegionEnabled = true
	
			case "work":
				currentAnim = SMELTERYWorkAnim;
				texture = SMELTERYWorkAnim;
				_billboard.Vframes = 1;
				_billboard.Hframes = 6;
				_billboard.RegionRect = new Rect2(0}, SMELTERYWorkAnimRegionY[rotationIndex], 1536, 155);
				_billboard.RegionEnabled = true;
	
				_billboard.Frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}