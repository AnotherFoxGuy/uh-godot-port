
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Brewery : Building
{
	 
	public const var BREWERYIdle = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_idle.png");
	public const var BREWERYIdleFull = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_idle_full.png");
	
	public const var BREWERYWork45 = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_45.png");
	public const var BREWERYWork135 = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_135.png");
	public const var BREWERYWork225 = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_225.png");
	public const var BREWERYWork315 = GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_315.png");
	
	public static readonly Array BREWERYWorkAnim = new Array(){
		BREWERYWork45,
		BREWERYWork135,
		BREWERYWork225,
		BREWERYWork315,
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = BREWERYIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_enabled = false
	
			{"idle_full",
				currentAnim = null;
				self.texture = BREWERYIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_enabled = false
	
			{"work",
				currentAnim = BREWERYWorkAnim;
				self.texture = BREWERYWorkAnim[self.rotation_index];
				_billboard.vframes = 4;
				_billboard.hframes = 4;
				_billboard.region_enabled = false;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}}}}
	
	
	
}