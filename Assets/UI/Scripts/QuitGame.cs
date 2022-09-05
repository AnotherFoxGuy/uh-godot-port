
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class QuitGame : Button
{
	 
	public void _Pressed()
	{  
		// Go back to the main menu.
		//warning-ignore:returnValueDiscarded
		GetTree().ChangeSceneTo(
				GD.Load("res://Assets/UI/Scenes/MainMenuScene.tscn"));
	
	
	}
	
	
	
}