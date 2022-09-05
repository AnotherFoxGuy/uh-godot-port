
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class HelpUI : Control
{
	 
	public __TYPE parent = null;
	
	//onready var pageControl = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/PageControl
	onready var pageControl = FindNode("PageControl");
	
	public void _Ready()
	{  
		pageControl.visible = true;
		pageControl.GetNode("PrevButton").disabled = true;
		pageControl.GetNode("NextButton").disabled = true;
	
	}
	
	public void _OnRichTextLabelMetaClicked(__TYPE meta)
	{  
		GD.Print(meta);
		OS.ShellOpen(meta);
	
	}
	
	public void _OnOKButtonPressed()
	{  
		if(parent != null)
		{
			parent.visible = true;
		}
		QueueFree();
	
	
	}
	
	
	
}