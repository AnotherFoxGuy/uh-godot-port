
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MainMenuButton : TextureButton
{
	 
	[Export("left", "right", "top", "bottom")]  public String alignment  = "left" {set{SetAlignment(value);}}
	[Export] public string text  = "" {set{SetText(value);}}
	[Export] public Texture texture = GD.Load("res://Assets/UI/Icons/MainMenu/help_bw.png") {set{SetTexture(value);}} // Fallback
	
	public Dictionary alignments = new Dictionary(){
		left = new Vector2(-200, 30),
		right = new Vector2(100, 30),
		top = new Vector2(-50, -35),
		bottom = new Vector2(-50, 100);
	};
	
	public void _Ready()
	{  
		$Panel.rect_position = alignments[alignment];
		$Panel/Label.text = text;
		$Icon.texture = texture;
	
	}
	
	public void SetAlignment(String newAlignment)
	{  
		alignment = newAlignment;
		$Panel.rect_position = alignments[alignment];
	
	}
	
	public void SetText(String newText)
	{  
		text = newText;
		$Panel/Label.text = text;
	
	}
	
	public void SetTexture(Texture newTexture)
	{  
		texture = newTexture;
		$Icon.texture = texture;
	
	
	}
	
	
	
}