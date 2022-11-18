using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MainSquare : Building
{
    // Tiers
    public const string MAINSquare = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
    public const string MAINSquareWooden = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
    public const string MAINSquareTimberFramed = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";
    public const string MAINSquareStone = "res://Assets/World/Buildings/MainSquare/MainSquare.tscn";

    // Tier 1 (Sailors) Resources


    // Tier 2 (Pioneers) Resources
    private Texture MAINSquareWoodenIdle;

    // Tier 3 (Settlers) Resources
    private Texture MAINSquareTimberFramedIdle;

    // Tier 4 (Citizens) Resources
    private Texture MAINSquareStoneIdle;

    // Tier 1 (Sailors) Sprites
    public Array<Texture> MAINSquareIdleAnim;

    // Tier 2 (Pioneers) Sprites
    // Tier 3 (Settlers) Sprites
    // Tier 4 (Citizens) Sprites
    public Array<Array<Texture>> TIERS;

    [Export]
    private int tier
    {
        set => SetTier(value);
        get => _tier;
    }

    private int _tier;

    public new void _Ready()
    {
        MAINSquareIdleAnim = new Array<Texture>
        {
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquare_idle_315.png") as Texture,
        };

        // Tier 2 (Pioneers) Resources
        MAINSquareWoodenIdle =
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareWooden_idle.png") as Texture;

        // Tier 3 (Settlers) Resources
        MAINSquareTimberFramedIdle =
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareTimberFramed_idle.png") as Texture;

        // Tier 4 (Citizens) Resources
        MAINSquareStoneIdle =
            GD.Load("res://Assets/World/Buildings/MainSquare/Sprites/MainSquareStone_idle.png") as Texture;

        TIERS = new Array<Array<Texture>>()
        {
            MAINSquareIdleAnim,
            new Array<Texture> { MAINSquareWoodenIdle },
            new Array<Texture> { MAINSquareTimberFramedIdle },
            new Array<Texture> { MAINSquareStoneIdle },
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                // As of now}, only 1st tier is animated
                if (tier == 0)
                {
                    currentAnim = TIERS[tier];
                    texture = TIERS[tier][rotationIndex];
                    _billboard.Vframes = 2;
                    _billboard.Hframes = 13;
                    _billboard.RegionRect = new Rect2(0, 0, 4992, 448);
                    _billboard.RegionEnabled = true;

                    _billboard.Frame = NextFrame();
                }
                else
                {
                    currentAnim = null;
                    texture = TIERS[tier][rotationIndex];
                    _billboard.Vframes = 2;
                    _billboard.Hframes = 2;
                    _billboard.RegionRect = new Rect2(0, 0, 768, 448);
                    _billboard.RegionEnabled = true;
                }

                break;
        }

        base.Animate();
    }

    public void SetTier(int newTier)
    {
        var previousTier = tier;

        tier = Mathf.Clamp(newTier, 0, TIERS.Count - 1);
        if (tier > previousTier)
        {
            Upgrade();
        }
        else
        {
            Downgrade();
        }
    }

    public void Upgrade()
    {
        // TODO
    }

    public void Downgrade()
    {
        // TODO
    }
}