using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Alvearies : Building
{
    public static Array<Texture> ALVEARIESIdleAnim;

    public new void _Ready()
    {
        ALVEARIESIdleAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Agricultural/Alvearies/Sprites/Alvearies_idle_315.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = ALVEARIESIdleAnim;
                texture = ALVEARIESIdleAnim[rotationIndex] as Texture;
                _billboard.Vframes = 4;
                _billboard.Hframes = 5;
                _billboard.RegionRect = new Rect2(0, 0, 960, 768);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();

                break;
        }
    }
}