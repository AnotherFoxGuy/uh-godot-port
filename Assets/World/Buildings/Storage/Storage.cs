
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Storage : Building
{
	 
	// Tier 1 (Sailors) Resources
	public const var STORAGETentIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageTent_idle.png");
	
	// Tier 2 (Pioneers) Resources
	public const var STORAGEHutIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageHut_idle.png");
	
	public static readonly Array TIERS = new Array(){
		STORAGETentIdle,
		STORAGEHutIdle,
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
						_billboard.region_rect = new Rect2(0}, 0, 256, 192);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 16);
						break;
					case 1:
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
	
	
	
}