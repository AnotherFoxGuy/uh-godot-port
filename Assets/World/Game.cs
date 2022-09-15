using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Game : Spatial
{
    [Signal]
    delegate void Notification(int messageType, string messageText);

    public bool isGameRunning = false;

    public Spatial playerStart = null;

    public Player player = null;
    //var players := new Array(){Player}

    public Array<Global.Faction> aiPlayers = new Array<Global.Faction>() { };

    public void _Ready()
    {
        Global.Game = this;
        playerStart = Global.PlayerStart;

        GD.Randomize();
        GD.PrintS("[New Game]");
        Audio.Instance.PlayEntrySnd();
    }

    public void _Process(float _delta)
    {
        if (!isGameRunning)
        {
            StartGame();

            // Notification Test (press N within a game session)
        }
    }

    public void _Input(InputEvent ev)
    {
        if (ev.IsActionPressed("debug_raise_notification"))
        {
            EmitSignal("notification", 3, "This is a test notification.");
        }
    }

    public void StartGame()
    {
        if (playerStart != null)
        {
            player = new Player();
            player.faction = Global.faction;

            AddChild(player);
            // warning-ignore:returnValueDiscarded
            Connect("notification", player, "_on_Game_notification");

            // Assign player starter ship
            var ships = Player.ships;
            ships[(int)(GD.Randi() % ships.Count)].faction = player.faction;

            Array<Global.Faction> factions = new Array<Global.Faction>();
            factions.Remove(player.faction); // remove occupied faction from array

            // Assign AI starter ships
            aiPlayers.Resize(Global.Instance.aiPlayers);
            if (aiPlayers.Count > 0)
                GD.Print("ai_player", "ship");
            foreach (var aiPlayer in GD.Range(aiPlayers.Count))
            {
                aiPlayers[aiPlayer] = factions[(int)(GD.Randi() % factions.Count)]; // assign random faction to AI player
                factions.Remove(aiPlayers[aiPlayer]); // remove occupied faction from array

                foreach (var ship in ships)
                {
                    if (ship.faction == Global.Faction.NONE)
                    {
                        ship.faction = aiPlayers[aiPlayer];
                        GD.Print(aiPlayers[aiPlayer], ship.Name);
                        break;

                        // Remove any ships left over
                    }
                }
            }

            foreach (var ship in ships)
            {
                if (ship.faction == Global.Faction.NONE)
                {
                    ship.QueueFree();

                    // Traders
                }
            }

            if (!Global.Instance.hasTraders)
            {
                var traders = GetNode("Traders");
                if (traders != null)
                {
                    traders.QueueFree();

                    // Pirates
                }
            }

            if (!Global.Instance.hasPirates)
            {
                var pirates = GetNode("Pirates");
                if (pirates != null)
                {
                    pirates.QueueFree();

                    // Disasters
                }
            }

            if (!Global.Instance.hasDisasters)
            {
                return; // TODO
            }
        }

        isGameRunning = true;
    }
}