
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SugarField : Building
{
	 
	public const var SUGARFieldIdle = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_idle.png");
	public const var SUGARFieldIdleFull = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_idle_full.png");
	
	//const SUGARFieldWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_45.png");
	//const SUGARFieldWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_135.png");
	//const SUGARFieldWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_225.png");
	//const SUGARFieldWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_315.png");
	
	//const SUGARFieldWorkAnim = new Array(){
	//	SUGARFieldWork45,
	//	SUGARFieldWork135,
	//	SUGARFieldWork225,
	//	SUGARFieldWork315,
	//};
	public const var SUGARFieldWorkAnim = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_anim.png");
	public static readonly Array SUGARFieldWorkAnimRegionY = new Array(){
		0, 192, 384, 576
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = SUGARFieldIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"idle_full",
				currentAnim = null;
				self.texture = SUGARFieldIdleFull;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_rect = new Rect2(0}, 0, 384, 384);
				_billboard.region_enabled = true
	
			{"work",
					currentAnim = SUGARFieldWorkAnim;
					self.texture = SUGARFieldWorkAnim;
					_billboard.vframes = 1;
					_billboard.hframes = 5;
					_billboard.region_rect = new Rect2(0}, SUGARFieldWorkAnimRegionY[self.rotation_index], 960, 192);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}
	
	
	
}