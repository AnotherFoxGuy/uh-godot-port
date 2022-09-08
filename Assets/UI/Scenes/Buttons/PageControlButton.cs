
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class PageControlButton : ButtonBase
{
	 
	public void _OnButtonBasePressed()
	{  
		Audio.Instance.PlaySnd("flippage");
	
	
	}
	
	
	
}