using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ToggleButton : WidgetButton
{
    // Button that cycles between two states visually.
    //
    // TODO: Clean up && possibly merge into base button class.

    [Export]
    Texture textureNormalInitial
    {
        set { SetTextureNormalInitial(value); }
    }

    [Export]
    Texture texturePressedInitial
    {
        set { SetTexturePressedInitial(value); }
    }

    [Export]
    Texture textureHoverInitial
    {
        set { SetTextureHoverInitial(value); }
    }

    [Export] Texture textureNormalAlternate;
    [Export] Texture texturePressedAlternate;
    [Export] Texture textureHoverAlternate;

    private AnimatedTexture animatedTexture;

    public void _Ready()
    {
        animatedTexture = GetNode<AnimatedTexture>("AnimatedTexture");
        _SetAnimation();
    }

    public void _Pressed()
    {
        Audio.Instance.PlaySndClick();
    }

    public void _Toggled(bool buttonPressed)
    {
        var textureVariant = buttonPressed ? "alternate" : "initial";

        var x = new Array<string>() { "normal", "pressed", "hover" };

        foreach (var textureType in x)
        {
            //prints("Set", textureType + "_" + textureVariant, "for", textureType, "_texture")
            Call($"set_{textureType}_texture", Get($"texture_{textureType}_{textureVariant}"));
        }

        _SetAnimation();
    }

    public void SetTextureNormalInitial(Texture newTextureNormalInitial)
    {
        textureNormalInitial = newTextureNormalInitial;
        TextureNormal = textureNormalInitial;

        PropertyListChangedNotify();
    }

    public void SetTexturePressedInitial(Texture newTexturePressedInitial)
    {
        texturePressedInitial = newTexturePressedInitial;
        TexturePressed = texturePressedInitial;

        PropertyListChangedNotify();
    }

    public void SetTextureHoverInitial(Texture newTextureHoverInitial)
    {
        textureHoverInitial = newTextureHoverInitial;
        TextureHover = textureHoverInitial;

        PropertyListChangedNotify();
    }

    public void _SetAnimation()
    {
        if (animatedTexture != null)
        {
            if (Pressed)
            {
                animatedTexture.Hide();
                TextureNormal = !Pressed ? textureNormalInitial : textureNormalAlternate;
            }
            else
            {
                animatedTexture.Show();
                TextureNormal = null;
                //prints("animated_texture.visible:", animatedTexture.visible)
            }
        }
    }

    public void _OnActionButtonGuiInput(InputEvent _event)
    {
        if (animatedTexture)
        {
            animatedTexture.Hide();

            //func _OnActionButtonMouseEntered() -> void:
            //	animatedTexture.Hide()
        }
    }

    public void _OnActionButtonMouseExited()
    {
        if (animatedTexture)
        {
            if (!Pressed)
            {
                animatedTexture.Show();
            }
        }
    }
}