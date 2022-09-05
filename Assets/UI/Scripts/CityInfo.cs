
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CityInfo : HBoxContainer
{
	 
	// Info widget displaying generic information about the hovered city.
	
	public const var Global = GD.Load("res://Assets/World/Global.gd");
	
	public static readonly Array FACTIONSettlement = new Array(){
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement.png"), // neutral
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_red.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_blue.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_dark_green.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_orange.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_purple.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_cyan.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_yellow.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_pink.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_teal.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_lime_green.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_bordeaux.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_white.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_gray.png"),
		GD.Load("res://Assets/UI/Icons/Widgets/CityInfo/settlement_black.png")
	};
	
	Export(Global.Faction) int faction  = 0 {set{SetFaction(value);}}
	Export(bool) bool debugCycleFactions  = false {set{DebugSetCycleFactions(value);}}
	
	onready var factionSettlement  = $SettlementName/FactionSettlement
	onready var animationPlayer  = $AnimationPlayer
	
	public void _Ready()
	{  
		if(!Engine.IsEditorHint())
		{
			visible = false;
	
		}
	}
	
	public async void SetFaction(int newFaction)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
	
		faction = newFaction;
		factionSettlement.texture = FACTIONSettlement[faction];
	
		PropertyListChangedNotify();
	
	}
	
	public async void DebugSetCycleFactions(bool newDebugCycleFactions)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
	
		debugCycleFactions = newDebugCycleFactions;
		if(debugCycleFactions)
		{
			$Timer.Start()
		}
		else
		{
			$Timer.Stop()
	
		}
	}
	
	public void Show()
	{  
		if(animationPlayer.IsPlaying())
		{
			animationPlayer.Stop(false);
		}
		animationPlayer.Play("fade_in");
	
	}
	
	public void Hide()
	{  
		if(animationPlayer.IsPlaying())
		{
			animationPlayer.Stop(false);
		}
		animationPlayer.PlayBackwards("fade_in");
	
	}
	
	public void _OnTimerTimeout()
	{  
		self.faction = Mathf.Wrap(faction + 1, 0, FACTIONSettlement.Size());
	
	}
	
	public void _OnAnimationPlayerAnimationStarted(String animName)
	{  
		switch( animName)
		{
			{"fade_in",
				visible = true;
	
		}
	}}
	
	public void _OnAnimationPlayerAnimationFinished(String animName)
	{  
		switch( animName)
		{
			{"fade_out",
				visible = false;
	
	
		}
	}}
	
	
	
}