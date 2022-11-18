using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Toolmaker : Building
{
    private Texture TOOLMAKERIdle;

    private Texture TOOLMAKERWorkAnim;

    public static readonly Array<float> TOOLMAKERWorkAnimRegionY = new Array<float>()
    {
        98 * 0, 98 * 1, 98 * 2, 98 * 3
    };

    public new void _Ready()
    {
        TOOLMAKERIdle = GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_idle.png") as Texture;
        TOOLMAKERWorkAnim =
            GD.Load("res://Assets/World/Buildings/Toolmaker/Sprites/Toolmaker_work_anim.png") as Texture;
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = TOOLMAKERIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 256, 196);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = new Array<Texture> { TOOLMAKERWorkAnim };
                texture = TOOLMAKERWorkAnim;
                _billboard.Vframes = 1;
                _billboard.Hframes = 8;
                _billboard.RegionRect = new Rect2(0, TOOLMAKERWorkAnimRegionY[rotationIndex], 1024, 98);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}