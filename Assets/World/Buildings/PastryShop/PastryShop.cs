
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PastryShop : Building
{
	 
	public const var PASTRYShopIdle = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_idle.png");
	
	public const var PASTRYShopWork45 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_45.png");
	public const var PASTRYShopWork135 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_135.png");
	public const var PASTRYShopWork225 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_225.png");
	public const var PASTRYShopWork315 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_315.png");
	
	public static readonly Array PASTRYShopWorkAnim = new Array(){
		PASTRYShopWork45,
		PASTRYShopWork135,
		PASTRYShopWork225,
		PASTRYShopWork315
	};
	
	public void Animate()
	{  
		switch( action)
		{
			{"idle",
				currentAnim = null;
				self.texture = PASTRYShopIdle;
				_billboard.vframes = 2;
				_billboard.hframes = 2;
				_billboard.region_enabled = false
	
			{"work",
				currentAnim = PASTRYShopWorkAnim;
				self.texture = PASTRYShopWorkAnim[self.rotation_index];
				_billboard.vframes = 4;
				_billboard.hframes = 4;
				_billboard.region_enabled = false;
	
				_billboard.frame = NextFrame();
	
		}
		base.Animate()
	
	
	}}}
	
	
	
}