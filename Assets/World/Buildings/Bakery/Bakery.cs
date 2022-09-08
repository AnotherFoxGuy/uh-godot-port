using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Bakery : Building
{
    private Texture BAKERYIdle;

    private Array<Texture> BAKERYWorkAnim;

    public static readonly Array<float> BAKERYWorkAnimRegionY = new Array<float>()
    {
        128 * 0, 128 * 1, 128 * 2, 128 * 3
    };
    public new void _Ready()
    {
        BAKERYIdle =
            GD.Load("res://Assets/World/Buildings/Bakery/Sprites/Bakery_idle.png") as Texture;

        BAKERYWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Bakery/Sprites/Bakery_work_anim.png") as Texture
        };
    }
    

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = BAKERYIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = BAKERYWorkAnim;
                texture = BAKERYWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 8;
                _billboard.RegionRect = new Rect2(0, BAKERYWorkAnimRegionY[rotationIndex], 1024, 128);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}