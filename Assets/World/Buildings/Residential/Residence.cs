
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Residence : Building
{
	 
	// Tiers
	public const string RESIDENTIALTent = "res://Assets/World/Buildings/Residential/Residence.tscn";
	public const string RESIDENTIALHut = "res://Assets/World/Buildings/Residential/Residence.tscn";
	public const string RESIDENTIALHouseTimberFramed = "res://Assets/World/Buildings/Residential/Residence.tscn";
	public const string RESIDENTIALStoneHouse = "res://Assets/World/Buildings/Residential/Residence.tscn";
	
	// Tier 1 (Sailors) Resources
	public const var RESIDENTIALTent1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent1_idle.png");
	
	public const var RESIDENTIALTent2Idle45 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_45.png");
	public const var RESIDENTIALTent2Idle135 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_135.png");
	public const var RESIDENTIALTent2Idle225 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_225.png");
	public const var RESIDENTIALTent2Idle315 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_315.png");
	
	public const var RESIDENTIALTent3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent3_idle.png");
	public const var RESIDENTIALTent4Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent4_idle.png");
	public const var RESIDENTIALTent5Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent5_idle.png");
	public const var RESIDENTIALTent6Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent6_idle.png");
	
	public const var RESIDENTIALTentRuined = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent_ruined.png");
	
	// Tier 2 (Pioneers) Resources
	public const var RESIDENTIALHut1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut1_idle.png");
	public const var RESIDENTIALHut2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut2_idle.png");
	public const var RESIDENTIALHut3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut3_idle.png");
	
	// Tier 3 (Settlers) Resources
	public const var RESIDENTIALHouseTimberFramed1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed1_idle.png");
	public const var RESIDENTIALHouseTimberFramed2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed2_idle.png");
	public const var RESIDENTIALHouseTimberFramed3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed3_idle.png");
	
	// Tier 4 (Citizens) Resources
	public const var RESIDENTIALStoneHouse1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse1_idle.png");
	public const var RESIDENTIALStoneHouse2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse2_idle.png");
	public const var RESIDENTIALStoneHouse3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse3_idle.png");
	public const var RESIDENTIALStoneHouse4Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse4_idle.png");
	
	// Tier 1 (Sailors) Sprites
	public static readonly Array RESIDENTIALTent2IdleAnim = new Array(){
		RESIDENTIALTent2Idle45,
		RESIDENTIALTent2Idle135,
		RESIDENTIALTent2Idle225,
		RESIDENTIALTent2Idle315,
	};
	
	public static readonly Array RESIDENTIALTentIdle = new Array(){
		RESIDENTIALTent1Idle,
		RESIDENTIALTent2IdleAnim, // 2nd tent is animated, treat differently
		RESIDENTIALTent3Idle,
		RESIDENTIALTent4Idle,
		RESIDENTIALTent5Idle,
		RESIDENTIALTent6Idle,
	};
	
	// Tier 2 (Pioneers) Sprites
	public static readonly Array RESIDENTIALHutIdle = new Array(){
		RESIDENTIALHut1Idle,
		RESIDENTIALHut2Idle,
		RESIDENTIALHut3Idle,
	};
	
	// Tier 3 (Settlers) Sprites
	public static readonly Array RESIDENTIALHouseTimberFramedIdle = new Array(){
		RESIDENTIALHouseTimberFramed1Idle,
		RESIDENTIALHouseTimberFramed2Idle,
		RESIDENTIALHouseTimberFramed3Idle,
	};
	
	// Tier 4 (Citizens) Sprites
	public static readonly Array RESIDENTIALStoneHouseIdle = new Array(){
		RESIDENTIALStoneHouse1Idle,
		RESIDENTIALStoneHouse2Idle,
		RESIDENTIALStoneHouse3Idle,
		RESIDENTIALStoneHouse4Idle,
	};
	
	public static readonly Array TIERS = new Array(){
		RESIDENTIALTentIdle,
		RESIDENTIALHutIdle,
		RESIDENTIALHouseTimberFramedIdle,
		RESIDENTIALStoneHouseIdle,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	Export(int) var variation {set{SetVariation(value);}}
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				if(tier == 0 && variation == 1) // the animated tent
				{
					currentAnim = RESIDENTIALTent2IdleAnim;
					self.texture = RESIDENTIALTent2IdleAnim[self.rotation_index];
					_billboard.vframes = 5;
					_billboard.hframes = 5;
					_billboard.region_rect = new Rect2(0, 0, 640, 640);
					_billboard.region_enabled = true;
	
					_billboard.frame = NextFrame();
				}
				else
				{
					currentAnim = null;
					self.texture = TIERS[tier][variation];
					_billboard.vframes = 2;
					_billboard.hframes = 2;
					_billboard.region_enabled = false;
	
				}
		}
	}}
	
	public void Destroy()
	{  
		self.texture = RESIDENTIALTentRuined;
	
	}
	
	public void SetTier(int newTier)
	{  
		var previousTier = tier;
	
		tier = Mathf.Clamp(newTier, 0, TIERS.Size() - 1);
		self.variation = Mathf.Wrap(variation, 0, TIERS[tier].Size());
	
		if(tier > previousTier)
		{
			Upgrade();
		}
		else
		{
			Downgrade();
	
		}
	}
	
	public void SetVariation(int newVariation)
	{  
		variation = Mathf.Wrap(newVariation, 0, TIERS[tier].Size());
	
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