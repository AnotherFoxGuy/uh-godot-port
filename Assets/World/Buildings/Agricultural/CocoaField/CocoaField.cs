
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CocoaField : Building
{
	 
	public const var COCOAFieldIdle = GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle.png");
	public const var COCOAFieldIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle_full.png");
	
	public const var COCOAFieldWorkAnim = GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_work_anim.png");
	public static readonly Array COCOAFieldWorkAnimRegionY = new Array(){
		192*0, 192*1, 192*2, 192*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = COCOAFieldIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = COCOAFieldIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
					currentAnim = COCOAFieldWorkAnim;
					self.texture = COCOAFieldWorkAnim;
					_billboard.vframes = 1;
					_billboard.hframes = 5;
					_billboard.region_rect = new Rect2(0}, COCOAFieldWorkAnimRegionY[self.rotation_index], 960, 192);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}