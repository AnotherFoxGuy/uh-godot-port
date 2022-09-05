
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class GameTypeButton : HBoxContainer
{
	 
	Export(String) string type = "" {set{SetNewType(value);}}
	
	onready var checkBox  = $CheckBox
	
	public void _Ready()
	{  
		checkBox.text = type;
	
	}
	
	public void _Process(float _delta)
	{  
		if(Engine.IsEditorHint())
		{
			if(checkBox == null)
			{
				GD.PrintS("Please reload the scene [new Dictionary(){0}].".Format(new Array(){name}));
				SetProcess(false);
				return;
			}
			checkBox.text = type;
		}
		else
		{
			SetProcess(false);
	
		}
	}
	
	public void SetNewType(String newType)
	{  
		type = newType;
	
	}
	
	public void _OnPressed()
	{  
		Audio.PlaySndClick();
		foreach(var typeButton in GetParent().GetChildren())
		{
			if(typeButton != this)
			{
				typeButton.GetNode("CheckBox").pressed = false;
	
	
			}
		}
	}
	
	
	
}