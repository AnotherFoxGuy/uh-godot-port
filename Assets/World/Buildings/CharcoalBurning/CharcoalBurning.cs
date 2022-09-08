using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CharcoalBurning : Building
{
    private Texture CHARCOALBurningIdle;
    private Texture CHARCOALBurningIdleFull;

    private Array<Texture> CHARCOALBurningWorkAnim;

    public static readonly Array<float> CHARCOALBurningWorkAnimRegionY = new Array<float>()
    {
        108 * 0, 108 * 1, 108 * 2, 108 * 3
    };

    public new void _Ready()
    {
        CHARCOALBurningIdle =
            GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_idle.png") as Texture;
        CHARCOALBurningIdleFull =
            GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_idle_full.png") as Texture;

        CHARCOALBurningWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/CharcoalBurning/Sprites/CharcoalBurning_work_anim.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = CHARCOALBurningIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 316, 216);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = CHARCOALBurningIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 316, 216);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = CHARCOALBurningWorkAnim;
                texture = CHARCOALBurningWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 7;
                _billboard.RegionRect = new Rect2(0, CHARCOALBurningWorkAnimRegionY[rotationIndex], 1106, 108);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}