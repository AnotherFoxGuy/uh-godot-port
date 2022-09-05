
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SaltPonds : Building
{
	 
	public const var SALTPondIdle = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle.png");
	public const var SALTPondIdleFull = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle_full.png");
	
	public const var SALTPondWorkAnim = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_work_anim.png");
	public static readonly Array SALTPondWorkAnimRegionY = new Array(){
		32, 224, 416, 608
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = SALTPondIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 256);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = SALTPondIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 256);
				_billboard.region_enabled = true
	
			{"work",
				currentAnim = SALTPondWorkAnim;
				self.texture = SALTPondWorkAnim;
				_billboard.vframes = 1;
				_billboard.hframes = 6;
				_billboard.region_rect = new Rect2(0}, SALTPondWorkAnimRegionY[self.rotation_index], 1152, 192);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}