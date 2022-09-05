
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CornField : Building
{
	 
	public const var CORNFieldIdle = GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_idle.png");
	public const var CORNFieldIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_idle_full.png");
	
	public const var CORNFieldWorkAnim = GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_work_anim.png");
	public static readonly Array CORNFieldWorkAnimRegionY = new Array(){
		192*0, 192*1, 192*2, 192*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = CORNFieldIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = CORNFieldIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
					currentAnim = CORNFieldWorkAnim;
					self.texture = CORNFieldWorkAnim;
					_billboard.vframes = 1;
					_billboard.hframes = 4;
					_billboard.region_rect = new Rect2(0}, CORNFieldWorkAnimRegionY[self.rotation_index], 768, 192);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}