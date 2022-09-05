
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Windmill : Building
{
	 
	public const var WINDMILLIdle = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle.png");
	public const var WINDMILLIdleFull = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle_full.png");
	
	public const var WINDMILLWork45 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_45.png");
	public const var WINDMILLWork135 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_135.png");
	public const var WINDMILLWork225 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_225.png");
	public const var WINDMILLWork315 = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_315.png");
	
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
			{"idle",
				currentAnim = null;
				self.texture = WINDMILLIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 256, 256)
	
			{"idle_full",
				currentAnim = null;
				self.texture = WINDMILLIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 256, 256)
	
			{"work",
				// set new animation set && randomize frame for the initial time},
				// afterwards only iterate through frames
				if(currentAnim != null && currentAnim[0].GetLoadPath().Find("_work") == -1 || currentAnim == null)
				{
					currentAnim = WINDMILLWorkAnim;
					self.texture = WINDMILLWorkAnim[self.rotation_index];
					_billboard.vframes = 5;
					_billboard.hframes = 6;
					_billboard.region_rect = new Rect2(0, 0, 768, 640);
	
					_billboard.frame = GetRandomFrame();
					//prints(self.name, "randomized frame:", _billboard.frame)
				}
				else
				{
					_billboard.frame = NextFrame();
	
				}
		}
		base.Animate()
	
	
	}
	
	
	
}