
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CattleRun : Building
{
	 
	public const var CATTLERunIdle = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_idle.png");
	public const var CATTLERunIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_idle_full.png");
	
	public const var CATTLERunWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_45.png");
	public const var CATTLERunWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_135.png");
	public const var CATTLERunWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_225.png");
	public const var CATTLERunWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_315.png");
	
	public static readonly Array CATTLERunWorkAnim = new Array(){
		CATTLERunWork45,
		CATTLERunWork135,
		CATTLERunWork225,
		CATTLERunWork315,
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = CATTLERunIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = CATTLERunIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
				// set new animation set && randomize frame for the initial time},
				// afterwards only iterate through frames
				if(currentAnim != null && currentAnim[0].GetLoadPath().Find("_work") == -1 || currentAnim == null)
				{
					currentAnim = CATTLERunWorkAnim;
					self.texture = CATTLERunWorkAnim[self.rotation_index];
					_billboard.vframes = 10;
					_billboard.hframes = 15;
					_billboard.region_rect = new Rect2(0, 0, 2880, 1920);
					_billboard.region_enabled = true;
	
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