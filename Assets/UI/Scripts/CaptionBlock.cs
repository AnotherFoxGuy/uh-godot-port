using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CaptionBlock : VBoxContainer
{
    [Export]
    private string text
    {
        set => SetText(value);
        get => _text;
    }

    private string _text = "This is a Book Title";

    //onready var caption  = $Caption

    public async void SetText(String newText)
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");
        _text = newText;

        // caption.text = text;
    }
}