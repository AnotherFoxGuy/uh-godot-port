
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CheckBoxEx : HBoxContainer
{
	 
	// CheckBox with a descriptive Label component
	
	[Signal] delegate void Toggled(checkState);// bool
	
	Export(String) string description  = "Unknown CheckBox:" {set{SetDescription(value);}}
	Export(bool) bool checked  = false {set{SetChecked(value);}}
	
	onready var descriptionNode  = $LabelEx
	onready var checkBoxNode  = $CheckBox
	
	//public void _Ready()
	{  
	//	guiInput.rect_size = rectSize;
	
	}
	
	public async void SetDescription(String newDescription)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		description = newDescription;
	
		descriptionNode.text = description;
	
	}
	
	public async void SetChecked(bool newChecked)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		checked = newChecked;
	
		checkBoxNode.pressed = checked;
	
	}
	
	public void _OnCheckBoxToggled(bool checkState)
	{  
		checked = checkState;
	
		EmitSignal("toggled", checked);
	
	}
	
	public void _Notification(int what)
	{  
		switch( what)
		{
			case NOTIFICATIONMouseEnter:
				descriptionNode.AddColorOverride("font_color", descriptionNode.theme.GetColor("font_color_hover", "CheckBox"));
				break;
			case NOTIFICATIONMouseExit:
				descriptionNode.AddColorOverride("font_color", descriptionNode.theme.GetColor("font_color", "CheckBox"));
	
				break;
		}
	}
	
	public void _OnCheckBoxExGuiInput(InputEvent event)
	{  
		if(event is InputEventMouseButton)
		{
			if(event.IsActionReleased("alt_command"))
			{
				//print("Left click on CheckBox")
				Audio.PlaySndClick();
				checkBoxNode.pressed = !check_box_node.pressed;
	
			}
		}
	}
	
	public void _OnReady()
	{  
		if(!description_node)
			 descriptionNode = $LabelEx
		if(!check_box_node)
			 checkBoxNode = $CheckBox
	
	
	}
	
	
	
}