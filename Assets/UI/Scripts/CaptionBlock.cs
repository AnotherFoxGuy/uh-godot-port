using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CaptionBlock : VBoxContainer
{
    [Export]
    internal string text
    {
        set => SetText(value);
        get => _text;
    }

    private string _text = "This is a Book Title";

    //onready var caption  = $Caption
    private Label caption;
    
    public void _Ready()
    {
        caption = GetNode<Label>("Caption");
    }

    public async void SetText(String newText)
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");
        _text = newText;

        caption.Text = text;
    }
}