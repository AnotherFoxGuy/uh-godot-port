using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class GameTypeButtons : VBoxContainer
{
    public void _Ready()
    {
        GetChild(2).GetNode<CheckBox>("CheckBox").Pressed = true;
    }
}