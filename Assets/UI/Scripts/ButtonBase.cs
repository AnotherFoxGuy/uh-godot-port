
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class ButtonBase : TextureButton
{
	 
	public void _OnButtonBasePressed()
	{  
		Audio.PlaySndClick();
	
	
	}
	
	
	
}