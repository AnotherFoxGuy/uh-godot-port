
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pasture : Building
{
	 
	public const var PASTUREIdle = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_idle.png");
	
	public const var PASTUREWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_45.png");
	public const var PASTUREWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_135.png");
	public const var PASTUREWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_225.png");
	public const var PASTUREWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_315.png");
	
	public static readonly Array PASTUREWorkAnim = new Array(){
		PASTUREWork45,
		PASTUREWork135,
		PASTUREWork225,
		PASTUREWork315,
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = PASTUREIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
				// set new animation set && randomize frame for the initial time},
				// afterwards only iterate through frames
				if(currentAnim != null && currentAnim[0].GetLoadPath().Find("_work") == -1 || currentAnim == null)
				{
					currentAnim = PASTUREWorkAnim;
					//update_rotation()
					self.texture = PASTUREWorkAnim[self.rotation_index];
					_billboard.vframes = 10;
					_billboard.hframes = 20;
					_billboard.region_rect = new Rect2(0, 0, 3840, 1920);
					_billboard.region_enabled = true;
	
					_billboard.frame = GetRandomFrame();
					//prints("randomized frame:", _billboard.frame)
				}
				else
				{
					_billboard.frame = NextFrame();
	
				}
		}
		base.Animate()
	
	
	}
	
	
	
}