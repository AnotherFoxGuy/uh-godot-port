using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pasture : Building
{
    private Texture PASTUREIdle;


    public static Array<Texture> PASTUREWorkAnim = new Array<Texture>()
    {
    };

    public new void _Ready()
    {
        PASTUREIdle = GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_idle.png") as Texture;
        PASTUREWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pasture/Sprites/Pasture_work_315.png") as Texture,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case
                "idle":
                currentAnim = null;
                texture = PASTUREIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                return;
            case
                "work":
                // set new animation set && randomize frame for the initial time},
                // afterwards only iterate through frames
                if (currentAnim != null && currentAnim[0].ResourcePath.Find("_work") == -1 || currentAnim == null) 
                {
                    currentAnim = PASTUREWorkAnim;
                    //update_rotation()
                    texture = PASTUREWorkAnim[rotationIndex];
                    _billboard.Vframes = 10;
                    _billboard.Hframes = 20;
                    _billboard.RegionRect = new Rect2(0, 0, 3840, 1920);
                    _billboard.RegionEnabled = true;

                    _billboard.Frame = GetRandomFrame();
                    //prints("randomized frame:", _billboard.Frame)
                }
                else
                {
                    _billboard.Frame = NextFrame();
                }

                return;
        }

        base.Animate();
    }
}