
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SwitchTabWidget : TextureButton
{
	 
	// Base class for all widget switch handles.
	
	[Signal] delegate void TabChanged(tab);// int
	
	Export(Texture) var textureActive;
	onready var _textureNormal  = textureNormal;
	
	onready TabContainer tabContainer {get{return GetTabContainer();}}
	
	//public void _Ready()
	{  
	//	if !Engine.IsEditorHint():
	//		if GetIndex() == 0: # => every other switch node is ready
	//			for sibling in GetParent().GetChildren():
	//				sibling._ListenToOtherSwitches()
	//
	//func _ListenToOtherSwitches() -> void:
	//	for sibling in GetParent().GetChildren():
	//		sibling.Connect("tab_changed", this, "_on_SwitchTabWidget_tab_changed")
	
	}
	
	public void _Draw()
	{  
		if(textureNormal)
		{
			rectMinSize = textureNormal.GetSize();
		}
		else
		{
			rectMinSize = rectSize;
	
		}
		PropertyListChangedNotify();
	
	}
	
	public TabContainer GetTabContainer()
	{  
		if(owner is TabWidget)
		{
			if(tabContainer == null)
			{
				tabContainer = owner.body.GetNode("TabContainer");
	
				foreach(var switch in GetParent().GetChildren())
				{
					tabContainer.Connect("tab_changed", this, "_on_TabContainer_tab_changed");
	
				}
			}
		}
		return tabContainer;
	
	}
	
	public void _Pressed()
	{  
		Audio.PlaySndClick();
	
	}
	
	public void _OnSwitchTabWidgetPressed()
	{  
		if(self.tab_container)
		{
			GD.PrintS("Set page", GetIndex(), "for", owner.name);
			tabContainer.current_tab = GetIndex();
			EmitSignal("tab_changed", tabContainer.current_tab);
	
	//func _OnSwitchTabWidgetTabChanged(tab: int) -> void:
	//	if self.tab_container:
	//		GD.PrintS("Notify", self.name, "about tab change to", tabContainer.current_tab)
	//		if tabContainer.current_tab == GetIndex():
	//			textureNormal = textureActive;
	//		else:
	//			textureNormal = _textureNormal;
	
		}
	}
	
	public void _OnTabContainerTabChanged(int tab)
	{  
		if(tabContainer.current_tab == GetIndex())
		{
			textureNormal = textureActive;
		}
		else
		{
			textureNormal = _textureNormal;
	
	
		}
	}
	
	
	
}