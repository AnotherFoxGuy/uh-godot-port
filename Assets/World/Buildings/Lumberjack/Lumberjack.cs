
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Lumberjack : Building
{
	 
	// Tiers
	public const string LUMBERJACKTent = "res://Assets/World/Buildings/Lumberjack/Lumberjack.tscn";
	public const string LUMBERJACKHut = "res://Assets/World/Buildings/Lumberjack/Lumberjack.tscn";
	
	// Tier 1 (Sailors) Resources
	public const var LUMBERJACKTentIdle = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle.png");
	public const var LUMBERJACKTentIdleLogs01 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_01.png");
	public const var LUMBERJACKTentIdleLogs02 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_02.png");
	public const var LUMBERJACKTentIdleLogs03 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_03.png");
	public const var LUMBERJACKTentIdleLogs04 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_04.png");
	public const var LUMBERJACKTentIdleLogs05 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_05.png");
	
	// Tier 2 (Pioneers) Resources
	public const var LUMBERJACKHutIdle = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_idle.png");
	public const var LUMBERJACKHutIdleLogs01 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_01.png");
	public const var LUMBERJACKHutIdleLogs02 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_02.png");
	public const var LUMBERJACKHutIdleLogs03 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_03.png");
	public const var LUMBERJACKHutIdleLogs04 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_04.png");
	public const var LUMBERJACKHutIdleLogs05 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_05.png");
	
	public const var LUMBERJACKHutIdlePlanks01 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_01.png");
	public const var LUMBERJACKHutIdlePlanks02 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_02.png");
	public const var LUMBERJACKHutIdlePlanks03 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_03.png");
	public const var LUMBERJACKHutIdlePlanks04 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_04.png");
	public const var LUMBERJACKHutIdlePlanks05 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_05.png");
	public const var LUMBERJACKHutIdlePlanks06 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_06.png");
	public const var LUMBERJACKHutIdlePlanks07 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_07.png");
	public const var LUMBERJACKHutIdlePlanks08 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_08.png");
	public const var LUMBERJACKHutIdlePlanks09 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_09.png");
	public const var LUMBERJACKHutIdlePlanks10 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_10.png");
	public const var LUMBERJACKHutIdlePlanks11 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_11.png");
	public const var LUMBERJACKHutIdlePlanks12 = GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_12.png");
	
	// Tier 1 (Sailors) Sprites
	public static readonly Array LUMBERJACKTentIdleLogs = new Array(){
		LUMBERJACKTentIdle,
		LUMBERJACKTentIdleLogs01,
		LUMBERJACKTentIdleLogs02,
		LUMBERJACKTentIdleLogs03,
		LUMBERJACKTentIdleLogs04,
		LUMBERJACKTentIdleLogs05,
	};
	
	//const LUMBERJACKTentWorkAnim = new Array(){
	//	LUMBERJACKTentWork45,
	//	LUMBERJACKTentWork135,
	//	LUMBERJACKTentWork225,
	//	LUMBERJACKTentWork315,
	//};
	
	//const LUMBERJACKTentBurnAnim = new Array(){
	//	LUMBERJACKTentBurn45,
	//	LUMBERJACKTentBurn135,
	//	LUMBERJACKTentBurn225,
	//	LUMBERJACKTentBurn315,
	//};
	
	// Tier 2 (Pioneers) Sprites Logs
	public static readonly Array LUMBERJACKHutIdleLogs = new Array(){
		LUMBERJACKHutIdleLogs01,
		LUMBERJACKHutIdleLogs02,
		LUMBERJACKHutIdleLogs03,
		LUMBERJACKHutIdleLogs04,
		LUMBERJACKHutIdleLogs05,
	};
	
	// Tier 2 (Pioneers) Sprites Planks
	public static readonly Array LUMBERJACKHutIdlePlanks = new Array(){
		LUMBERJACKHutIdlePlanks01,
		LUMBERJACKHutIdlePlanks02,
		LUMBERJACKHutIdlePlanks03,
		LUMBERJACKHutIdlePlanks04,
		LUMBERJACKHutIdlePlanks05,
		LUMBERJACKHutIdlePlanks06,
		LUMBERJACKHutIdlePlanks07,
		LUMBERJACKHutIdlePlanks08,
		LUMBERJACKHutIdlePlanks09,
		LUMBERJACKHutIdlePlanks10,
		LUMBERJACKHutIdlePlanks11,
		LUMBERJACKHutIdlePlanks12,
	};
	
	public static readonly Array TIERS = new Array(){
		LUMBERJACKTentIdle,
		LUMBERJACKHutIdle,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	[Export(0, 5)]  public int resourceAmount  = 0 {set{SetResourceAmount(value);}}
	[Export(0, 12)]  public int resourceAmountOutput  = 0 {set{SetResourceAmountOutput(value);}}
	
	onready var resourceOverlay  = GetNodeOrNull("Billboard/ResourceOverlay");
	onready var resourceOverlay2  = GetNodeOrNull("Billboard/ResourceOverlay2");
	
	public void _Ready()
	{  
		SetRotationDegree(rotationDegree);
		SetResourceAmount(resourceAmount);
		SetResourceAmountOutput(resourceAmountOutput);
	
	}
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				switch( tier)
				{
					case 0:
						self.texture = !texture in LUMBERJACKTentIdleLogs ? TIERS[0] : texture
						_billboard.vframes = 2;
						_billboard.hframes = 2;
						_billboard.region_rect = new Rect2(0}, 0, 256, 256);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 32);
						break;
					case 1:
						self.texture = TIERS[tier];
						_billboard.vframes = 2;
						_billboard.hframes = 2;
						_billboard.region_rect = new Rect2(0, 0, 256, 256);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 32);
	
						break;
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
	
	public void SetResourceAmount(int newResourceAmount)
	{  
		resourceAmount = newResourceAmount;
	
		if(!is_inside_tree())
		{
			return;
	
		}
		if(tier == 0)
		{
			self.texture = LUMBERJACKTentIdleLogs[resourceAmount];
		}
		else
		{
			self.texture = LUMBERJACKHutIdle;
			resourceOverlay.texture = resourceAmount > 0 ? LUMBERJACKHutIdleLogs[Mathf.Clamp(resourceAmount - 1, 0, LUMBERJACKHutIdleLogs.Size() - 1)] : null
	
		}
	}
	
	public void SetResourceAmountOutput(__TYPE newResourceAmountOutput)
	{  
		resourceAmountOutput = newResourceAmountOutput;
	
		if(!is_inside_tree())
		{
			return;
	
		}
		if(tier == 1)
		{
			self.texture = LUMBERJACKHutIdle;
			resourceOverlay2.texture = resourceAmountOutput > 0 ? LUMBERJACKHutIdlePlanks[Mathf.Clamp(resourceAmountOutput - 1, 0, LUMBERJACKHutIdlePlanks.Size() - 1)] : null
	
		}
	}
	
	public void AddResource()
	{  
		pass ;// TODO
	
	}
	
	public void RemoveResource()
	{  
		pass ;// TODO
	
	}
	
	public void _OnInput(InputEvent event)
	{  
		base._OnInput(event)
	
		if(null in [resourceOverlay, resourceOverlay2])
			 return;
	
		// Switch frame accordingly with the world rotation.
		if(event.IsActionPressed("rotate_left"))
		{
			resourceOverlay.frame = Mathf.Wrap(resourceOverlay.frame - 1, 0,
					resourceOverlay.hframes * resourceOverlay.vframes);
			resourceOverlay2.frame = Mathf.Wrap(resourceOverlay2.frame - 1, 0,
					resourceOverlay2.hframes * resourceOverlay2.vframes);
		}
		else if(event.IsActionPressed("rotate_right"))
		{
			resourceOverlay.frame = Mathf.Wrap(resourceOverlay.frame + 1, 0,
					resourceOverlay.hframes * resourceOverlay.vframes);
			resourceOverlay2.frame = Mathf.Wrap(resourceOverlay2.frame + 1, 0,
					resourceOverlay2.hframes * resourceOverlay2.vframes);
	
		}
	}
	
	public void SetRotationDegree(int newRotation)
	{  
		base.SetRotationDegree(newRotation)
	
		if(!is_inside_tree() || resourceOverlay == null)
		{
			return;
	
		}
		resourceOverlay.frame = self.rotation_index;
		resourceOverlay2.frame = self.rotation_index;
	
	
	}
	
	
	
}