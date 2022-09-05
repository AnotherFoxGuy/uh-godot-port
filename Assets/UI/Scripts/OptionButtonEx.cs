
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class OptionButtonEx : HBoxContainer
{
	 
	// OptionButton with a descriptive Label component
	
	[Signal] delegate void ItemFocused(index);// int
	[Signal] delegate void ItemSelected(index);// int
	
	Export(String) string description  = "Descriptive Label:" {set{SetDescription(value);}}
	[Export(String)]  Array options {set{SetOptions(value);}}
	Export(int) int selected  = -1 {set{SetSelected(value);}}
	
	[Export("Left", "Center", "Right")]  public String alignStyle  = "Left" {set{SetAlignStyle(value);}}
	
	onready var descriptionNode  = $LabelEx
	onready var optionButtonNode  = $OptionButton
	
	public async void SetDescription(String newDescription)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		description = newDescription;
	
		descriptionNode.text = description;
	
	}
	
	public async void SetOptions(Array newOptions)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		options = newOptions;
	
		//prints("Set options:", options)
		optionButtonNode.Clear();
		foreach(var option in options)
		{
			optionButtonNode.AddItem(option);
	
		// Reassign in case the size has Changed (e.g. reduce index if invalid now)
		}
		self.selected = selected;
	
		PropertyListChangedNotify();
	
	}
	
	public async void SetSelected(int newSelected)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		selected = Mathf.Clamp(newSelected, -1, options.Size() - 1) as int;
	
		optionButtonNode.selected = selected;
	
	}
	
	public async void SetAlignStyle(String newAlignStyle)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		alignStyle = newAlignStyle;
	
		switch( alignStyle)
		{
			{"Left",
				MoveChild(optionButtonNode}, descriptionNode.GetIndex() + 1)
				descriptionNode.align = Label.ALIGN_LEFT;
				descriptionNode.visible = true;
				optionButtonNode.align = OptionButton.ALIGN_LEFT
			{"Center",
				descriptionNode.visible = false
			{"Right",
				MoveChild(descriptionNode}}, optionButtonNode.GetIndex() + 1)
				descriptionNode.align = Label.ALIGN_RIGHT;
				descriptionNode.visible = true;
				optionButtonNode.align = OptionButton.ALIGN_RIGHT;
	
		}
	}
	
	public void _OnOptionButtonItemFocused(int index)
	{  
		EmitSignal("item_focused", index);
	
	}
	
	public void _OnOptionButtonItemSelected(int index)
	{  
		selected = index;
		EmitSignal("item_selected", selected);
	
	}
	
	public void _OnReady()
	{  
		if(!description_node)
			 descriptionNode = $LabelEx
		if(!option_button_node)
			 optionButtonNode = $OptionButton
	
	
	}
	
	
	
}