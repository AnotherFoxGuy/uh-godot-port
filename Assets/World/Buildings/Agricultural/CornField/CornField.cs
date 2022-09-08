using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CornField : Building
{
    private Texture CORNFieldIdle;
    private Texture CORNFieldIdleFull;

    private Array<Texture> CORNFieldWorkAnim;

    public static readonly Array<float> CORNFieldWorkAnimRegionY = new Array<float>()
    {
        192 * 0, 192 * 1, 192 * 2, 192 * 3
    };
    
    public new void _Ready()
    {
        CORNFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_idle.png") as Texture;
        CORNFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_idle_full.png") as Texture;

        CORNFieldWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/CornField/Sprites/CornField_work_anim.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = CORNFieldIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = CORNFieldIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = CORNFieldWorkAnim;
                texture = CORNFieldWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 4;
                _billboard.RegionRect = new Rect2(0, CORNFieldWorkAnimRegionY[rotationIndex], 768, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}