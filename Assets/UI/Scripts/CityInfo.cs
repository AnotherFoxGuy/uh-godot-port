
using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CityInfo : HBoxContainer
{
	// Info widget displaying generic information about the hovered city.

	public static readonly Array<Texture> FACTIONSettlement = new Array<Texture>(){
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement.png"), // neutral
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_red.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_blue.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_dark_green.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_orange.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_purple.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_cyan.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_yellow.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_pink.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_teal.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_lime_green.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_bordeaux.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_white.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_gray.png"),
		GD.Load<Texture>("res://Assets/UI/Icons/Widgets/CityInfo/settlement_black.png"),
	};

	[Export]Global.Faction faction  {set{SetFaction(value);}}
	private Global.Faction _faction;
	[Export] bool debugCycleFactions  {set{DebugSetCycleFactions(value);}}
	private bool _debugCycleFactions;
	
	// onready var factionSettlement  = $SettlementName/FactionSettlement
	private Spatial factionSettlement;
	// onready var animationPlayer  = $AnimationPlayer
	private AnimationPlayer animationPlayer;

	private Timer _timer;
	
	public void _Ready()
	{
		if(!Engine.IsEditorHint())
		{
			Visible = false;
	
		}
	}
	
	public async void SetFaction(Global.Faction newFaction)
	{
		if (!IsInsideTree())
			await ToSignal(this, "ready");
	
		_faction = newFaction;
		factionSettlement.Texture = FACTIONSettlement[_faction];
	
		PropertyListChangedNotify();
	
	}
	
	public async void DebugSetCycleFactions(bool newDebugCycleFactions)
	{
		if (!IsInsideTree())
			await ToSignal(this, "ready");
	
		_debugCycleFactions = newDebugCycleFactions;
		if(_debugCycleFactions)
		{
			_timer.Start();
		}
		else
		{
			_timer.Stop();

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
		_faction = (Global.Faction)Mathf.Wrap((int)(_faction + 1), 0, FACTIONSettlement.Count);
	
	}
	
	public void _OnAnimationPlayerAnimationStarted(String animName)
	{  
		switch( animName)
		{
			case "fade_in":
				Visible = true;
				break;
	
		}
	}
	
	public void _OnAnimationPlayerAnimationFinished(String animName)
	{  
		switch( animName)
		{
			case"fade_out": 
				Visible = false;
				break;
	
		}
	}
	
	
	
}