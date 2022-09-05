
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Smeltery : Building
{
	 
	public const var SMELTERYIdle = GD.Load("res://Assets/World/Buildings/Smeltery/Sprites/Smeltery_idle.png");
	
	public const var SMELTERYWorkAnim = GD.Load("res://Assets/World/Buildings/Smeltery/Sprites/Smeltery_work.png");
	public static readonly Array SMELTERYWorkAnimRegionY = new Array(){
		155*0, 155*1, 155*2, 155*3
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = SMELTERYIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 512, 310);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = SMELTERYWorkAnim;
				self.texture = SMELTERYWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 6;
				_billboard.region_rect = new Rect2(0}, SMELTERYWorkAnimRegionY[self.rotation_index], 1536, 155);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}