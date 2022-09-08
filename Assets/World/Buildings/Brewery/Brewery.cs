using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Brewery : Building
{
    private Texture BREWERYIdle;
    private Texture BREWERYIdleFull;
    public static Array<Texture> BREWERYWorkAnim;

    public new void _Ready()
    {
        BREWERYIdle =
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_idle.png") as Texture;
        BREWERYIdleFull =
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_idle_full.png") as Texture;

        BREWERYWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/Brewery/Sprites/Brewery_work_315.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = BREWERYIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionEnabled = false;
                break;
            case "idle_full":
                currentAnim = null;
                texture = BREWERYIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionEnabled = false;
                break;
            case "work":
                currentAnim = BREWERYWorkAnim;
                texture = BREWERYWorkAnim[rotationIndex];
                _billboard.Vframes = 4;
                _billboard.Hframes = 4;
                _billboard.RegionEnabled = false;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}