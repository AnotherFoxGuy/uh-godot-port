using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CannonFoundry : Building
{
    private Texture CANNONFoundryIdle;
    private Texture CANNONFoundryIdleFull;
    public static Array<Texture> CANNONFoundryWorkAnim;

    public new void _Ready()
    {
        CANNONFoundryIdle =
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_idle.png") as Texture;
        CANNONFoundryIdleFull =
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_idle_full.png") as Texture;
        CANNONFoundryWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/CannonFoundry/Sprites/CannonFoundry_work_315.png") as Texture,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = CANNONFoundryIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = CANNONFoundryIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = CANNONFoundryWorkAnim;
                texture = CANNONFoundryWorkAnim[rotationIndex];
                _billboard.Vframes = 7;
                _billboard.Hframes = 20;
                _billboard.RegionRect = new Rect2(0, 0, 3840, 1344);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}