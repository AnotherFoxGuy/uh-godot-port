using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Bookmark : TextureButton
{
    public static Texture BOOKMARKLeft;
    public static Texture BOOKMARKRight;

    public readonly Array<Texture> SIDES = new Array<Texture>()
    {
        BOOKMARKLeft,
        BOOKMARKRight
    };

    [Export]
    public int side
    {
        set => SetSide(value);
        get => _side;
    }

    private int _side;

    public new void _Ready()
    {
        BOOKMARKLeft = GD.Load("res://Assets/UI/Images/Background/pickbelt_left.png") as Texture;
        BOOKMARKRight = GD.Load("res://Assets/UI/Images/Background/pickbelt_right.png") as Texture;
    }

    public void SetSide(int newSide)
    {
        _side = newSide;
        TextureNormal = SIDES[newSide];
    }
}