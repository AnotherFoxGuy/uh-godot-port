using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class SelectionContext : InteractionContext
{
    [Signal]
    delegate void Selected(Array newSelection); // Array
    // public signal deselected

    public enum SelectionType
    {
        UNIT,
        BUILDING,
    }

    Node _parent;

    [Export] int selectionTolerance = 10;

    public Vector2 selPosStart;
    public Vector2 selPosEnd;

    public void _Ready()
    {
        _parent = GetParent();
    }

    public Array GetSelectedUnits(Vector2 topLeft, Vector2 bottomRight)
    {
        if (topLeft.x > bottomRight.x)
        {
            var tmp = topLeft.x;
            topLeft.x = bottomRight.x;
            bottomRight.x = tmp;
        }

        if (topLeft.y > bottomRight.y)
        {
            var tmp = topLeft.y;
            topLeft.y = bottomRight.y;
            bottomRight.y = tmp;
        }

        Rect2 box = new Rect2(topLeft, bottomRight - topLeft);
        Array selectedUnits = new Array() { };
        foreach (Unit unit in GetTree().GetNodesInGroup("units"))
        {
            if (unit.faction == Game.player.faction)
            {
                var unitPos = GetViewport().GetCamera().UnprojectPosition(unit.GlobalTransform.origin);
                if (box.HasPoint(unitPos))
                {
                    GD.Print($"Selected unit: {unit.Name}");
                    selectedUnits.Add(unit);
                }
            }
        }

        return selectedUnits;
    }

    public void _OnIaAltCommandPressed(Node target, Vector2 position)
    {
        // Start selection
        //print_debug("Start selection")
        selPosStart = position;

        _parent.sel_pos_start = GetViewport().GetMousePosition();
        _parent.Show();
    }

    public void _OnIaAltCommandReleased(Node target, Vector2 position)
    {
        // End selection
        //print_debug("End selection")

        if (!_parent.visible)
        {
            return;
        }

        selPosEnd = position;
        Array selection = null;
        Vector2 topLeft = GetViewport().GetCamera().UnprojectPosition(Utils.Map2To3(selPosStart));
        Vector2 bottomRight = GetViewport().GetCamera().UnprojectPosition(Utils.Map2To3(selPosEnd));
        if (topLeft.DistanceTo(bottomRight) <= selectionTolerance)
        {
            if (target != null && target is Unit || target is Building) //target.IsInGroup("units"):
            {
                selection = new Array() { target };
            }
        }
        else
        {
            selection = GetSelectedUnits(topLeft, bottomRight);
        }

        _parent.Hide();

        if (selection != null)
        {
            EmitSignal("selected", selection);
        }
        else
        {
            EmitSignal("deselected");
        }
    }

    public void _OnIaMainCommandPressed(Node target, Vector2 position)
    {
        // Abort selection
        //print_debug("Abort selection")
        _parent.Hide();
    }
}