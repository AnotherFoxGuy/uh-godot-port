using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pigsty : Building
{
    private Texture PIGSTYIdle;
    public static Array<Texture> PIGSTYWorkAnim;

    public new void _Ready()
    {
        PIGSTYIdle = GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_idle.png") as Texture;
        PIGSTYWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Pigsty/Sprites/Pigsty_work_315.png") as Texture,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = PIGSTYIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                // set new animation set && randomize frame for the initial time},
                // afterwards only iterate through frames
                if (currentAnim != null && currentAnim[0].ResourcePath.Find("_work") == -1 || currentAnim == null)
                {
                    currentAnim = PIGSTYWorkAnim;
                    texture = PIGSTYWorkAnim[rotationIndex];
                    _billboard.Vframes = 8;
                    _billboard.Hframes = 10;
                    _billboard.RegionRect = new Rect2(0, 0, 1920, 1536);
                    _billboard.RegionEnabled = true;

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