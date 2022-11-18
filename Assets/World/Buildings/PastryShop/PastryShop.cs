using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PastryShop : Building
{
    private Texture PASTRYShopIdle;

    public Array<Texture> PASTRYShopWorkAnim;

    public new void _Ready()
    {
        PASTRYShopIdle = GD.Load("res://Assets/World/Buildings/Bakery/Sprites/Bakery_idle.png") as Texture;

        PASTRYShopWorkAnim = new Array<Texture>
        {
            GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_45.png") as Texture,
            GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_135.png") as Texture,
            GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_225.png") as Texture,
            GD.Load("res://Assets/World/Buildings/PastryShop/Sprites/PastryShop_work_315.png") as Texture,
        };
    }

    public void Animate()
    {
        switch (action)
        {
            case "idle":
                currentAnim = null;
                texture = PASTRYShopIdle;
                _billboard.Vframes = 2;
                _billboard.Hframes = 2;
                _billboard.RegionEnabled = false;
                break;

            case "work":
                currentAnim = PASTRYShopWorkAnim;
                texture = PASTRYShopWorkAnim[rotationIndex];
                _billboard.Vframes = 4;
                _billboard.Hframes = 4;
                _billboard.RegionEnabled = false;

                _billboard.Frame = NextFrame();
                break;
        }

        base.Animate();
    }
}
