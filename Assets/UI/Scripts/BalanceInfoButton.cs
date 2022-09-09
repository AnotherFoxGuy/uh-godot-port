using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BalanceInfoButton : VBoxContainer
{
    [Export]
    private bool showDetails
    {
        set { SetShowDetails(value); }
        get => _showDetails;
    }

    private bool _showDetails;

    private TextureRect details; //$VBoxContainer/Details

    public void _Process(float _delta)
    {
        if (Engine.IsEditorHint())
        {
            if (details == null)
                details = GetNode<TextureRect>("VBoxContainer/Details");
        }
        else
        {
            SetProcess(false);
        }

        showDetails = details.Visible;
    }

    public void SetShowDetails(bool newShowDetails)
    {
        if (details == null)
            return;

        _showDetails = newShowDetails;
        details.Visible = _showDetails;
    }

    public void _OnTextureButtonPressed()
    {
        _showDetails = !_showDetails;
    }
}