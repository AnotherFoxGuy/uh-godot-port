using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class InventorySlot : TextureButton
{
    [Export] bool showIfEmpty = true;

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

    // TODO: Make dependent from currently selected ship
    [Export]
    int storageLimit
    {
        set { SetStorageLimit(value); }
    }

    private int _storageLimit = 30;

    // onready var textureRect = $TextureRect
    // onready var label = $Label
    // onready var textureRect2 = $TextureRect2

    internal TextureRect textureRect;
    internal Label label;
    internal TextureRect textureRect2;

    public void _Ready()
    {
        textureRect = GetNode<TextureRect>("TextureRect");
        label = GetNode<Label>("Label");
        textureRect2 = GetNode<TextureRect>("TextureRect2");
        
        textureRect2.RectPivotOffset = textureRect2.RectSize;

        UpdateDisplay();
    }

    public void _Draw()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (_resourceType != Global.ResourceType.NONE && showIfEmpty ||
            _resourceType != Global.ResourceType.NONE && _resourceType > 0)
        {
            SetSlotStatus(true);
        }
        else
        {
            SetSlotStatus(false);
        }
    }

    public void SetSlotStatus(bool active)
    {
        var status = active ? "show" : "hide";

        textureRect.Call(status);
        label.Call(status);
        textureRect2.Call(status);
    }

    public async void SetResourceType(Global.ResourceType newResourceType)
    {
        //prints("new_resource_type:", newResourceType)
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _resourceType = (Global.ResourceType)Mathf.Wrap((int)newResourceType, 0, Global.RESOURCETypes.Count);

        textureRect.Texture = (Texture)Global.RESOURCETypes[(int)_resourceType];

        _Draw();
    }

    public async void SetResourceValue(int newResourceValue)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _resourceValue = Mathf.Clamp(newResourceValue, 0, _storageLimit);

        label.Text = GD.Str(_resourceValue);
        UpdateAmountBar();

        _Draw();
    }

    public async void SetStorageLimit(int newStorageLimit)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _storageLimit = Mathf.Clamp(newStorageLimit, 0, newStorageLimit);

        // Always keep resourceValue within the storageLimit
        _resourceValue = Mathf.Clamp(_resourceValue, 0, _storageLimit);
        PropertyListChangedNotify();

        UpdateAmountBar();
    }

    public async void UpdateAmountBar()
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        var scaleFactor = Mathf.Stepify((float)(1.0 / _storageLimit * _resourceValue), 0.01f);
        var x = textureRect2.RectSize;
        x.y = scaleFactor;
        textureRect2.RectSize = x;
    }

    public void _OnReady()
    {
        // if(!texture_rect)
        // 	 textureRect = $TextureRect
        // if(!label)
        // 	 label = $Label
        // if(!texture_rect2)
        // 	 textureRect2 = $TextureRect2
    }
}