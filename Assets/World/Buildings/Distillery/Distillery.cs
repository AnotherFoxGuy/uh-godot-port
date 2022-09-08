
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Distillery : Building
{
	 
	Texture DISTILLERYIdle = GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_idle.png");
	
	Texture DISTILLERYWorkAnim = GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_work_anim.png");
	public static readonly Array DISTILLERYWorkAnimRegionY = new Array(){
		98*0, 98*1, 98*2, 98*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = DISTILLERYIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 256, 196);
				_billboard.RegionEnabled = true
	
			case "work":
				currentAnim = DISTILLERYWorkAnim;
				texture = DISTILLERYWorkAnim;
				_billboard.Vframes = 1;
				_billboard.Hframes = 5;
				_billboard.RegionRect = new Rect2(0}, DISTILLERYWorkAnimRegionY[rotationIndex], 640, 98);
				_billboard.RegionEnabled = true;
	
				_billboard.Frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}