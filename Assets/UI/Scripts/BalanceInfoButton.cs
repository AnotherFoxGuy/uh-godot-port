
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BalanceInfoButton : VBoxContainer
{
	 
	Export(bool) var showDetails {set{SetShowDetails(value);}}
	
	onready var details = $VBoxContainer/Details
	
	public void _Process(float _delta)
	{  
		if(Engine.IsEditorHint())
		{
			if(details == null)
				 details = $VBoxContainer/Details
		}
		else
		{
			SetProcess(false);
	
		}
		showDetails = details.visible;
	
	}
	
	public void SetShowDetails(bool newShowDetails)
	{  
		if(details == null)
			 return;
	
		showDetails = newShowDetails;
		details.visible = showDetails;
	
	}
	
	public void _OnTextureButtonPressed()
	{  
		self.show_details = !show_details;
	
	
	}
	
	
	
}