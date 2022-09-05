
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MainSquare : Building
{
	 
	// Tiers
	public const string MAINSquare = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
	public const string MAINSquareWooden = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
	public const string MAINSquareTimberFramed = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
	public const string MAINSquareStone = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
	
	// Tier 1 (Sailors) Resources
	public const var MAINSquareIdle45 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_45.png");
	public const var MAINSquareIdle135 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_135.png");
	public const var MAINSquareIdle225 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_225.png");
	public const var MAINSquareIdle315 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_315.png");
	
	// Tier 2 (Pioneers) Resources
	public const var MAINSquareWoodenIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareWooden_idle.png");
	
	// Tier 3 (Settlers) Resources
	public const var MAINSquareTimberFramedIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareTimberFramed_idle.png");
	
	// Tier 4 (Citizens) Resources
	public const var MAINSquareStoneIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareStone_idle.png");
	
	// Tier 1 (Sailors) Sprites
	public static readonly Array MAINSquareIdleAnim = new Array(){
		MAINSquareIdle45,
		MAINSquareIdle135,
		MAINSquareIdle225,
		MAINSquareIdle315,
	};
	
	// Tier 2 (Pioneers) Sprites
	// Tier 3 (Settlers) Sprites
	// Tier 4 (Citizens) Sprites
	
	public static readonly Array TIERS = new Array(){
		MAINSquareIdleAnim,
		MAINSquareWoodenIdle,
		MAINSquareTimberFramedIdle,
		MAINSquareStoneIdle,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				// As of now}, only 1st tier is animated
				if(tier == 0)
				{
					currentAnim = TIERS[tier];
					self.texture = TIERS[tier][self.rotation_index];
					_billboard.vframes = 2;
					_billboard.hframes = 13;
					_billboard.region_rect = new Rect2(0, 0, 4992, 448);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
				}
				else
				{
					currentAnim = null;
					self.texture = TIERS[tier];
					_billboard.vframes = 2;
					_billboard.hframes = 2;
					_billboard.region_rect = new Rect2(0, 0, 768, 448);
					_billboard.region_enabled = true;
	
				}
		}
		base.Animate()
	
	}
	
	public void SetTier(int newTier)
	{  
		var previousTier = tier;
	
		tier = Mathf.Clamp(newTier, 0, TIERS.Size() - 1);
		if(tier > previousTier)
		{
			Upgrade();
		}
		else
		{
			Downgrade();
	
		}
	}
	
	public void Upgrade()
	{  
		pass ;// TODO
	
	}
	
	public void Downgrade()
	{  
		pass ;// TODO
	
	
	}
	
	
	
}