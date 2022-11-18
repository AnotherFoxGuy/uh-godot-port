using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SaltPonds : Building
{
    private Texture SALTPondIdle;
    Texture SALTPondIdleFull;

    Texture SALTPondWorkAnim;

    public static readonly Array<float> SALTPondWorkAnimRegionY = new Array<float>()
    {
        32, 224, 416, 608
    };

    public new void _Ready()
    {
        SALTPondIdle = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle.png") as Texture;
        SALTPondIdleFull = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_idle_full.png") as Texture;
        SALTPondWorkAnim = GD.Load("res://Assets/World/Buildings/SaltPonds/Sprites/SaltPond_work_anim.png") as Texture;
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = SALTPondIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 256);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = SALTPondIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 256);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = new Array<Texture> { SALTPondWorkAnim };
                texture = SALTPondWorkAnim;
                _billboard.Vframes = 1;
                _billboard.Hframes = 6;
                _billboard.RegionRect = new Rect2(0, SALTPondWorkAnimRegionY[rotationIndex], 1152, 192);
                _billboard.RegionEnabled = true;
                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}