
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Alvearies : Building
{
	 
	public const var ALVEARIESIdle45 = GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_45.png");
	public const var ALVEARIESIdle135 = GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_135.png");
	public const var ALVEARIESIdle225 = GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_225.png");
	public const var ALVEARIESIdle315 = GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_315.png");
	
	public static readonly Array ALVEARIESIdleAnim = new Array(){
		ALVEARIESIdle45,
		ALVEARIESIdle135,
		ALVEARIESIdle225,
		ALVEARIESIdle315
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = ALVEARIESIdleAnim;
				self.texture = ALVEARIESIdleAnim[self.rotation_index];
				_billboard.vframes = 4;
				_billboard.hframes = 5;
				_billboard.region_rect = new Rect2(0}, 0, 960, 768);
				_billboard.region_enabled = true;
	
				_billboard.frame = NextFrame();
	
	
		}
	}
	
	
	
}