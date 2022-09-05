using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class InteractionContext : Node
{
    // Template for different behavior states within the interaction system.
    // It is meant to be inherited from && !to be instanced directly.
    //
    // PlayerCamera will keep track of one active InteractionContext at a time
    // && will pass any unhandled InputEvents to it.
    // E.g., a build menu could invoke a switch to its own InteractionContext
    // to handle the display of ghost buildings && later the placement of actual buildings.
    // If a military unit is selected, the system could swap to an InteractionContext
    // responsible for military commands, etc.
    //
    // Each InteractionContext is responsible for setting inputs
    // as handled themselves if so desired.
    //
    // Per default, any InteractionContext can emit two different signals:
    //	switchContext - This signal causes the interaction system to switch its
    //					 active InteractionContext to the one provided as parameter.
    //	abortContext - This signal causes the interaction system to revert to the
    //					default Context (probably selection mode)
    //
    // The PoolStringArray 'valid_actions' contains the names of all possible
    // action names. These are the same names as they would be used with
    // InputEvent.IsAction().
    // Each of these actions will be routed to a method identified by its name.
    // The method should be constructed as follows:
    //	func _onIa<action name>_<pressed|released>(
    //		target: Node,
    //		position: Vector2
    //		) -> void
    //
    // Spaces in the action name will be replaced by underscores
    // ('action name' will become _OnIaActionNamePressed()
    //  || _OnIaActionNameReleased())
    //
    // A notable exception to this is the method:
    //	func _OnMouseMotion(
    //		target: Node,
    //		position: Vector2
    //		) -> void
    //
    // All InputEventMouseMotion events will be routed to this function. This can
    // be used to update hover effects, the cursor, etc.

    [Signal]
    delegate void switchContext(string willSendsAString);

    [Signal]
    delegate void abortContext(string willSendsAString);

    // Spatial _playerCamera  = owner;

    internal string _contextName = "Basic Interaction Context";
    Array validActions = new Array() { "main_command" };

    public void Interact(InputEvent ev, Node target, Vector2 position)
    {
        if (ev.IsActionType())
        {
            foreach (string action in validActions)
            {
                if (ev.IsAction(action))
                {
                    String function = _MakeFunctionName(
                        action, ev.IsActionPressed(action));
                    /*if (self.HasMethod(function))
                    {
                        self.Call(function, target, position);
                        return;
                    }*/
                }
            }
        }
        else if (ev is InputEventMouseMotion)
        {
            _OnMouseMotion(target, position);
            return;
        }
    }

    public void AbortContext()
    {
        EmitSignal("abort_context");
        GetTree().SetInputAsHandled();
    }

    public void _OnEnter()
    {
         //print("InteractionContext %s entered" % _contextName)
    }

    public void _OnExit()
    {
         //print("InteractionContext %s exited" % _contextName)
    }

    public void _OnMouseMotion(Node target, Vector2 position)
    {
    }

    public void _OnIaMainCommandPressed(Node target, Vector2 position)
    {
        AbortContext();
    }

    public String _MakeFunctionName(String action, bool pressed = true)
    {
        String funcName = action.Replace(" ", "_");
        funcName = "_on_ia_" + funcName;
        if (pressed)
        {
            funcName += "_pressed";
        }
        else
        {
            funcName += "_released";
        }

        return funcName;
    }
}