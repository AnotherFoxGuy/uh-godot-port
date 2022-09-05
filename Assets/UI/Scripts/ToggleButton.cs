
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ToggleButton : WidgetButton
{
	 
	// Button that cycles between two states visually.
	//
	// TODO: Clean up && possibly merge into base button class.
	
	Export(Texture) var textureNormalInitial {set{SetTextureNormalInitial(value);}}
	Export(Texture) var texturePressedInitial {set{SetTexturePressedInitial(value);}}
	Export(Texture) var textureHoverInitial {set{SetTextureHoverInitial(value);}}
	Export(Texture) var textureNormalAlternate;
	Export(Texture) var texturePressedAlternate;
	Export(Texture) var textureHoverAlternate;
	
	onready var animatedTexture  = GetNode("AnimatedTexture");
	
	public void _Ready()
	{  
		_SetAnimation();
	
	}
	
	public void _Pressed()
	{  
		Audio.PlaySndClick();
	
	}
	
	public void _Toggled(bool buttonPressed)
	{  
		Dictionary textureVariant = new Dictionary(){
			true: "alternate",
			false: "initial",
		}.Get(buttonPressed);
	
		foreach(var textureType in ["normal", "pressed", "hover"])
		{
			//prints("Set", textureType + "_" + textureVariant, "for", textureType, "_texture")
			Call("set_{0}_texture".Format(new Array(){textureType}),
				Get("texture_{0}_{1}".Format(new Array(){textureType, textureVariant}))
			);
	
		}
		_SetAnimation();
	
	}
	
	public void SetTextureNormalInitial(Texture newTextureNormalInitial)
	{  
		textureNormalInitial = newTextureNormalInitial;
		textureNormal = textureNormalInitial;
	
		PropertyListChangedNotify();
	
	}
	
	public void SetTexturePressedInitial(Texture newTexturePressedInitial)
	{  
		texturePressedInitial = newTexturePressedInitial;
		texturePressed = texturePressedInitial;
	
		PropertyListChangedNotify();
	
	}
	
	public void SetTextureHoverInitial(Texture newTextureHoverInitial)
	{  
		textureHoverInitial = newTextureHoverInitial;
		textureHover = textureHoverInitial;
	
		PropertyListChangedNotify();
	
	}
	
	public void _SetAnimation()
	{  
		if(animatedTexture)
		{
			if(pressed)
			{
				animatedTexture.Hide();
				textureNormal = !pressed ? textureNormalInitial : textureNormalAlternate
			}
			else
			{
				animatedTexture.Show();
				textureNormal = null;
			//prints("animated_texture.visible:", animatedTexture.visible)
	
			}
		}
	}
	
	public void _OnActionButtonGuiInput(InputEvent _event)
	{  
		if(animatedTexture)
		{
			animatedTexture.Hide();
	
	//func _OnActionButtonMouseEntered() -> void:
	//	animatedTexture.Hide()
	
		}
	}
	
	public void _OnActionButtonMouseExited()
	{  
		if(animatedTexture)
		{
			if(!pressed)
			{
				animatedTexture.Show();
	
	
			}
		}
	}
	
	
	
}