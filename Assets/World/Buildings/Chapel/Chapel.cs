using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Chapel : Building
{
    // Tier 1 (Sailors) Resources
    private Texture CHAPELIdle;

    // Tier 2 (Pioneers) Resources
    private Texture CHAPELWoodenIdle;

    // Tier 3 (Settlers) Resources
    private Texture CHAPELClinkerIdle;

    public Array<Texture> TIERS;

    [Export]
    private int tier
    {
        set => SetTier(value);
        get => _tier;
    }

    private int _tier;

    public new void _Ready()
    {
        CHAPELIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/SunSail_idle.png") as Texture;

        // Tier 2 (Pioneers) Resources
        CHAPELWoodenIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/Chapel_idle.png") as Texture;

        // Tier 3 (Settlers) Resources
        CHAPELClinkerIdle = GD.Load("res://Assets/World/Buildings/Chapel/Sprites/ChapelClinker_idle.png") as Texture;

        TIERS = new Array<Texture>()
        {
            CHAPELIdle,
            CHAPELWoodenIdle,
            CHAPELClinkerIdle,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = TIERS[tier];
                switch (tier)
                {
                    case 0:
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 2;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 32);
                        break;
                    case 1:
                    case 2:
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 2;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 48);
                        break;
                }

                break;
        }

        base.Animate();
    }

    public void SetTier(int newTier)
    {
        var previousTier = _tier;

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