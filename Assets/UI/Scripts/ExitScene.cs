using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class ExitScene : Node
{
    public void _Ready()
    {
        GetTree().Quit();
    }
}