using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MovementContext : SelectionContext
{
    private PlayerCamera _playerCamera;

    public void MoveSelectedUnits(Vector2 mPos)
    {
        var result = _playerCamera.RaycastFromMouse();
        if (result.Count > 0)
        {
            GD.Print($"Move Command selected units {result} ");
            foreach (var unit in _playerCamera.selectedEntities)
            {
                if (unit.Faction == _playerCamera.player.faction)
                {
                    unit.MoveTo(Utils.Map3To2((Vector3)result["position"]));
                }
            }
        }
    }

    public void _OnIaMainCommandPressed(Node target, Vector2 position)
    {
        //print_debug("Move action")

        var mPos = GetViewport().GetMousePosition();
        MoveSelectedUnits(mPos);
    }
}