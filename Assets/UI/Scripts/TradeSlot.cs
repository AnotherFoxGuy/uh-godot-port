using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class TradeSlot : InventorySlot
{
    public Texture NONETexture;

    VSlider vSlider;

    public async void UpdateDisplay()
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        base.UpdateDisplay();

        if (!label.Visible && !textureRect2.Visible)
        {
            textureRect.Texture = NONETexture;
            textureRect.Show();
            vSlider.Hide();
        }
        else
        {
            textureRect.Show();
            label.Show();
            textureRect2.Show();
            vSlider.Show();
        }
    }

    public void _OnReady()
    {
        NONETexture = GD.Load<Texture>("res://Assets/UI/Icons/Resources/none_gray.png");
        vSlider = GetNode<VSlider>("VSlider");
    }
}