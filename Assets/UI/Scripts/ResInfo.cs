using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ResInfo : TextureRect
{
    [Export]
    Global.ResourceType resourceType
    {
        set { SetResourceType(value); }
    }

    private Global.ResourceType _resourceType;

    [Export]
    int resourceValue
    {
        set { SetResourceValue(value); }
    }

    private int _resourceValue;

    // onready var textureRect = $VBoxContainer/TextureRect
    // onready var label = $VBoxContainer/Label

    private TextureRect textureRect;
    private Label label;

    public async void SetResourceType(Global.ResourceType newResourceType)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _resourceType = (Global.ResourceType)Mathf.Wrap((int)newResourceType, 0, Global.RESOURCETypes.Count);
        textureRect.Texture = (Texture)Global.RESOURCETypes[(int)_resourceType];
    }

    public async void SetResourceValue(int newResourceValue)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _resourceValue = newResourceValue;
        label.Text = GD.Str(_resourceValue);
    }

    public void _OnReady()
    {
        // if(!texture_rect)
        textureRect = GetNode<TextureRect>("VBoxContainer/TextureRect");
        // if(!label)
        label = GetNode<Label>("VBoxContainer/Label");
    }
}