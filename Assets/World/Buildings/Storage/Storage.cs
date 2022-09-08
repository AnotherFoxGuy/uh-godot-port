
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Storage : Building
{
	 
	// Tier 1 (Sailors) Resources
	Texture STORAGETentIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageTent_idle.png");
	
	// Tier 2 (Pioneers) Resources
	Texture STORAGEHutIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageHut_idle.png");
	
	public static readonly Array TIERS = new Array(){
		STORAGETentIdle,
		STORAGEHutIdle,
	};
	
	[Export(0, 4)]  int tier {set{SetTier(value);}}
	
	public void Animate()
	{  
		switch( action)
		{
			case "idle":
				currentAnim = null;
				texture = TIERS[tier];
				switch( tier)
				{
					case 0:
						_billboard.Vframes = 2;
						_billboard.Hframes = 2;
						_billboard.RegionRect = new Rect2(0}, 0, 256, 192);
						_billboard.RegionEnabled = true;
						_billboard.offset = new Vector2(0, 16);
						break;
					case 1:
						_billboard.Vframes = 2;
						_billboard.Hframes = 2;
						_billboard.RegionRect = new Rect2(0, 0, 256, 256);
						_billboard.RegionEnabled = true;
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
	
	
	
}