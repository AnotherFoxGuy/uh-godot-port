
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Chapel : Building
{
	 
	// Tier 1 (Sailors) Resources
	public const var CHAPELIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/SunSail_idle.png");
	
	// Tier 2 (Pioneers) Resources
	public const var CHAPELWoodenIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/Chapel_idle.png");
	
	// Tier 3 (Settlers) Resources
	public const var CHAPELClinkerIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/ChapelClinker_idle.png");
	
	public static readonly Array TIERS = new Array(){
		CHAPELIdle,
		CHAPELWoodenIdle,
		CHAPELClinkerIdle,
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
						_billboard.region_rect = new Rect2(0}, 0, 256, 256);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 32);
						break;
					case 1:
					case 2:
						_billboard.vframes = 2;
						_billboard.hframes = 2;
						_billboard.region_rect = new Rect2(0, 0, 256, 256);
						_billboard.region_enabled = true;
						_billboard.offset = new Vector2(0, 48);
	
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