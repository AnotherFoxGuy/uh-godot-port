
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Game : Spatial
{
	 
	[Signal] delegate void Notification(messageType, messageText);// int, String
	
	public bool isGameRunning = false;
	
	public Spatial playerStart = null;
	public Player player = null;
	//var players := new Array(){Player}
	
	public Array aiPlayers = new Array(){};
	
	public void _Ready()
	{  
		Global.Game = this;
		playerStart = Global.PlayerStart;
	
		GD.Randomize();
		GD.PrintS("[New Game]");
		Audio.PlayEntrySnd();
	
	}
	
	public void _Process(float _delta)
	{  
		if(!is_game_running)
		{
			StartGame();
	
	// Notification Test (press N within a game session)
		}
	}
	
	public void _Input(InputEvent event)
	{  
		if(event.IsActionPressed("debug_raise_notification"))
		{
			EmitSignal("notification", 3, "This is a test notification.");
	
		}
	}
	
	public void StartGame()
	{  
		if(playerStart)
		{
			player = new Player()
			player.faction = Global.faction;
	
			AddChild(player);
			// warning-ignore:returnValueDiscarded
			Connect("notification", player, "_on_Game_notification");
	
			// Assign player starter ship
			var ships = playerStart.ships;
			ships[(GD.Randi() % ships.Size())].faction = player.faction;
	
			Array factions = GD.Range(1, 15);
			factions.Remove(factions.Find(player.faction)) ;// remove occupied faction from array
	
			// Assign AI starter ships
			aiPlayers.Resize(Global.ai_players);
			if(aiPlayers.Size() > 0)
				 Printt("ai_player", "ship");
			foreach(var aiPlayer in GD.Range(aiPlayers.Size()))
			{
				aiPlayers[aiPlayer] = factions[GD.Randi() % factions.Size()] ;// assign random faction to AI player
				factions.Remove(factions.Find(aiPlayers[aiPlayer])) ;// remove occupied faction from array
	
				foreach(var ship in ships)
				{
					if(ship.faction == Global.Faction.NONE)
					{
						ship.faction = aiPlayers[aiPlayer];
						Printt(aiPlayers[aiPlayer], ship.name);
						break;
	
			// Remove any ships left over
					}
				}
			}
			foreach(var ship in ships)
			{
				if(ship.faction == Global.Faction.NONE)
				{
					ship.QueueFree();
	
			// Traders
				}
			}
			if(!Global.has_traders)
			{
				var traders  = GetNode("Traders");
				if(traders != null)
				{
					traders.QueueFree();
	
			// Pirates
				}
			}
			if(!Global.has_pirates)
			{
				var pirates  = GetNode("Pirates");
				if(pirates != null)
				{
					pirates.QueueFree();
	
			// Disasters
				}
			}
			if(!Global.has_disasters)
			{
				pass ;// TODO
	
			}
		}
		isGameRunning = true;
	
	
	}
	
	
	
}