
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class InventorySlot : TextureButton
{
	 
	public const var Global = GD.Load("res://Assets/World/Global.gd");
	
	Export(bool) bool showIfEmpty  = true;
	Export(Global.ResourceType) var resourceType {set{SetResourceType(value);}}
	Export(int) var resourceValue {set{SetResourceValue(value);}}
	
	// TODO: Make dependent from currently selected ship
	Export(int) int storageLimit  = 30 {set{SetStorageLimit(value);}}
	
	onready var textureRect = $TextureRect
	onready var label = $Label
	onready var textureRect2 = $TextureRect2
	
	public void _Ready()
	{  
		textureRect2.rect_pivot_offset = textureRect2.rect_size;
	
		UpdateDisplay();
	
	}
	
	public void _Draw()
	{  
		UpdateDisplay();
	
	}
	
	public void UpdateDisplay()
	{  
		if resourceType != Global.ResourceType.NONE && showIfEmpty || \
			resourceType != Global.ResourceType.NONE && resourceValue > 0:
			SetSlotStatus(true);
		else
		{
			SetSlotStatus(false);
	
		}
	}
	
	public void SetSlotStatus(bool active)
	{  
		Dictionary status = new Dictionary(){
			true: "show",
			false: "hide"
		}.Get(active);
	
		textureRect.Call(status);
		label.Call(status);
		textureRect2.Call(status);
	
	}
	
	public async void SetResourceType(int newResourceType)
	{  
		//prints("new_resource_type:", newResourceType)
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		resourceType = Mathf.Wrap(newResourceType, 0, Global.RESOURCE_TYPES.Size());
	
		textureRect.texture = Global.RESOURCE_TYPES[resourceType];
	
		_Draw();
	
	}
	
	public async void SetResourceValue(int newResourceValue)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		resourceValue = Mathf.Clamp(newResourceValue, 0, storageLimit) as int;
	
		label.text = GD.Str(resourceValue);
		UpdateAmountBar();
	
		_Draw();
	
	}
	
	public async void SetStorageLimit(int newStorageLimit)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		storageLimit = Mathf.Clamp(newStorageLimit, 0, newStorageLimit) as int;
	
		// Always keep resourceValue within the storageLimit
		self.resource_value = Mathf.Clamp(resourceValue, 0, storageLimit) as int;
		PropertyListChangedNotify();
	
		UpdateAmountBar();
	
	}
	
	public async void UpdateAmountBar()
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		var scaleFactor  = Mathf.Stepify(1.0 / storageLimit * resourceValue, 0.01) as float;
		textureRect2.rect_scale.y = scaleFactor;
	
	}
	
	public void _OnReady()
	{  
		if(!texture_rect)
			 textureRect = $TextureRect
		if(!label)
			 label = $Label
		if(!texture_rect2)
			 textureRect2 = $TextureRect2
	
	
	}
	
	
	
}