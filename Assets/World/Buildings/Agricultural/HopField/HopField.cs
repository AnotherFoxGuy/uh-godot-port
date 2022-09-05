
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class HopField : Building
{
	 
	public const var HOPFieldIdle = GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_idle.png");
	public const var HOPFieldIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_idle_full.png");
	
	public const var HOPFieldWorkAnim = GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_work_anim.png");
	public static readonly Array HOPFieldWorkAnimRegionY = new Array(){
		192*0, 192*1, 192*2, 192*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = HOPFieldIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = HOPFieldIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = HOPFieldWorkAnim;
				self.texture = HOPFieldWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 4;
				_billboard.region_rect = new Rect2(0}, HOPFieldWorkAnimRegionY[self.rotation_index], 768, 192);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}