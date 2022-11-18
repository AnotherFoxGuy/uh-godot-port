using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Storage : Building
{
    // Tier 1 (Sailors) Resources
    Texture STORAGETentIdle;

    // Tier 2 (Pioneers) Resources
    Texture STORAGEHutIdle;

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
        STORAGETentIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageTent_idle.png") as Texture;
        STORAGEHutIdle = GD.Load("res://Assets/World/Buildings/Storage/Sprites/StorageHut_idle.png") as Texture;

        TIERS = new Array<Texture>()
        {
            STORAGETentIdle,
            STORAGEHutIdle,
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
                        _billboard.RegionRect = new Rect2(0, 0, 256, 192);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 16);
                        break;
                    case 1:
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 2;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 32);

                        break;
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