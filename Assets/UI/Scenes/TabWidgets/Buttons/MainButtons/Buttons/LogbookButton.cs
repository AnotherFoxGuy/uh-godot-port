using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class LogbookButton : WidgetButton
{
    public void _Pressed()
    {
        Audio.Instance.PlaySnd("flippage");
    }
}