using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SwitchTabWidget : TextureButton
{
    // Base class for all widget switch handles.

    [Signal]
    delegate void TabChanged(int tab); // int

    [Export] Texture textureActive;
    Texture _textureNormal;

    TabContainer tabContainer => GetTabContainer();
    TabContainer _tabContainer;

    public void _Ready()
    {
        _textureNormal = TextureNormal;
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
        if (TextureNormal != null)
        {
            RectMinSize = TextureNormal.GetSize();
        }
        else
        {
            RectMinSize = RectSize;
        }

        PropertyListChangedNotify();
    }

    public TabContainer GetTabContainer()
    {
        if (Owner is TabWidget)
        {
            if (_tabContainer == null)
            {
                _tabContainer = Owner.GetNode("TabContainer") as TabContainer;

                foreach (var sw in GetParent().GetChildren())
                {
                    _tabContainer.Connect("tab_changed", this, "_on_TabContainer_tab_changed");
                }
            }
        }

        return _tabContainer;
    }

    public void _Pressed()
    {
        Audio.Instance.PlaySndClick();
    }

    public void _OnSwitchTabWidgetPressed()
    {
        if (_tabContainer != null)
        {
            GD.PrintS("Set page", GetIndex(), "for", Owner.Name);
            tabContainer.CurrentTab = GetIndex();
            EmitSignal("tab_changed", tabContainer.CurrentTab);

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
        if (tabContainer.CurrentTab == GetIndex())
        {
            TextureNormal = textureActive;
        }
        else
        {
            TextureNormal = _textureNormal;
        }
    }
}