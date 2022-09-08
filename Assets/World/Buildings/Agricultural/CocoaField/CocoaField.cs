using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CocoaField : Building
{
    private Texture COCOAFieldIdle;
    private Texture COCOAFieldIdleFull;

    private Array<Texture> COCOAFieldWorkAnim;

    public static readonly Array<float> COCOAFieldWorkAnimRegionY = new Array<float>()
    {
        192 * 0, 192 * 1, 192 * 2, 192 * 3
    };

    public new void _Ready()
    {
        COCOAFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle.png") as Texture;
        COCOAFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_idle_full.png") as Texture;

        COCOAFieldWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/CocoaField/Sprites/CocoaField_work_anim.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = COCOAFieldIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0
                    , 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;

            case "idle_full":
                currentAnim = null;
                texture = COCOAFieldIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0
                    , 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;

            case "work":
                currentAnim = COCOAFieldWorkAnim;
                texture = COCOAFieldWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 5;
                _billboard.RegionRect = new Rect2(0
                    , COCOAFieldWorkAnimRegionY[rotationIndex], 960, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}