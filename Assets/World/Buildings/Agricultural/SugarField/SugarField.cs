using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class SugarField : Building
{
    private Texture SUGARFieldIdle;
    private Texture SUGARFieldIdleFull;

    //const SUGARFieldWork45 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_45.png");
    //const SUGARFieldWork135 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_135.png");
    //const SUGARFieldWork225 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_225.png");
    //const SUGARFieldWork315 = GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_315.png");

    //const SUGARFieldWorkAnim = new Array(){
    //	SUGARFieldWork45,
    //	SUGARFieldWork135,
    //	SUGARFieldWork225,
    //	SUGARFieldWork315,
    //};
    private Array<Texture> SUGARFieldWorkAnim;

    public static readonly Array<float> SUGARFieldWorkAnimRegionY = new Array<float>()
    {
        0, 192, 384, 576
    };

    public new void _Ready()
    {
        SUGARFieldIdle =
            GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_idle.png") as Texture;
        SUGARFieldIdleFull =
            GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_idle_full.png") as Texture;

        SUGARFieldWorkAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Buildings/Agricultural/SugarField/Sprites/SugarField_work_anim.png") as Texture
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = SUGARFieldIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "idle_full":
                currentAnim = null;
                texture = SUGARFieldIdleFull;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionRect = new Rect2(0, 0, 384, 384);
                _billboard.RegionEnabled = true;
                break;
            case "work":
                currentAnim = SUGARFieldWorkAnim;
                texture = SUGARFieldWorkAnim[0];
                _billboard.Vframes = 1;
                _billboard.Hframes = 5;
                _billboard.RegionRect = new Rect2(0, SUGARFieldWorkAnimRegionY[rotationIndex], 960, 192);
                _billboard.RegionEnabled = true;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}