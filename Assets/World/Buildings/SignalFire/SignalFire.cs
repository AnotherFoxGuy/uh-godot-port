using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SignalFire : Building
{
    // Tiers
    public const string SIGNALFire = "res://Assets/World/Buildings/SignalFire/SignalFire.tscn";
    public const string SIGNALFireWooden = "res://Assets/World/Buildings/SignalFire/SignalFire.tscn";

    // Tier 1 (Sailors) Sprites
    public Array<Texture> SIGNALFireIdleAnim;

    // Tier 2 (Pioneers) Sprites
    public Array<Texture> SIGNALFireWoodenIdleAnim;

    // Tier 3 (Settlers) Sprites
    public Array<Texture> SIGNALFireClinkerIdleAnim;

    public Array<Array<Texture>> TIERS;

    [Export]
    private int tier
    {
        set => SetTier(value);
        get => _tier;
    }

    private int _tier;

    public void _Ready()
    {
        action = "idle";

        // Tier 1 (Sailors) Sprites
        SIGNALFireIdleAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFire_idle_315.png") as Texture,
        };

        // Tier 2 (Pioneers) Sprites
        SIGNALFireWoodenIdleAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireWooden_idle_315.png") as Texture,
        };

        // Tier 3 (Settlers) Sprites
        SIGNALFireClinkerIdleAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/SignalFire/Sprites/SignalFireClinker_idle_315.png") as Texture,
        };

        TIERS = new Array<Array<Texture>>()
        {
            SIGNALFireIdleAnim,
            SIGNALFireWoodenIdleAnim,
            SIGNALFireClinkerIdleAnim,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = TIERS[tier];
                texture = TIERS[tier][rotationOffset];

                switch (tier)
                {
                    case 0:
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 5;
                        _billboard.RegionRect = new Rect2(0, 0, 320, 256);
                        _billboard.RegionEnabled = true;
                        break;
                    case 1:
                        _billboard.Vframes = 4;
                        _billboard.Hframes = 4;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 512);
                        _billboard.RegionEnabled = true;
                        break;
                    case 2:
                        _billboard.Vframes = 4;
                        _billboard.Hframes = 4;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 512);
                        _billboard.RegionEnabled = true;

                        break;
                }

                _billboard.Frame = NextFrame();
                break;
        }
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