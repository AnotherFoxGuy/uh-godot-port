
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
	Texture MAINSquareIdle45 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_45.png");
	Texture MAINSquareIdle135 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_135.png");
	Texture MAINSquareIdle225 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_225.png");
	Texture MAINSquareIdle315 = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_315.png");
	
	// Tier 2 (Pioneers) Resources
	Texture MAINSquareWoodenIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareWooden_idle.png");
	
	// Tier 3 (Settlers) Resources
	Texture MAINSquareTimberFramedIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareTimberFramed_idle.png");
	
	// Tier 4 (Citizens) Resources
	Texture MAINSquareStoneIdle = GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareStone_idle.png");
	
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
			case "idle":
				// As of now}, only 1st tier is animated
				if(tier == 0)
				{
					currentAnim = TIERS[tier];
					texture = TIERS[tier][rotationIndex];
					_billboard.Vframes = 2;
					_billboard.Hframes = 13;
					_billboard.RegionRect = new Rect2(0, 0, 4992, 448);
					_billboard.RegionEnabled = true;
	
					_billboard.Frame = NextFrame();
				}
				else
				{
					currentAnim = null;
					texture = TIERS[tier];
					_billboard.Vframes = 2;
					_billboard.Hframes = 2;
					_billboard.RegionRect = new Rect2(0, 0, 768, 448);
					_billboard.RegionEnabled = true;
	
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