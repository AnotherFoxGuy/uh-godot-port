using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CocoaField : Building
{
    private Texture COCOAFieldIdle;
    private Texture COCOAFieldIdleFull;

    private Texture COCOAFieldWorkAnim;

    public static readonly Array COCOAFieldWorkAnimRegionY = new Array()
    {
        192 * 0, 192 * 1, 192 * 2, 192 * 3
    };

    public new void _Ready()
    {
        COCOAFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle.png") as Texture;
        COCOAFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle_full.png") as Texture;

        COCOAFieldWorkAnim =
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_work_anim.png") as Texture;
    }

    public void Animate()
    {
        switch (action)
        {
            case  "idle":
                    currentAnim = null;
                    texture = COCOAFieldIdle;
                    _billboard.Vframes = 2;
                    _billboard.Hframes = 2;
                    _billboard.RegionRect = new Rect2(0
                , 0, 384, 384);
                    _billboard.RegionEnabled = true;

            case
                    "idle_full":
                    currentAnim = null;
                    texture = COCOAFieldIdleFull;
                    _billboard.Vframes = 2;
                    _billboard.Hframes = 2;
                    _billboard.RegionRect = new Rect2(0
                , 0, 384, 384);
                    _billboard.RegionEnabled = true;

            case
                    "work":
                    currentAnim = COCOAFieldWorkAnim;
                    texture = COCOAFieldWorkAnim;
                    _billboard.Vframes = 1;
                    _billboard.Hframes = 5;
                    _billboard.RegionRect = new Rect2(0
                , COCOAFieldWorkAnimRegionY, 960, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
        }

        base.Animate();
    }
}