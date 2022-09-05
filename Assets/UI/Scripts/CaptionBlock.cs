
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CaptionBlock : VBoxContainer
{
	 
	Export(String) string text  = "This is a Book Title" {set{SetText(value);}}
	
	onready var caption  = $Caption
	
	public async void SetText(String newText)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
		text = newText;
	
		caption.text = text;
	
	
	}
	
	
	
}