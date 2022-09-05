
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class LineEditEx : HBoxContainer
{
	 
	// LineEdit with a descriptive Label component
	
	public signal textChangeRejected
	[Signal] delegate void TextChanged(newText);// String
	[Signal] delegate void TextEntered(newText);// String
	
	Export(String) string description  = "Descriptive Label:" {set{SetDescription(value);}}
	Export(String) string text  = "Example Text" {set{SetText(value);}}
	
	[Export("Left", "Center", "Right")]  public String alignStyle  = "Left" {set{SetAlignStyle(value);}}
	
	//export(NodePath) var descriptionNodePath {set{SetDescriptionNodePath(value);}}
	//export(NodePath) var inputNodePath {set{SetInputNodePath(value);}}
	//onready var descriptionNode = GetNode(descriptionNodePath);
	//onready var inputNode = GetNode(inputNodePath);
	
	//public void SetDescriptionNodePath(__TYPE newDescriptionNodePath)
	{  
	//	descriptionNodePath = newDescriptionNodePath;
	//	descriptionNode = GetNode(descriptionNodePath);
	
	//func SetInputNodePath(newInputNodePath):
	//	inputNodePath = newInputNodePath;
	//	inputNode = GetNode(inputNodePath);
	
	}
	
	onready var descriptionNode  = $LabelEx
	onready var inputNode  = $LineEdit
	
	public async void SetDescription(String newDescription)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		description = newDescription;
	
		descriptionNode.text = description;
	
	}
	
	public async void SetText(String newText)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		text = newText;
	
		inputNode.text = text;
	
	}
	
	public async void SetAlignStyle(String newAlignStyle)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		alignStyle = newAlignStyle;
	
		switch( alignStyle)
		{
			{"Left",
				MoveChild(inputNode}, descriptionNode.GetIndex() + 1)
				descriptionNode.align = Label.ALIGN_LEFT;
				descriptionNode.visible = true
			{"Center",
				descriptionNode.visible = false
			{"Right",
				MoveChild(descriptionNode}}, inputNode.GetIndex() + 1)
				descriptionNode.align = Label.ALIGN_RIGHT;
				descriptionNode.visible = true;
	
		}
		inputNode.align_style = alignStyle;
	
	}
	
	public void _OnLineEditTextChangeRejected()
	{  
		EmitSignal("text_change_rejected");
	
	}
	
	public void _OnLineEditTextChanged(String newText)
	{  
		text = newText;
		EmitSignal("text_changed", text);
	
	}
	
	public void _OnLineEditTextEntered(String newText)
	{  
		text = newText;
		EmitSignal("text_entered", text);
	
	}
	
	public void _OnReady()
	{  
		if(!description_node)
			 descriptionNode = $LabelEx
		if(!input_node)
			 inputNode = $LineEdit
	
	
	}
	
	
	
}