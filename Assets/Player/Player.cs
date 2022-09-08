using Godot;
using Godot.Collections;

public class Player : Control
{
    public Global.Faction faction = Global.Faction.NONE;

    public Array settlements = new Array();
    public static Array<Ship> ships = new Array<Ship>();

    public PlayerCamera camera;

    //warning-ignore-all:unusedClassVariable

    public void _Ready()
    {
        /*PrintDebug(
            "I'm {0} in faction {1} (new Dictionary(){2}).".Format(
                    [Config.player_name, faction, Global.FACTIONS[faction]]);
            );*/
    }

    public void _OnGameNotification(int messageType, string messageText)
    {
        if (camera == null) return;
        var hud = camera.GetNode("PlayerHUD") as PlayerHUD;
        hud?.RaiseNotification(messageType, messageText);
    }
}