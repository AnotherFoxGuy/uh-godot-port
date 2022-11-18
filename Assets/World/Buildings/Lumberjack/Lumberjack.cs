using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;
using Object = Godot.Object;

[Tool]
public class Lumberjack : Building
{
    // Tiers
    public const string LUMBERJACKTent = "res://Assets/World/Buildings/Lumberjack/Lumberjack.tscn";
    public const string LUMBERJACKHut = "res://Assets/World/Buildings/Lumberjack/Lumberjack.tscn";

    // Tier 1 (Sailors) Sprites
    public Array<Texture> LUMBERJACKTentIdleLogs;

    //const LUMBERJACKTentWorkAnim = new Array(){
    //	LUMBERJACKTentWork45,
    //	LUMBERJACKTentWork135,
    //	LUMBERJACKTentWork225,
    //	LUMBERJACKTentWork315,
    //};

    //const LUMBERJACKTentBurnAnim = new Array(){
    //	LUMBERJACKTentBurn45,
    //	LUMBERJACKTentBurn135,
    //	LUMBERJACKTentBurn225,
    //	LUMBERJACKTentBurn315,
    //};

    // Tier 2 (Pioneers) Sprites Logs
    public Array<Texture> LUMBERJACKHutIdleLogs;

    // Tier 2 (Pioneers) Sprites Planks
    public Array<Texture> LUMBERJACKHutIdlePlanks;

    public Array<Texture> TIERS;

    [Export]
    private int tier
    {
        set => SetTier(value);
        get => _tier;
    }

    private int _tier;

    [Export]
    public int resourceAmount
    {
        set => SetResourceAmount(value);
        get => _resourceAmount;
    }

    private int _resourceAmount;

    [Export]
    public int resourceAmountOutput
    {
        set => SetResourceAmountOutput(value);
        get => _resourceAmountOutput;
    }

    private int _resourceAmountOutput;

    //onready var resourceOverlay  = GetNodeOrNull("Billboard/ResourceOverlay");
    private Sprite3D resourceOverlay;
    //onready var resourceOverlay2  = GetNodeOrNull("Billboard/ResourceOverlay2");
    private Sprite3D resourceOverlay2;

    public void _Ready()
    {
        SetRotationDegree(rotationDegree);
        SetResourceAmount(resourceAmount);
        SetResourceAmountOutput(resourceAmountOutput);

        LUMBERJACKTentIdleLogs = new Array<Texture>()
        {
            // Tier 1 (Sailors) Resources
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_01.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_02.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_03.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_04.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackTent_idle_logs_05.png") as Texture,
        };
        LUMBERJACKHutIdleLogs = new Array<Texture>()
        {
            // Tier 2 (Pioneers) Resources
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_01.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_02.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_03.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_04.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_logs_05.png") as Texture,
        };
        LUMBERJACKHutIdlePlanks = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_01.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_02.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_03.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_04.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_05.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_06.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_07.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_08.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_09.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_10.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_11.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Lumberjack/Sprites/LumberjackHut_overlay_planks_12.png") as Texture,
        };

        TIERS = new Array<Texture>()
        {
            LUMBERJACKTentIdleLogs[0],
            LUMBERJACKHutIdleLogs[0],
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                switch (tier)
                {
                    case 0:
                        texture = LUMBERJACKTentIdleLogs.Contains(texture) ? TIERS[0] : texture;
                        _billboard.Vframes = 2;
                        _billboard.Hframes = 2;
                        _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                        _billboard.RegionEnabled = true;
                        _billboard.Offset = new Vector2(0, 32);
                        break;
                    case 1:
                        texture = TIERS[tier];
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

    public void SetResourceAmount(int newResourceAmount)
    {
        resourceAmount = newResourceAmount;

        if (!IsInsideTree())
        {
            return;
        }

        if (tier == 0)
        {
            texture = LUMBERJACKTentIdleLogs[resourceAmount];
        }
        else
        {
            texture = LUMBERJACKTentIdleLogs[0];
            resourceOverlay.Texture = resourceAmount > 0
                ? LUMBERJACKHutIdleLogs[Mathf.Clamp(resourceAmount - 1, 0, LUMBERJACKHutIdleLogs.Count - 1)]
                : null;
        }
    }

    public void SetResourceAmountOutput(int newResourceAmountOutput)
    {
        resourceAmountOutput = newResourceAmountOutput;

        if (!IsInsideTree())
        {
            return;
        }

        if (tier == 1)
        {
            texture = LUMBERJACKHutIdlePlanks[0];
            resourceOverlay2.Texture = resourceAmountOutput > 0
                ? LUMBERJACKHutIdlePlanks[Mathf.Clamp(resourceAmountOutput - 1, 0, LUMBERJACKHutIdlePlanks.Count - 1)]
                : null;
        }
    }

    public void AddResource()
    {
        // TODO
    }

    public void RemoveResource()
    {
        // TODO
    }

    public void _OnInput(InputEvent _event)
    {
        base._OnInput(_event);

        //if(null in [resourceOverlay, resourceOverlay2])
        //	 return;

        // Switch frame accordingly with the world rotation.
        if (_event.IsActionPressed("rotate_left"))
        {
            resourceOverlay.Frame = Mathf.Wrap(resourceOverlay.Frame - 1, 0,
                resourceOverlay.Hframes * resourceOverlay.Vframes);
            resourceOverlay2.Frame = Mathf.Wrap(resourceOverlay2.Frame - 1, 0,
                resourceOverlay2.Hframes * resourceOverlay2.Vframes);
        }
        else if (_event.IsActionPressed("rotate_right"))
        {
            resourceOverlay.Frame = Mathf.Wrap(resourceOverlay.Frame + 1, 0,
                resourceOverlay.Hframes * resourceOverlay.Vframes);
            resourceOverlay2.Frame = Mathf.Wrap(resourceOverlay2.Frame + 1, 0,
                resourceOverlay2.Hframes * resourceOverlay2.Vframes);
        }
    }

    public void SetRotationDegree(RotationDegree newRotation)
    {
        base.SetRotationDegree(newRotation);

        if (!IsInsideTree() || resourceOverlay == null)
        {
            return;
        }

        resourceOverlay.Frame = rotationIndex;
        resourceOverlay2.Frame = rotationIndex;
    }
}