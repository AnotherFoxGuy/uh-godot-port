
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class HSlider : HSlider
{
	 
	public void _OnHSliderValueChanged(float _value)
	{  
		if(HasFocus())
		{
			Audio.PlaySndClick();
	
	
		}
	}
	
	
	
}