
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Toolmaker : Building
{
	 
	Texture TOOLMAKERIdle = GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_idle.png");
	
	Texture TOOLMAKERWorkAnim = GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_work_anim.png");
	public static readonly Array TOOLMAKERWorkAnimRegionY = new Array(){
		98*0, 98*1, 98*2, 98*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = TOOLMAKERIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 256, 196);
				_billboard.RegionEnabled = true
	
			case "work":
				currentAnim = TOOLMAKERWorkAnim;
				texture = TOOLMAKERWorkAnim;
				_billboard.Vframes = 1;
				_billboard.Hframes = 8;
				_billboard.RegionRect = new Rect2(0}, TOOLMAKERWorkAnimRegionY[rotationIndex], 1024, 98);
				_billboard.RegionEnabled = true;
	
				_billboard.Frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}