
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class BalanceInfoItem : HBoxContainer
{
	 
	enum BalanceType {
		EXPENSE,
		INCOME,
		BUY,
		SELL,
		RESULT,
	
		SHIPS,
		TOOLS,
		WEAPONS
	}
	
	public static readonly Array BALANCETypes = new Array(){
		GD.Load("res://Assets/UI/Images/ResbarStats/expense.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/income.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/buy.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/sell.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/scales_icon.png"),
	
		GD.Load("res://Assets/UI/Images/ResbarStats/ship_icon.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/tools_icon.png"),
		GD.Load("res://Assets/UI/Images/ResbarStats/weapons_icon.png")
	};
	
	Export(BalanceType) var balanceType {set{SetBalanceType(value);}}
	Export(int) var balanceValue {set{SetBalanceValue(value);}}
	
	onready var textureRect = $TextureRect
	onready var label = $LabelEx
	
	public async void SetBalanceType(int newBalanceType)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
		if(textureRect == null)
			 textureRect = $TextureRect
	
		balanceType = newBalanceType;
		textureRect.texture = BALANCETypes[balanceType];
	
	}
	
	public async void SetBalanceValue(int newBalanceValue)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
		if(label == null)
			 label = $LabelEx
	
		balanceValue = newBalanceValue;
	
		string balanceSign = "";
		if(balanceValue >= 0)
		{
			balanceSign = "+";
	
		}
		label.text = "{0}{1}".Format(new Array(){balanceSign, balanceValue});
	
	
	}
	
	
	
}