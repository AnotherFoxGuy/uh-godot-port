using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Distillery : Building
{
    private Texture DISTILLERYIdle;
    private Array<Texture> DISTILLERYWorkAnim;

    public static readonly Array<float> DISTILLERYWorkAnimRegionY = new Array<float>()
    {
        98 * 0, 98 * 1, 98 * 2, 98 * 3
    };

    public new void _Ready()
    {
        DISTILLERYIdle = GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_idle.png") as Texture;

        DISTILLERYWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Distillery/Sprites/Distillery_work_anim.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = DISTILLERYIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 256, 196);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = DISTILLERYWorkAnim;
                texture = DISTILLERYWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 5;
                _billboard.RegionRect = new Rect2(0, DISTILLERYWorkAnimRegionY[rotationIndex], 640, 98);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}