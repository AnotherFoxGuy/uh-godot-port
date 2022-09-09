
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class TabWidget : Control
{
	 
	// Base class for all TabWidget objects.
	
	public signal buttonTearPressed
	public signal buttonLogbookPressed
	public signal buttonBuildMenuPressed
	public signal buttonDiplomacyPressed
	public signal buttonGameMenuPressed
	
	onready var body  =
	internal FindNode("Body") as Control;
	
	public async void _Ready()
	{  
		if(owner is PlayerHUD)
		{
			Connect("button_tear_pressed", owner, "_on_TabWidget_button_tear_pressed");
			Connect("button_logbook_pressed", owner, "_on_TabWidget_button_logbook_pressed");
			Connect("button_build_menu_pressed", owner, "_on_TabWidget_button_build_menu_pressed");
			Connect("button_diplomacy_pressed", owner, "_on_TabWidget_button_diplomacy_pressed");
			Connect("button_game_menu_pressed", owner, "_on_TabWidget_button_game_menu_pressed");
	
			// Hide empty detail widget section on runtime
			if(body.GetChild(0).GetChildCount() == 0)
			{
				$WidgetDetail.visible = false;
	
	//	if body.GetChildCount() > 0:
	//		var childContainer = body.GetChild(0) as Control;
			}
		}
		if(body.GetChildCount() > 0)
		{
			foreach(var childContainer in body.GetChildren())
			{
				//prints("Attach signals to", childContainer.name, "of", self.name)
				//child_container.Connect("resized", this, "_on_TabContainer_resized")
				//child_container.Connect("draw", this, "_on_TabContainer_draw")
				childContainer.Connect("sort_children", this, "_on_TabContainer_sort_children");
	
	//func _Process(_delta: float) -> void:
	//	if Engine.IsEditorHint():
	//	_AdaptRectSize()
	
	//func _Draw() -> void:
	//	if !is_inside_tree(): await ToSignal(this, "ready"); _OnReady()
	//
	//	body.rect_size.y = body.rect_min_size.y;
	
			}
		}
	}
	
	public void UpdateData(Dictionary contextData)
	{  
		foreach(var data in contextData)
		{
			GD.PrintS("data:", data) ;// TownName
			var node = FindNode(data);
	
			if(node is Label)
			{
				node.text = contextData[data];
	
			}
		}
	}
	
	public void _AdaptRectSize()
	{  
		if(body != null)
		{
	//		var childContainer = body.GetChild(0) as Control;
	//		if childContainer:
	//			GD.PrintS("Adapt rectMinSize to body content:", childContainer.name)
	//			body.rect_min_size.y = childContainer.rect_size.y;
	
			// Keep the size of one tile visible at all times
			body.rect_min_size.y = body.texture.GetSize().y;
	
			// This will squeeze in all children to their least required sizes
			body.rect_size.y = body.rect_min_size.y;
	
			// Now extend the whole thing based on the biggest child
			if(body.GetChildCount() > 0)
			{
				//print("Adapt rectMinSize to body content consisting of:")
				//prints("Adapt rectMinSize for", self.name)
				foreach(var childContainer in body.GetChildren())
				{
					//print("\t", childContainer.name)
					if(childContainer.rect_size.y > body.rect_min_size.y)
					{
						body.rect_min_size.y = childContainer.rect_size.y;
					}
				}
			}
			else
			{
				GD.PrintS("No body content; set initial rectSize");
	
			// Bug? rectSize should always be >= rectMinSize.
			// Enforce it then.
			}
			body.rect_size.y = body.rect_min_size.y;
	
			var bottomNewPosition = body.rect_position.y + body.rect_size.y - 1;
			body.GetParent().GetChildren()[-1].rect_position.y = bottomNewPosition;
	
	//func _OnTabContainerResized() -> void:
	//	GD.PrintS("resized on", self.name)
	//	_AdaptRectSize()
	//
	//func _OnTabContainerDraw() -> void:
	//	GD.PrintS("Draw call on", self.name)
	//	_AdaptRectSize()
	
		}
	}
	
	public void _OnTabContainerSortChildren()
	{  
		//prints("sort_children on", self.name)
		_AdaptRectSize();
	
	//func _Notification(what: int) -> void:
	//	match what:
	//		NOTIFICATIONParented:
	//			GD.PrintS(this, "has been parented.")
	
	}
	
	public void _OnTearButtonPressed()
	{  
		EmitSignal("button_tear_pressed");
	
	}
	
	public void _OnLogbookButtonPressed()
	{  
		EmitSignal("button_logbook_pressed");
	
	}
	
	public void _OnBuildMenuButtonPressed()
	{  
		EmitSignal("button_build_menu_pressed");
	
	}
	
	public void _OnDiplomacyButtonPressed()
	{  
		EmitSignal("button_diplomacy_pressed");
	
	}
	
	public void _OnGameMenuButtonPressed()
	{  
		EmitSignal("button_game_menu_pressed");
	
	}
	
	public void _OnReady()
	{  
		if(body == null)
			 body = FindNode("Body") as Control;
	
	
	}
	
	
	
}