using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PotatoField : Building
{
    private Texture POTATOFieldIdle;
    private Texture POTATOFieldIdleFull;

    //const POTATOFieldWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_45.png");
    //const POTATOFieldWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_135.png");
    //const POTATOFieldWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_225.png");
    //const POTATOFieldWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_315.png");

    //const POTATOFieldWorkAnim = new Array(){
    //	POTATOFieldWork45,
    //	POTATOFieldWork135,
    //	POTATOFieldWork225,
    //	POTATOFieldWork315,
    //};
    private Array<Texture> POTATOFieldWorkAnim;

    public static readonly Array<float> POTATOFieldWorkAnimRegion = new Array<float>()
    {
        0, 192, 384, 576
    };

    public new void _Ready()
    {
        POTATOFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_idle.png") as Texture;
        POTATOFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_idle_full.png") as
                Texture;

        POTATOFieldWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/PotatoField/Sprites/PotatoField_work_anim.png") as
                Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = POTATOFieldIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;

            case "idle_full":
                currentAnim = null;
                texture = POTATOFieldIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;

            case "work":
                currentAnim = POTATOFieldWorkAnim;
                texture = POTATOFieldWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 5;
                _billboard.RegionRect = new Rect2(0, POTATOFieldWorkAnimRegion[rotationIndex], 960, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}