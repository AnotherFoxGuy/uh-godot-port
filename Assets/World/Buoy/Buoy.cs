using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Buoy : WorldThing
{
    public void _RecalculateTranslation(InputEvent ev = null)
    {
        return;
    }
    
    private static readonly Lazy<Buoy> lazy =
        new Lazy<Buoy>(() => new Buoy());

    public static Buoy Instance => lazy.Value;
}