
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class TradeSlot : InventorySlot
{
	 
	public const var NONETexture = GD.Load("res://Assets/UI/Icons/Resources/none_gray.png");
	
	onready var vSlider  = $VSlider
	
	public async void UpdateDisplay()
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		base.UpdateDisplay()
	
		if(!label.visible && !texture_rect2.visible)
		{
			textureRect.texture = NONETexture;
			textureRect.Show();
			vSlider.Hide();
	
		}
		else
		{
			textureRect.Show();
			label.Show();
			textureRect2.Show();
			vSlider.Show();
	
		}
	}
	
	public void _OnReady()
	{  
		if(vSlider == null)
			 vSlider = $VSlider
	
	
	}
	
	
	
}