
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class CloseMenu : Button
{
	 
	private VBoxContainer _parent
	
	public void _Ready()
	{  
		_parent = GetParent();
	
	}
	
	public void _Pressed()
	{  
		_parent.ToggleVisible();
	
	
	}
	
	
	
}