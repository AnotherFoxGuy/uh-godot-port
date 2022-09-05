
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class ColorSelection : HBoxContainer
{
	 
	onready var selectedColor  = $TextureRect/SelectedColor
	onready var choices  = $Choices
	
	public void _Ready()
	{  
		foreach(var choice in choices.GetChildren())
		{
			choice.Connect("gui_input", this, "_on_choice_gui_input", new Array(){choice});
	
			if(choice.color_to_faction == Global.faction)
			{
				selectedColor.color = choice.color;
	
			}
		}
	}
	
	public void _OnChoiceGuiInput(InputEvent event, ColorRect choice)
	{  
		if(event is InputEventMouseButton && event.pressed)
		{
			Audio.PlaySndClick();
			selectedColor.color = choice.color;
	
	//		int i = 1;
	//		for choice in choices.GetChildren():
	//			if selectedColor.color == choice.color:
	//				Global.faction = i;
	//				break
	//			i += 1;
			Global.faction = choice.color_to_faction;
	
	
		}
	}
	
	
	
}