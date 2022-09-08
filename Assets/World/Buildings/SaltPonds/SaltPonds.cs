
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SaltPonds : Building
{
	 
	Texture SALTPondIdle = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle.png");
	Texture SALTPondIdleFull = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle_full.png");
	
	Texture SALTPondWorkAnim = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_work_anim.png");
	public static readonly Array SALTPondWorkAnimRegionY = new Array(){
		32, 224, 416, 608
	};
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = SALTPondIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 384, 256);
				_billboard.RegionEnabled = true
	
			case "idle_full":
				currentAnim = null;
				texture = SALTPondIdleFull;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 384, 256);
				_billboard.RegionEnabled = true
	
			case "work":
				currentAnim = SALTPondWorkAnim;
				texture = SALTPondWorkAnim;
				_billboard.Vframes = 1;
				_billboard.Hframes = 6;
				_billboard.RegionRect = new Rect2(0}, SALTPondWorkAnimRegionY[rotationIndex], 1152, 192);
				_billboard.RegionEnabled = true;
	
				_billboard.Frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}