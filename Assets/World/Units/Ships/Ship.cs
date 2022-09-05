
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Ship : Unit
{
	 
	//warning-ignore-all:unusedClassVariable
	
	// Generic properties
	[Export(250)]  public int maxHealth = 150;
	
	// Navigational properties
	[Export(8)]  public int radius = 5;
	[Export(12)]  public int velocity = 12;
	
	// Storage capacity
	[Export(120)]  public int storageLimit = 120;
	[Export(4)]  public int numOfSlots = 4;
	
	public void _Ready()
	{  
		AddToGroup("units");
		// DEBUG
		$Billboard.vframes = 2;
		$Billboard.hframes = 4;
	
	}
	
	public void _Process(float delta)
	{  
		UpdatePath();
	
		RecalculateDirections();
		AnimateMovement();
		UpdateFactionColor();
	
		if(isMoving)
		{
			Translate(Utils.Map2To3(moveVector.Normalized()) * delta * velocity / 4);
	
		}
	}
	
	public void UpdateFactionColor()
	{  
	
	
	}
	
	
	
}