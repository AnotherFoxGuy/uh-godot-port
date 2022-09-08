
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Windmill : Building
{
	 
	Texture WINDMILLIdle = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle.png");
	Texture WINDMILLIdleFull = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle_full.png");
	
	Texture WINDMILLWork45 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_45.png");
	Texture WINDMILLWork135 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_135.png");
	Texture WINDMILLWork225 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_225.png");
	Texture WINDMILLWork315 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_315.png");
	
	public static readonly Array WINDMILLWorkAnim = new Array(){
		WINDMILLWork45,
		WINDMILLWork135,
		WINDMILLWork225,
		WINDMILLWork315,
	};
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = WINDMILLIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 256, 256)
	
			case "idle_full":
				currentAnim = null;
				texture = WINDMILLIdleFull;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionRect = new Rect2(0}, 0, 256, 256)
	
			case "work":
				// set new animation set && randomize frame for the initial time},
				// afterwards only iterate through frames
				if(currentAnim != null && currentAnim[0].GetLoadPath().Find("_work") == -1 || currentAnim == null)
				{
					currentAnim = WINDMILLWorkAnim;
					texture = WINDMILLWorkAnim[rotationIndex];
					_billboard.Vframes = 5;
					_billboard.Hframes = 6;
					_billboard.RegionRect = new Rect2(0, 0, 768, 640);
	
					_billboard.Frame = GetRandomFrame();
					//prints(self.name, "randomized frame:", _billboard.Frame)
				}
				else
				{
					_billboard.Frame = NextFrame();
	
				}
		}
		base.Animate()
	
	
	}
	
	
	
}