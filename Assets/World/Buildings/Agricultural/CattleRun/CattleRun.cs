using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CattleRun : Building
{
    public Texture CATTLERunIdle;
    public Texture CATTLERunIdleFull;


    public static Array<Texture> CATTLERunWorkAnim;

    public new void _Ready()
    {
        CATTLERunIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_idle.png") as Texture;
        CATTLERunIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_idle_full.png") as Texture;

        CATTLERunWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/CattleRun/Sprites/CattleRun_work_315.png") as Texture,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = CATTLERunIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = CATTLERunIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                // set new animation set && randomize frame for the initial time},
                // afterwards only iterate through frames
                if (currentAnim != null  || currentAnim == null) // && currentAnim[0].GetLoadPath().Find("_work") == -1
                {
                    currentAnim = CATTLERunWorkAnim;
                    texture = CATTLERunWorkAnim[rotationIndex];
                    _billboard.Vframes = 10;
                    _billboard.Hframes = 15;
                    _billboard.RegionRect = new Rect2(0, 0, 2880, 1920);
                    _billboard.RegionEnabled = true;

                    _billboard.Frame = GetRandomFrame();
                    //prints(self.name, "randomized frame:", _billboard.frame)
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