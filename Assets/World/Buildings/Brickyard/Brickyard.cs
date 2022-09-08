using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Brickyard : Building
{
    public static Array<Texture> BRICKYARDIdle;

    //const BRICKYARDWorkAnim = new Array(){
    //	BRICKYARDWork45,
    //	BRICKYARDWork135,
    //	BRICKYARDWork225,
    //	BRICKYARDWork315,
    //};

    //const BRICKYARDBurnAnim = new Array(){
    //	BRICKYARDBurn45,
    //	BRICKYARDBurn135,
    //	BRICKYARDBurn225,
    //	BRICKYARDBurn315,
    //};

    [Export] public int resourceAmount
    {
        set => SetResourceAmount(value);
    }

    private int _resourceAmount;

    public new void _Ready()
    {
        BRICKYARDIdle = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_01.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_02.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_03.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brickyard/Sprites/Brickyard_idle_bricks_04.png") as Texture,
        };
    }

    public void SetResourceAmount(int newResourceAmount)
    {
        _resourceAmount = newResourceAmount;
        texture = BRICKYARDIdle[_resourceAmount];
    }
}