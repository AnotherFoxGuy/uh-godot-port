
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Bakery : Building
{
	 
	public const var BAKERYIdle = GD.Load("res://Assets/World/Buildings/Bakery/Sprites/Bakery_idle.png");
	
	public const var BAKERYWorkAnim = GD.Load("res://Assets/World/Buildings/Bakery/Sprites/Bakery_work_anim.png");
	public static readonly Array BAKERYWorkAnimRegionY = new Array(){
		128*0, 128*1, 128*2, 128*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = BAKERYIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 256, 256);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = BAKERYWorkAnim;
				self.texture = BAKERYWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 8;
				_billboard.region_rect = new Rect2(0}, BAKERYWorkAnimRegionY[self.rotation_index], 1024, 128);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}