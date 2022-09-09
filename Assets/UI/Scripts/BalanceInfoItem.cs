using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BalanceInfoItem : HBoxContainer
{
    public enum BalanceType
    {
        EXPENSE,
        INCOME,
        BUY,
        SELL,
        RESULT,

        SHIPS,
        TOOLS,
        WEAPONS
    }

    public static readonly Array<Texture> BALANCETypes = new Array<Texture>()
    {
        GD.Load("res://Assets/UI/Images/ResbarStats/expense.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/income.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/buy.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/sell.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/scales_icon.png") as Texture,

        GD.Load("res://Assets/UI/Images/ResbarStats/ship_icon.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/tools_icon.png") as Texture,
        GD.Load("res://Assets/UI/Images/ResbarStats/weapons_icon.png") as Texture
    };

    [Export]
    BalanceType balanceType
    {
        set => SetBalanceType(value);
        get => _balanceType;
    }

    private BalanceType _balanceType;

    [Export]
    int balanceValue
    {
        set => SetBalanceValue(value);
        get => _balanceValue;
    }

    private int _balanceValue;

    TextureRect textureRect; // = $TextureRect
    LabelEx label; //= $LabelEx

    public async void SetBalanceType(BalanceType newBalanceType)
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");
        // if(textureRect == null)
        // 	 textureRect = $TextureRect

        _balanceType = newBalanceType;
        textureRect.Texture = BALANCETypes[(int)_balanceType];
    }

    public async void SetBalanceValue(int newBalanceValue)
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");
        // if(label == null)
        // 	 label = $LabelEx

        _balanceValue = newBalanceValue;

        string balanceSign = "";
        if (_balanceValue >= 0)
        {
            balanceSign = "+";
        }

        label.Text = $"{balanceSign}{_balanceValue}";
    }
}