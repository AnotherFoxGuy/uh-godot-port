
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SignalFire : Building
{
	 
	// Tiers
	public const string SIGNALFire = "res://Assets/World/Buildings/SignalFire/SignalFire.tscn";
	public const string SIGNALFireWooden = "res://Assets/World/Buildings/SignalFire/SignalFire.tscn";
	
	// Tier 1 (Sailors) Resources
	Texture SIGNALFireIdle45 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_45.png");
	Texture SIGNALFireIdle135 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_135.png");
	Texture SIGNALFireIdle315 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_225.png");
	Texture SIGNALFireIdle225 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_315.png");
	
	// Tier 2 (Pioneers) Resources
	Texture SIGNALFireWoodenIdle45 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_45.png");
	Texture SIGNALFireWoodenIdle135 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_135.png");
	Texture SIGNALFireWoodenIdle315 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_225.png");
	Texture SIGNALFireWoodenIdle225 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_315.png");
	
	// Tier 3 (Settlers) Resources
	Texture SIGNALFireClinkerIdle45 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_45.png");
	Texture SIGNALFireClinkerIdle135 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_135.png");
	Texture SIGNALFireClinkerIdle315 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_225.png");
	Texture SIGNALFireClinkerIdle225 = GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_315.png");
	
	// Tier 1 (Sailors) Sprites
	public static readonly Array SIGNALFireIdleAnim = new Array(){
		SIGNALFireIdle45,
		SIGNALFireIdle135,
		SIGNALFireIdle225,
		SIGNALFireIdle315,
	};
	
	// Tier 2 (Pioneers) Sprites
	public static readonly Array SIGNALFireWoodenIdleAnim = new Array(){
		SIGNALFireWoodenIdle45,
		SIGNALFireWoodenIdle135,
		SIGNALFireWoodenIdle225,
		SIGNALFireWoodenIdle315,
	};
	
	// Tier 3 (Settlers) Sprites
	public static readonly Array SIGNALFireClinkerIdleAnim = new Array(){
		SIGNALFireClinkerIdle45,
		SIGNALFireClinkerIdle135,
		SIGNALFireClinkerIdle225,
		SIGNALFireClinkerIdle315,
	};
	
	public static readonly Array TIERS = new Array(){
		SIGNALFireIdleAnim,
		SIGNALFireWoodenIdleAnim,
		SIGNALFireClinkerIdleAnim,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	
	public void _Ready()
	{  
		action = "idle";
	
	}
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = TIERS[tier];
				texture = TIERS[tier][rotationOffset];
	
				switch( tier)
				{
					case 0:
						_billboard.Vframes = 2;
						_billboard.Hframes = 5;
						_billboard.RegionRect = new Rect2(0}, 0, 320, 256);
						_billboard.RegionEnabled = true;
						break;
					case 1:
						_billboard.Vframes = 4;
						_billboard.Hframes = 4;
						_billboard.RegionRect = new Rect2(0, 0, 256, 512);
						_billboard.RegionEnabled = true;
						break;
					case 2:
						_billboard.Vframes = 4;
						_billboard.Hframes = 4;
						_billboard.RegionRect = new Rect2(0, 0, 256, 512);
						_billboard.RegionEnabled = true;
	
						break;
				}
				_billboard.Frame = NextFrame();
	
		}
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