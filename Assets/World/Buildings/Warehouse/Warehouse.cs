
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Warehouse : Building
{
	 
	// Tiers
	public const string WAREHOUSE = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
	public const string WAREHOUSEWooden = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
	public const string WAREHOUSETimberFramed = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
	public const string WAREHOUSEStone = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
	
	// Tier 1 (Sailors) Resources
	public const var WAREHOUSEIdle = GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/Warehouse_idle.png");
	
	// Tier 2 (Pioneers) Resources
	public const var WAREHOUSEWoodenIdle = GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseWooden_idle.png");
	
	// Tier 3 (Settlers) Resources
	public const var WAREHOUSETimberFramedIdle = GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseTimberFramed_idle.png");
	
	// Tier 4 (Citizens) Resources
	public const var WAREHOUSEStoneIdle = GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseStone_idle.png");
	
	// Tier 1 (Sailors) Sprites
	// Tier 2 (Pioneers) Sprites
	// Tier 3 (Settlers) Sprites
	// Tier 4 (Citizens) Sprites
	
	public static readonly Array TIERS = new Array(){
		WAREHOUSEIdle,
		WAREHOUSEWoodenIdle,
		WAREHOUSETimberFramedIdle,
		WAREHOUSEStoneIdle,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = TIERS[tier];
				switch( tier)
				{
					case 0:
						_billboard.vframes = 2;
						_billboard.hframes = 2;
						_billboard.region_rect = new Rect2(0}, 0, 384, 256);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 10);
						break;
					case 1, 2, 3:
						_billboard.vframes = 2;
						_billboard.hframes = 2;
						_billboard.region_rect = new Rect2(0, 0, 384, 384);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 40);
	
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
	
	
	
}