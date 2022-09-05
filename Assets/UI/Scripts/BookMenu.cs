
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class BookMenu : CenterContainer
{
	 
	//signal tabIndexChanged
	
	// warning-ignore:unusedClassVariable
	public __TYPE parent = null;
	
	Export(bool) var hasDeleteButton {set{SetHasDeleteButton(value);}}
	Export(bool) var hasCancelButton {set{SetHasCancelButton(value);}}
	Export(bool) bool hasOkButton  = true {set{SetHasOkButton(value);}}
	
	onready var pages  = $Pages as TabContainer
	
	public void _Ready()
	{  
		var pageControl;
		foreach(var page in pages.GetChildren())
		{
			if(pages.GetTabCount() > 1)
			{
				pageControl = page.FindNode("PageControl");
				pageControl.GetNode("PrevButton").Connect("pressed", this, "_on_PrevButton_pressed");
				pageControl.GetNode("NextButton").Connect("pressed", this, "_on_NextButton_pressed");
	
				pageControl.visible = true;
	
		// warning-ignore:returnValueDiscarded
		//connect("tab_index_changed", this, "_on_Pages_tab_changed")
			}
		}
		pages.Connect("tab_changed", this, "_on_Pages_tab_changed");
	
		// Force-call to determine initial state of page Controls (enabled/disabled)
		pages.EmitSignal("tab_changed", pages.current_tab);
	
	}
	
	public async void SetHasDeleteButton(bool newHasDeleteButton)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		hasDeleteButton = newHasDeleteButton;
	
		string pressedSignal = "pressed";
		string callbackFunction = "_on_DeleteButton_pressed";
	
		foreach(var page in pages.GetChildren())
		{
			var deleteButton = page.FindNode("DeleteButton");
			if(!delete_button.IsConnected(pressedSignal, this, callbackFunction))
			{
				// warning-ignore:returnValueDiscarded
				deleteButton.Connect(pressedSignal, this, callbackFunction);
			}
			deleteButton.visible = hasDeleteButton;
	
		}
	}
	
	public async void SetHasCancelButton(bool newHasCancelButton)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		hasCancelButton = newHasCancelButton;
	
		string pressedSignal = "pressed";
		string callbackFunction = "_on_CancelButton_pressed";
	
		foreach(var page in pages.GetChildren())
		{
			// Place CancelButton on
			//	left side for one-paged menus
			//	right side for multi-paged menus
			var cancelButton;
			if(pages.GetChildCount() > 1)
			{
				cancelButton = page.FindNode("RightPage").FindNode("CancelButton");
			}
			else
			{
				cancelButton = page.FindNode("CancelButton");
			}
			if(!cancel_button.IsConnected(pressedSignal, this, callbackFunction))
			{
				// warning-ignore:returnValueDiscarded
				cancelButton.Connect(pressedSignal, this, callbackFunction);
			}
			cancelButton.visible = hasCancelButton;
	
	
		}
	}
	
	public async void SetHasOkButton(bool newHasOkButton)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		hasOkButton = newHasOkButton;
	
		string pressedSignal = "pressed";
		string callbackFunction = "_on_OKButton_pressed";
	
		foreach(var page in pages.GetChildren())
		{
			var okButton = page.FindNode("OKButton");
			if(!ok_button.IsConnected(pressedSignal, this, callbackFunction))
			{
				// warning-ignore:returnValueDiscarded
				okButton.Connect("pressed", this, "_on_OKButton_pressed");
			}
			okButton.visible = hasOkButton;
	
		}
	}
	
	public void _OnPrevButtonPressed()
	{  
		//prints("_on_PrevButton_pressed", "current_tab:", pages.current_tab)
		Audio.PlaySndClick();
	
		pages.current_tab -= 1;
		//emit_signal("tab_index_changed")
		pages.EmitSignal("tab_changed", pages.current_tab);
	
	}
	
	public void _OnNextButtonPressed()
	{  
		//prints("_on_NextButton_pressed", "current_tab:", pages.current_tab)
		Audio.PlaySndClick();
	
		pages.current_tab += 1;
		//emit_signal("tab_index_changed")
		pages.EmitSignal("tab_changed", pages.current_tab);
	
	}
	
	public void _OnPagesTabChanged(int tab)
	{  
		//var tabCount = pages.GetTabCount();
		//var currentTab = pages.current_tab;
		var currentTabControl = pages.GetCurrentTabControl();
		var currentPageControl = currentTabControl.FindNode("PageControl");
	
	//	if pages.GetTabCount() <= 1:
	//		pageControl.GetNode("PrevButton").disabled = true;
	//		pageControl.GetNode("NextButton").disabled = true;
		currentPageControl.GetNode("PrevButton").disabled = true;
		currentPageControl.GetNode("NextButton").disabled = true;
		if(pages.GetTabCount() > 1)
		{
			if(0 < tab)
			{
				currentPageControl.GetNode("PrevButton").disabled = false;
			}
			if(tab < pages.GetTabCount() - 1)
			{
				currentPageControl.GetNode("NextButton").disabled = false;
	
			}
		}
	}
	
	public void _OnDeleteButtonPressed()
	{  
		//print("_on_DeleteButton_pressed")
		Audio.PlaySndClick();
	
	}
	
	public void _OnCancelButtonPressed()
	{  
		//print("_on_CancelButton_pressed")
		Audio.PlaySndClick();
	
		if(parent != null)
		{
			parent.visible = true;
		}
		QueueFree();
	
	}
	
	public void _OnOKButtonPressed()
	{  
		//print("_on_OKButton_pressed")
		Audio.PlaySndClick();
	
		if(parent != null)
		{
			parent.visible = true;
		}
		QueueFree();
	
	}
	
	public void _OnReady()
	{  
		if(!pages)
			 pages = $Pages
	
	
	}
	
	
	
}