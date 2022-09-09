using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class HelpUI : Control
{
    public Spatial parent = null;

    //onready var pageControl = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/PageControl
    Control pageControl;

    public void _Ready()
    {
        pageControl = FindNode("PageControl") as Control;
        pageControl.Visible = true;
        pageControl.GetNode<Button>("PrevButton").Disabled = true;
        pageControl.GetNode<Button>("NextButton").Disabled = true;
    }

    public void _OnRichTextLabelMetaClicked(string meta)
    {
        GD.Print(meta);
        OS.ShellOpen(meta);
    }

    public void _OnOKButtonPressed()
    {
        if (parent != null)
        {
            parent.Visible = true;
        }

        QueueFree();
    }
}