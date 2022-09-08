using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class HopField : Building
{
    private Texture HOPFieldIdle;
    private Texture HOPFieldIdleFull;

    private Array<Texture> HOPFieldWorkAnim;

    public static readonly Array<float> HOPFieldWorkAnimRegionY = new Array<float>()
    {
        192 * 0, 192 * 1, 192 * 2, 192 * 3
    };

    public new void _Ready()
    {
        HOPFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_idle.png") as Texture;
        HOPFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_idle_full.png") as Texture;

        HOPFieldWorkAnim = new Array<Texture>()
            { GD.Load("res://Assets/World/Buildings/Agricultural/HopField/Sprites/HopField_work_anim.png") as Texture };
    }


    public void Animate()
    {
        switch (action)
        {
            case
                "idle":
                currentAnim = null;
                texture = HOPFieldIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0
                    , 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case
                "idle_full":
                currentAnim = null;
                texture = HOPFieldIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0
                    , 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case
                "work":
                currentAnim = HOPFieldWorkAnim;
                texture = HOPFieldWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 4;
                _billboard.RegionRect = new Rect2(0
                    , HOPFieldWorkAnimRegionY[rotationIndex], 768, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}