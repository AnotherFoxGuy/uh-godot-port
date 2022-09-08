
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PastryShop : Building
{
	 
	Texture PASTRYShopIdle = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_idle.png");
	
	Texture PASTRYShopWork45 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_45.png");
	Texture PASTRYShopWork135 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_135.png");
	Texture PASTRYShopWork225 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_225.png");
	Texture PASTRYShopWork315 = GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_315.png");
	
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
			case "idle":
				currentAnim = null;
				texture = PASTRYShopIdle;
				_billboard.Vframes = 2;
				_billboard.Hframes = 2;
				_billboard.RegionEnabled = false
	
			case "work":
				currentAnim = PASTRYShopWorkAnim;
				texture = PASTRYShopWorkAnim[rotationIndex];
				_billboard.Vframes = 4;
				_billboard.Hframes = 4;
				_billboard.RegionEnabled = false;
	
				_billboard.Frame = NextFrame();
	
		}
		base.Animate()
	
	
	}}}
	
	
	
}