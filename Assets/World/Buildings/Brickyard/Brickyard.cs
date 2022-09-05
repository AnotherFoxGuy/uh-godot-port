
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Brickyard : Building
{
	 
	public const var BRICKYARDIdleBricks00 = GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle.png");
	public const var BRICKYARDIdleBricks01 = GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_01.png");
	public const var BRICKYARDIdleBricks02 = GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_02.png");
	public const var BRICKYARDIdleBricks03 = GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_03.png");
	public const var BRICKYARDIdleBricks04 = GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_04.png");
	
	public static readonly Array BRICKYARDIdle = new Array(){
		BRICKYARDIdleBricks00,
		BRICKYARDIdleBricks01,
		BRICKYARDIdleBricks02,
		BRICKYARDIdleBricks03,
		BRICKYARDIdleBricks04
	};
	
	//const BRICKYARDWorkAnim = new Array(){
	//	BRICKYARDWork45,
	//	BRICKYARDWork135,
	//	BRICKYARDWork225,
	//	BRICKYARDWork315,
	//};
	
	//const BRICKYARDBurnAnim = new Array(){
	//	BRICKYARDBurn45,
	//	BRICKYARDBurn135,
	//	BRICKYARDBurn225,
	//	BRICKYARDBurn315,
	//};
	
	[Export(0, 4)]  public int resourceAmount  = 0 {set{SetResourceAmount(value);}}
	
	public void SetResourceAmount(int newResourceAmount)
	{  
		resourceAmount = newResourceAmount;
		self.texture = BRICKYARDIdle[resourceAmount];
	
	
	}
	
	
	
}