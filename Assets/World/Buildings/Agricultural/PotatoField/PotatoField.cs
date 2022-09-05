
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PotatoField : Building
{
	 
	public const var POTATOFieldIdle = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_idle.png");
	public const var POTATOFieldIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_idle_full.png");
	
	//const POTATOFieldWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_45.png");
	//const POTATOFieldWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_135.png");
	//const POTATOFieldWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_225.png");
	//const POTATOFieldWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_315.png");
	
	//const POTATOFieldWorkAnim = new Array(){
	//	POTATOFieldWork45,
	//	POTATOFieldWork135,
	//	POTATOFieldWork225,
	//	POTATOFieldWork315,
	//};
	public const var POTATOFieldWorkAnim = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_anim.png");
	public static readonly Array POTATOFieldWorkAnimRegion = new Array(){
		0, 192, 384, 576
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = POTATOFieldIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = POTATOFieldIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
					currentAnim = POTATOFieldWorkAnim;
					self.texture = POTATOFieldWorkAnim;
					_billboard.vframes = 1;
					_billboard.hframes = 5;
					_billboard.region_rect = new Rect2(0}, POTATOFieldWorkAnimRegion[self.rotation_index], 960, 192);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}