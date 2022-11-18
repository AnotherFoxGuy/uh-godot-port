using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MainMenuUI : Control
{
	private Dictionary<string, PackedScene> _scenes = new Dictionary<string, PackedScene>()
	{
		{ "spGame", GD.Load<PackedScene>("res://Assets/UI/Scenes/NewGameUI/NewGameUI.tscn") },
		{ "loadGame", GD.Load<PackedScene>("res://Assets/World/WorldDev.tscn") },
		{ "help", GD.Load<PackedScene>("res://Assets/UI/Scenes/HelpUI/HelpUI.tscn") },
		{ "options", GD.Load<PackedScene>("res://Assets/UI/Scenes/OptionsUI/OptionsUI.tscn") },
		{ "exit", GD.Load<PackedScene>("res://Assets/UI/Scenes/ExitScene.tscn") }
	};

	public void _Input(InputEvent ev)
	{
		/*if(ev is InputEventKey && ev is InputEventMouseButton)
		{
			return;
	
		// Set the animation mark to the very end, so all final values are still set.
		}*/
		var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer.Seek(animationPlayer.CurrentAnimationLength);

		AcceptEvent(); // Avoid triggering buttons on intro skip.
		SetProcessInput(false);
	}

	public void _GoToScene(String scene)
	{
		Audio.Instance.PlaySndClick();

		if (scene == "sp_game" || scene == "help" || scene == "options")
		{
			var subscene = _scenes[scene].Instance();
			// subscene.GetParent() = this;
			Visible = false;
			GetTree().Root.AddChild(subscene);
		}
		else
		{
			//warning-ignore:returnValueDiscarded
			GetTree().ChangeSceneTo(_scenes[scene]);
		}
	}
}
