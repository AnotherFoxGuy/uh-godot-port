
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CannonFoundry : Building
{
	 
	public const var CANNONFoundryIdle = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_idle.png");
	public const var CANNONFoundryIdleFull = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_idle_full.png");
	
	public const var CANNONFoundryWork45 = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_45.png");
	public const var CANNONFoundryWork135 = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_135.png");
	public const var CANNONFoundryWork225 = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_225.png");
	public const var CANNONFoundryWork315 = GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_315.png");
	
	public static readonly Array CANNONFoundryWorkAnim = new Array(){
		CANNONFoundryWork45,
		CANNONFoundryWork135,
		CANNONFoundryWork225,
		CANNONFoundryWork315,
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = CANNONFoundryIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = CANNONFoundryIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = CANNONFoundryWorkAnim;
				self.texture = CANNONFoundryWorkAnim[self.rotation_index];
				_billboard.vframes = 7;
				_billboard.hframes = 20;
				_billboard.region_rect = new Rect2(0}, 0, 3840, 1344);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}