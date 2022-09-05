
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Toolmaker : Building
{
	 
	public const var TOOLMAKERIdle = GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_idle.png");
	
	public const var TOOLMAKERWorkAnim = GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_work_anim.png");
	public static readonly Array TOOLMAKERWorkAnimRegionY = new Array(){
		98*0, 98*1, 98*2, 98*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = TOOLMAKERIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 256, 196);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = TOOLMAKERWorkAnim;
				self.texture = TOOLMAKERWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 8;
				_billboard.region_rect = new Rect2(0}, TOOLMAKERWorkAnimRegionY[self.rotation_index], 1024, 98);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}