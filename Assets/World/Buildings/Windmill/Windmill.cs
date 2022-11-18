using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Windmill : Building
{
    private Texture WINDMILLIdle;
    private Texture WINDMILLIdleFull;

    private Texture WINDMILLWork45;
    private Texture WINDMILLWork135;
    private Texture WINDMILLWork225;
    private Texture WINDMILLWork315;

    public Array<Texture> WINDMILLWorkAnim;

    public new void _Ready()
    {
        WINDMILLIdle = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle.png") as Texture;
        WINDMILLIdleFull = GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_idle_full.png") as Texture;

        WINDMILLWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Windmill/Sprites/Windmill_work_315.png") as Texture,
        };
    }


    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = WINDMILLIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                break;
            case "idle_full":
                currentAnim = null;
                texture = WINDMILLIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 256, 256);
                break;
            case "work":
                // set new animation set && randomize frame for the initial time},
                // afterwards only iterate through frames
                if (currentAnim != null && currentAnim[0].ResourcePath.Contains("_work") || currentAnim == null)
                {
                    currentAnim = WINDMILLWorkAnim;
                    texture = WINDMILLWorkAnim[rotationIndex];
                    _billboard.Vframes = 5;
                    _billboard.Hframes = 6;
                    _billboard.RegionRect = new Rect2(0, 0, 768, 640);

                    _billboard.Frame = GetRandomFrame();
                    //prints(self.name, "randomized frame:", _billboard.Frame)
                }
                else
                {
                    _billboard.Frame = NextFrame();
                }

                break;
        }

        base.Animate();
    }
}