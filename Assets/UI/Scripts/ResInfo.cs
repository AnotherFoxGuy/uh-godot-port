
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ResInfo : TextureRect
{
	 
	public const var Global = GD.Load("res://Assets/World/Global.gd");
	
	Export(Global.ResourceType) var resourceType {set{SetResourceType(value);}}
	Export(int) var resourceValue {set{SetResourceValue(value);}}
	
	onready var textureRect = $VBoxContainer/TextureRect
	onready var label = $VBoxContainer/Label
	
	public async void SetResourceType(int newResourceType)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		resourceType = Mathf.Wrap(newResourceType, 0, Global.RESOURCE_TYPES.Size());
		textureRect.texture = Global.RESOURCE_TYPES[resourceType];
	
	}
	
	public async void SetResourceValue(int newResourceValue)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		resourceValue = newResourceValue;
		label.text = GD.Str(resourceValue);
	
	}
	
	public void _OnReady()
	{  
		if(!texture_rect)
			 textureRect = $VBoxContainer/TextureRect
		if(!label)
			 label = $VBoxContainer/Label
	
	
	}
	
	
	
}