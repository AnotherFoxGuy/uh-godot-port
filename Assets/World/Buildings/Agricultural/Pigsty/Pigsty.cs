
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pigsty : Building
{
	 
	public const var PIGSTYIdle = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_idle.png");
	
	public const var PIGSTYWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_45.png");
	public const var PIGSTYWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_135.png");
	public const var PIGSTYWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_225.png");
	public const var PIGSTYWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_315.png");
	
	public static readonly Array PIGSTYWorkAnim = new Array(){
		PIGSTYWork45,
		PIGSTYWork135,
		PIGSTYWork225,
		PIGSTYWork315
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = PIGSTYIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
				// set new animation set && randomize frame for the initial time},
				// afterwards only iterate through frames
				if(currentAnim != null && currentAnim[0].GetLoadPath().Find("_work") == -1 || currentAnim == null)
				{
					currentAnim = PIGSTYWorkAnim;
					self.texture = PIGSTYWorkAnim[self.rotation_index];
					_billboard.vframes = 8;
					_billboard.hframes = 10;
					_billboard.region_rect = new Rect2(0, 0, 1920, 1536);
					_billboard.region_enabled = true;
	
					_billboard.frame = GetRandomFrame();
					//prints(self.name, "randomized frame:", _billboard.frame)
				}
				else
				{
					_billboard.frame = NextFrame();
	
				}
		}
		base.Animate()
	
	
	}
	
	
	
}