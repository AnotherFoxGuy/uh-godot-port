using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MainMenuButton : TextureButton
{
    [Export]
    public string alignment
    {
        set { SetAlignment(value); }
    }

    private string _alignment = "left";

    [Export]
    public string text
    {
        set { SetText(value); }
    }

    string _text = "";

    [Export]
    public Texture texture
    {
        set { SetTexture(value); }
    } // Fallback

    private Texture _texture;

    private Panel _panel;

    public Dictionary<string, Vector2> alignments = new Dictionary<string, Vector2>()
    {
        { "left", new Vector2(-200, 30) },
        { "right", new Vector2(100, 30) },
        { "top", new Vector2(-50, -35) },
        { "bottom", new Vector2(-50, 100) },
    };

    public void _Ready()
    {
        _panel = GetNode<Panel>("Panel");
        _texture = GD.Load<Texture>("res://Assets/UI/Icons/MainMenu/help_bw.png");
        _panel.RectPosition = alignments[_alignment];
        GetNode<Label>("Panel/Label").Text = _text;
        GetNode<TextureRect>("Icon").Texture = _texture;
    }

    public void SetAlignment(String newAlignment)
    {
        alignment = newAlignment;
        _panel.RectPosition = alignments[_alignment];
    }

    public void SetText(String newText)
    {
        text = newText;
        GetNode<Label>("Panel/Label").Text = _text;
    }

    public void SetTexture(Texture newTexture)
    {
        texture = newTexture;
        GetNode<TextureRect>("Icon").Texture = _texture;
    }
}