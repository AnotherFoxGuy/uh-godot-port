using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class uLineEdit : LineEdit
{
    // Single-line input field

    public static readonly Dictionary<string, AlignEnum> ALIGN = new Dictionary<string, AlignEnum>()
    {
        { "Left", LineEdit.AlignEnum.Left },
        { "Center", LineEdit.AlignEnum.Center },
        { "Right", LineEdit.AlignEnum.Right }
    };

    [Export]
    public string alignStyle
    {
        set { SetAlignStyle(value); }
    }

    private string _alignStyle = "Center";

    private bool _currentEditable;

    public void _Process(float _delta)
    {
        if (!Engine.IsEditorHint())
        {
            if (_currentEditable != Editable)
            {
                SelectingEnabled = Editable;
                MouseDefaultCursorShape = Editable ? CursorShape.Ibeam : CursorShape.Arrow;

                _currentEditable = Editable;
                PropertyListChangedNotify();
            }
        }
    }

    public void SetAlignStyle(String newAlignStyle)
    {
        _alignStyle = newAlignStyle;

        // Text alignment
        Align = ALIGN[_alignStyle];
        //	AddStyleboxOverride( # StyleBox alignment
        //			"normal",
        //			theme.GetStylebox(
        //				"normal_" + alignStyle.ToLower() if alignStyle != "Center"
        //				else
        //				"normal",
        //					"LineEdit"))

        // StyleBox alignment
        _ApplyStyle("focus");
        _ApplyStyle("normal");
        _ApplyStyle("read_only");

        PropertyListChangedNotify();
    }

    public void _ApplyStyle(String name)
    {
        AddStyleboxOverride(
            name,
            Theme.GetStylebox(name, "LineEdit"));
    }
}