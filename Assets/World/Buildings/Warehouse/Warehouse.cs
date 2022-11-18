using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Warehouse : Building
{
    // Tiers
    public const string WAREHOUSE = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
    public const string WAREHOUSEWooden = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
    public const string WAREHOUSETimberFramed = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";
    public const string WAREHOUSEStone = "res://Assets/World/Buildings/Warehouse/Warehouse.tscn";

    // Tier 1 (Sailors) Resources
    private Texture WAREHOUSEIdle;

    // Tier 2 (Pioneers) Resources
    private Texture WAREHOUSEWoodenIdle;

    // Tier 3 (Settlers) Resources
    private Texture WAREHOUSETimberFramedIdle;

    // Tier 4 (Citizens) Resources
    private Texture WAREHOUSEStoneIdle;

    // Tier 1 (Sailors) Sprites
    // Tier 2 (Pioneers) Sprites
    // Tier 3 (Settlers) Sprites
    // Tier 4 (Citizens) Sprites

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
        // Tier 1 (Sailors) Resources
        WAREHOUSEIdle = GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/Warehouse_idle.png") as Texture;

        // Tier 2 (Pioneers) Resources
        WAREHOUSEWoodenIdle =
            GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseWooden_idle.png") as Texture;

        // Tier 3 (Settlers) Resources
        WAREHOUSETimberFramedIdle =
            GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseTimberFramed_idle.png") as Texture;

        // Tier 4 (Citizens) Resources
        WAREHOUSEStoneIdle =
            GD.Load("res://Assets/World/Buildings/Warehouse/Sprites/WarehouseStone_idle.png") as Texture;

        TIERS = new Array<Texture>()
        {
            WAREHOUSEIdle,
            WAREHOUSEWoodenIdle,
            WAREHOUSETimberFramedIdle,
            WAREHOUSEStoneIdle,
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
                        _billboard.RegionRect = new Rect2(0, 0, 384, 256);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 10);
                        break;
                    case 1:
                    case 2:
                    case 3:
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 2;
                        _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 40);

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