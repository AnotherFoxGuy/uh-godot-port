
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MainMenuUI : Control
{
	 
	private Dictionary _scenes = new Dictionary(){
		spGame = GD.Load("res://Assets/UI/Scenes/NewGameUI/NewGameUI.tscn"),
		loadGame = GD.Load("res://Assets/World/WorldDev.tscn"),
		help = GD.Load("res://Assets/UI/Scenes/HelpUI/HelpUI.tscn"),
		options = GD.Load("res://Assets/UI/Scenes/OptionsUI/OptionsUI.tscn"),
		exit = GD.Load("res://Assets/UI/Scenes/ExitScene.tscn");
	};
	
	public void _Input(InputEvent event)
	{  
		if(!event is InputEventKey && !event is InputEventMouseButton)
		{
			return;
	
		// Set the animation mark to the very end, so all final values are still set.
		}
		var animationPlayer  = $AnimationPlayer as AnimationPlayer
		animationPlayer.Seek(animationPlayer.current_animation_length);
	
		AcceptEvent() ;// Avoid triggering buttons on intro skip.
		SetProcessInput(false);
	
	}
	
	public void _GoToScene(String scene)
	{  
		Audio.PlaySndClick();
	
		if(scene == "sp_game" || scene == "help" || scene == "options")
		{
			var subscene = _scenes[scene].Instance();
			subscene.parent = this;
			visible = false;
			GetTree().GetRoot().AddChild(subscene);
		}
		else
		{
			//warning-ignore:returnValueDiscarded
			GetTree().ChangeSceneTo(_scenes[scene]);
	
	
		}
	}
	
	
	
}