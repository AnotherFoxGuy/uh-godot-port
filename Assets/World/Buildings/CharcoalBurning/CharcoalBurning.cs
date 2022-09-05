
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CharcoalBurning : Building
{
	 
	public const var CHARCOALBurningIdle = GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_idle.png");
	public const var CHARCOALBurningIdleFull = GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_idle_full.png");
	
	public const var CHARCOALBurningWorkAnim = GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_work_anim.png");
	public static readonly Array CHARCOALBurningWorkAnimRegionY = new Array(){
		108*0, 108*1, 108*2, 108*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = CHARCOALBurningIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 316, 216);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = CHARCOALBurningIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 316, 216);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = CHARCOALBurningWorkAnim;
				self.texture = CHARCOALBurningWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 7;
				_billboard.region_rect = new Rect2(0}, CHARCOALBurningWorkAnimRegionY[self.rotation_index], 1106, 108);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}