using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Ship : Unit
{
    //warning-ignore-all:unusedClassVariable

    // Generic properties
    [Export] public int maxHealth = 150;

    // Navigational properties
    [Export] public int radius = 5;
    [Export] public int velocity = 12;

    // Storage capacity
    [Export] public int storageLimit = 120;
    [Export] public int numOfSlots = 4;

    public void _Ready()
    {
        AddToGroup("units");
        // DEBUG
        _billboard.Vframes = 2;
        _billboard.Hframes = 4;
    }

    public void _Process(float delta)
    {
        UpdatePath();

        RecalculateDirections();
        AnimateMovement();
        UpdateFactionColor();

        if (isMoving)
        {
            Translate(Utils.Map2To3(moveVector.Normalized()) * delta * velocity / 4);
        }
    }

    public void UpdateFactionColor()
    {
    }
}