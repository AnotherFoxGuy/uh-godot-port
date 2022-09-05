
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Distillery : Building
{
	 
	public const var DISTILLERYIdle = GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_idle.png");
	
	public const var DISTILLERYWorkAnim = GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_work_anim.png");
	public static readonly Array DISTILLERYWorkAnimRegionY = new Array(){
		98*0, 98*1, 98*2, 98*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = DISTILLERYIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 256, 196);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = DISTILLERYWorkAnim;
				self.texture = DISTILLERYWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 5;
				_billboard.region_rect = new Rect2(0}, DISTILLERYWorkAnimRegionY[self.rotation_index], 640, 98);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}