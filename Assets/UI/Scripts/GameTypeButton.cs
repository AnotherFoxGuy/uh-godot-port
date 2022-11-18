using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class GameTypeButton : HBoxContainer
{
    [Export]
    string type
    {
        get => _type;
        set => SetNewType(value);
    }

    private string _type;

    // onready var checkBox  = $CheckBox

    private CheckBox checkBox;

    public void _Ready()
    {
        checkBox = GetNode<CheckBox>("CheckBox");
        checkBox.Text = _type;
    }

    public void _Process(float _delta)
    {
        if (Engine.IsEditorHint())
        {
            if (checkBox == null)
            {
                GD.PrintS($"Please reload the scene [new Dictionary(){_type}].");
                SetProcess(false);
                return;
            }

            checkBox.Text = _type;
        }
        else
        {
            SetProcess(false);
        }
    }

    public void SetNewType(String newType)
    {
        _type = newType;
    }

    public void _OnPressed()
    {
        Audio.Instance.PlaySndClick();
        foreach (Node typeButton in GetParent().GetChildren())
        {
            if (typeButton != this)
            {
                typeButton.GetNode<CheckBox>("CheckBox").Pressed = false;
            }
        }
    }
}