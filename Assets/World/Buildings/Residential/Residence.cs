using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Residence : Building
{
    // Tiers
    public const string RESIDENTIALTent = "res://Assets/World/Buildings/Residential/Residence.tscn";
    public const string RESIDENTIALHut = "res://Assets/World/Buildings/Residential/Residence.tscn";
    public const string RESIDENTIALHouseTimberFramed = "res://Assets/World/Buildings/Residential/Residence.tscn";
    public const string RESIDENTIALStoneHouse = "res://Assets/World/Buildings/Residential/Residence.tscn";

    /*// Tier 1 (Sailors) Resources
    Texture RESIDENTIALTent1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent1_idle.png");
    
    Texture RESIDENTIALTent2Idle45 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_45.png");
    Texture RESIDENTIALTent2Idle135 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_135.png");
    Texture RESIDENTIALTent2Idle225 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_225.png");
    Texture RESIDENTIALTent2Idle315 = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_315.png");
    
    Texture RESIDENTIALTent3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent3_idle.png");
    Texture RESIDENTIALTent4Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent4_idle.png");
    Texture RESIDENTIALTent5Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent5_idle.png");
    Texture RESIDENTIALTent6Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent6_idle.png");
    
    Texture RESIDENTIALTentRuined = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent_ruined.png");
    
    // Tier 2 (Pioneers) Resources
    Texture RESIDENTIALHut1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut1_idle.png");
    Texture RESIDENTIALHut2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut2_idle.png");
    Texture RESIDENTIALHut3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut3_idle.png");
    
    // Tier 3 (Settlers) Resources
    Texture RESIDENTIALHouseTimberFramed1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed1_idle.png");
    Texture RESIDENTIALHouseTimberFramed2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed2_idle.png");
    Texture RESIDENTIALHouseTimberFramed3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed3_idle.png");
    
    // Tier 4 (Citizens) Resources
    Texture RESIDENTIALStoneHouse1Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse1_idle.png");
    Texture RESIDENTIALStoneHouse2Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse2_idle.png");
    Texture RESIDENTIALStoneHouse3Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse3_idle.png");
    Texture RESIDENTIALStoneHouse4Idle = GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse4_idle.png");
    
    // Tier 1 (Sailors) Sprites
    public  Array RESIDENTIALTent2IdleAnim = new Array(){
        RESIDENTIALTent2Idle45,
        RESIDENTIALTent2Idle135,
        RESIDENTIALTent2Idle225,
        RESIDENTIALTent2Idle315,
    };
    
    public  Array RESIDENTIALTentIdle = new Array(){
        RESIDENTIALTent1Idle,
        RESIDENTIALTent2IdleAnim, // 2nd tent is animated, treat differently
        RESIDENTIALTent3Idle,
        RESIDENTIALTent4Idle,
        RESIDENTIALTent5Idle,
        RESIDENTIALTent6Idle,
    };
    
    // Tier 2 (Pioneers) Sprites
    public  Array RESIDENTIALHutIdle = new Array(){
        RESIDENTIALHut1Idle,
        RESIDENTIALHut2Idle,
        RESIDENTIALHut3Idle,
    };
    
    // Tier 3 (Settlers) Sprites
    public  Array RESIDENTIALHouseTimberFramedIdle = new Array(){
        RESIDENTIALHouseTimberFramed1Idle,
        RESIDENTIALHouseTimberFramed2Idle,
        RESIDENTIALHouseTimberFramed3Idle,
    };
    
    // Tier 4 (Citizens) Sprites
    public  Array RESIDENTIALStoneHouseIdle = new Array(){
        RESIDENTIALStoneHouse1Idle,
        RESIDENTIALStoneHouse2Idle,
        RESIDENTIALStoneHouse3Idle,
        RESIDENTIALStoneHouse4Idle,
    };
    
    public  Array TIERS = new Array(){
        RESIDENTIALTentIdle,
        RESIDENTIALHutIdle,
        RESIDENTIALHouseTimberFramedIdle,
        RESIDENTIALStoneHouseIdle,
    };*/

    // Tier 1 (Sailors) Sprites
    public Array<Texture> RESIDENTIALTent2IdleAnim;

    public Array<Texture> RESIDENTIALTentIdle;

    // Tier 2 (Pioneers) Sprites
    public Array<Texture> RESIDENTIALHutIdle;

    // Tier 3 (Settlers) Sprites
    public Array<Texture> RESIDENTIALHouseTimberFramedIdle;

    // Tier 4 (Citizens) Sprites
    public Array<Texture> RESIDENTIALStoneHouseIdle;

    public Array<Array<Texture>> TIERS;

    private Texture RESIDENTIALTentRuined;

    [Export]
    private int tier
    {
        set => SetTier(value);
        get => _tier;
    }

    private int _tier;

    [Export]
    int variation
    {
        set { SetVariation(value); }
        get => _variation;
    }

    private int _variation;


    public void _Ready()
    {
        RESIDENTIALTentRuined = GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent_ruined.png") as Texture;

        // Tier 1 (Sailors) Sprites
        RESIDENTIALTent2IdleAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent2_idle_315.png") as Texture,
        };

        RESIDENTIALTentIdle = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent1_idle.png") as Texture,
            //RESIDENTIALTent2IdleAnim, // 2nd tent is animated, treat differently
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent3_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent4_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent5_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Tent6_idle.png") as Texture,
        };

        // Tier 2 (Pioneers) Sprites
        RESIDENTIALHutIdle = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut1_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut2_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/Hut3_idle.png") as Texture,
        };

        // Tier 3 (Settlers) Sprites
        RESIDENTIALHouseTimberFramedIdle = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed1_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed2_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/HouseTimberFramed3_idle.png") as Texture,
        };

        // Tier 4 (Citizens) Sprites
        RESIDENTIALStoneHouseIdle = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse1_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse2_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse3_idle.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Residential/Sprites/StoneHouse4_idle.png") as Texture,
        };

        TIERS = new Array<Array<Texture>>()
        {
            RESIDENTIALTentIdle,
            RESIDENTIALHutIdle,
            RESIDENTIALHouseTimberFramedIdle,
            RESIDENTIALStoneHouseIdle,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                if (tier == 0 && variation == 1) // the animated tent
                {
                    currentAnim = RESIDENTIALTent2IdleAnim;
                    texture = RESIDENTIALTent2IdleAnim[rotationIndex];
                    _billboard.Vframes = 5;
                    _billboard.Hframes = 5;
                    _billboard.RegionRect = new Rect2(0, 0, 640, 640);
                    _billboard.RegionEnabled = true;

                    _billboard.Frame = NextFrame();
                }
                else
                {
                    currentAnim = null;
                    texture = TIERS[tier][variation];
                    _billboard.Vframes = 2;
                    _billboard.Hframes = 2;
                    _billboard.RegionEnabled = false;
                }

                break;
        }
    }

    public void Destroy()
    {
        texture = RESIDENTIALTentRuined;
    }

    public void SetTier(int newTier)
    {
        var previousTier = tier;

        tier = Mathf.Clamp(newTier, 0, TIERS.Count - 1);
        variation = Mathf.Wrap(variation, 0, TIERS[tier].Count);

        if (tier > previousTier)
        {
            Upgrade();
        }
        else
        {
            Downgrade();
        }
    }

    public void SetVariation(int newVariation)
    {
        variation = Mathf.Wrap(newVariation, 0, TIERS[tier].Count);
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