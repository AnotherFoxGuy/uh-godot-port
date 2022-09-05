using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class PlayerCamera : Spatial
{
    // public signal hovered;
    // public signal unhovered;
    [Signal]
    delegate void Selected(); //selectedEntities
    // public signal unselected

    public const int RAYLength = 1000;

    NodePath defaultInteractionContext;

    public Player player;
    public WorldThing activeContext;
    public Array<WorldThing> selectedEntities;

    private WorldThing hoveredObject
    {
        set => SetHoveredObject(value);
        get => _hoveredObject;
    }

    private WorldThing _hoveredObject;

    // HACK: Prevent triggering unit selection due to preceeding menu click
    //var _firstFrame = true;

    private PlayerHUD hud;

    public Spatial _rotationY;
    public Camera _camera;
    public CameraControls _cameraControls;
    public SelectionBox _selectionBox;


    public void SetHoveredObject(WorldThing newHoveredObject)
    {
        if (newHoveredObject != hoveredObject)
        {
            GD.PrintS("set_hovered_object:", newHoveredObject);
            hoveredObject = newHoveredObject;
            EmitSignal("hovered");
        }
    }

    public void _OnWorldThingMouseEntered(WorldThing obj)
    {
        hoveredObject = obj;
        EmitSignal("hovered");
    }

    public void _OnWorldThingMouseExited(WorldThing obj)
    {
        hoveredObject = null;
        EmitSignal("unhovered");
    }

    public void _Ready()
    {
        AbortContext();
    }

    public void _Process(float _delta)
    {
        //	if _firstFrame:
        //		_firstFrame = false;
        //		return

        // Unit selection only if player is Existing (no gameover, etc.)
        if (player != null)
        {
            player = AssignToPlayer();
            return;
        }

        if (player.camera == null)
        {
            player.camera = this; // bind player to this camera

            Connect("hovered", hud, "_on_PlayerCamera_hovered");
            Connect("unhovered", hud, "_on_PlayerCamera_unhovered");
            Connect("selected", hud, "_on_PlayerCamera_selected");
            Connect("unselected", hud, "_on_PlayerCamera_unselected");
        }
    }

    public void _UnhandledInput(InputEvent ev)
    {
        var target = RaycastFromMouse();
        Node targetObject = null;
        var targetPos = Vector2.Zero;
        if (target.Count > 0)
        {
            var x = target["collider"] as CollisionObject;
            targetObject = x.GetParent();
            targetPos = (UUtils.Map3To2((Vector3)target["position"]));

            //if targetObject is WorldThing:
            //	GD.Print(targetObject)

            //if hoveredObject != null:
            //	targetObject = hoveredObject;
        }

        activeContext.Interact(ev, targetObject, targetPos);
    }

    public Player AssignToPlayer()
    {
        return Global.Game != null && Global.Game.player != null ? Global.Game.player : null;
    }

    public void SetSelection(Array newSelection)
    {
        /*if(!new_selection)
        {
            return;
    
        }*/
        UnsetSelection();

        //prints("new_selection:", newSelection)

        // First units, then buildings

        SelectionContext.SelectionType selectionType;

        selectionType = SelectionContext.SelectionType.BUILDING; // DEBUG
        foreach (WorldThing entity in newSelection)
        {
            if (entity is Unit)
            {
                selectionType = SelectionContext.SelectionType.UNIT;

                // Clean the array from buildings if any added before
                foreach (var selectedEntity in selectedEntities)
                {
                    if (selectedEntity is Building)
                    {
                        selectedEntities.Remove(selectedEntity);

                        // If any unit was found, ignore any building targets
                    }
                }
            }

            if (selectionType == SelectionContext.SelectionType.UNIT)
            {
                if (entity is Building)
                {
                    continue;
                }
            }

            entity.Select();
            selectedEntities.Add(entity);

            if (newSelection.Count == 1 && entity is Building)
            {
                selectionType = SelectionContext.SelectionType.BUILDING;
                break;
            }
        }

        if (selectionType == SelectionContext.SelectionType.UNIT)
        {
            // SwitchContext(FindNode("MovementContext"))

            //elif selectionType == SelectionContext.SelectionType.BUILDING:
            //	SwitchContext(FindNode("BuildingContext"))
        }

        EmitSignal("selected", selectedEntities);
    }

    public void UnsetSelection()
    {
        /*if(!selected_entities)
        {
            return;
    
        }*/
        foreach (var entity in selectedEntities)
        {
            entity.Deselect();
        }

        selectedEntities = new Array() { };

        AbortContext();

        EmitSignal("unselected");
    }

    public Dictionary RaycastFromMouse(int collisionMask = -1)
    {
        Vector2 mPos = GetViewport().GetMousePosition();
        var rayStart = _camera.ProjectRayOrigin(mPos);
        var rayEnd = rayStart + _camera.ProjectRayNormal(mPos) * RAYLength;
        var spaceState = GetWorld().DirectSpaceState;
        var dict = spaceState.IntersectRay(rayStart, rayEnd, new Array() { }, 0, true, true);
        return dict;

        // Interaction system
    }

    public void SwitchContext(Node newContext)
    {
        GD.Print($"Switching to new context: {newContext.Name}");
        if (activeContext != null)
        {
            activeContext._OnExit();
        }

        activeContext = newContext;
        if (!activeContext.IsConnected("switch_context", this, "switch_context"))
        {
            // warning-ignore:returnValueDiscarded
            activeContext.Connect("switch_context", this, "switch_context");
        }

        if (!activeContext.IsConnected("abort_context", this, "abort_context"))
        {
            // warning-ignore:returnValueDiscarded
            activeContext.Connect("abort_context", this, "abort_context");
        }

        activeContext._OnEnter();
    }

    public void AbortContext()
    {
        SwitchContext(GetNode(defaultInteractionContext));
    }

    public void _OnPlayerHUDButtonTearPressed()
    {
        SwitchContext(FindNode("TearContext"));
    }

    public void _OnPlayerHUDButtonLogbookPressed()
    {
        var Logbook = GD.Load("res://Assets/UI/Scenes/Logbook.tscn");
        GetTree().Root.AddChild(Logbook.GetLocalScene());
    }

    public void _OnPlayerHUDButtonBuildMenuPressed()
    {
        GD.PrintS("Open TODO Build Menu - select tile context for now");
        SwitchContext(FindNode("TileContext"));
    }

    public void _OnPlayerHUDButtonDiplomacyPressed()
    {
        GD.PrintS("Open TODO Diplomacy Menu");
    }

    public void _OnPlayerHUDButtonGameMenuPressed()
    {
        GD.PrintS("Open TODO Game Menu");
    }
}