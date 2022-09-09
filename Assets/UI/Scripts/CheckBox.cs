using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class CCheckBox : CheckBox
{
    public void _OnCheckBoxToggled(bool _buttonPressed)
    {
        if (HasFocus())
        {
            Audio.Instance.PlaySndClick();
        }
    }
}