using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class TileContext : InteractionContext
{
    [Signal]
    delegate void TilesChanged(Array scaffoldTiles, bool canBuilt);

    public Texture PHANTOMTileTexture;

    private TileMap3D streets;

    public Vector2 mPos;

    public Sprite3D phantomTile;

    public Vector2 lastTilePos;

    public bool isDrawing = false;
    public Array<Vector2> drawPath = new Array<Vector2>() { };
    public bool aborted = false;

    public void _Ready()
    {
        PHANTOMTileTexture = GD.Load("res://Assets/World/Buildings/Streets/Sprites/trail_single.png") as Texture;
        streets = GetNode("/root/World/AStarMap/Streets") as TileMap3D;
        SetProcess(false);
    }

    public void ShowPhantomTile(Vector2 tilePos)
    {
        phantomTile.Translation = streets.MapToWorld((int)(tilePos.x), 0, (int)tilePos.y);
    }

    public void HandleTiles(Vector2 raycastPosition)
    {
        var tilePos = streets.WorldToTilemap(raycastPosition);
        //var tileItem = streets.GetTileItem(tilePos);
        //var meshLibrary = streets.mesh_library;
        //var itemName = meshLibrary.GetItemName(tileItem);

        GD.PrintS("tile pos:", tilePos);
        //prints("tile item:", tileItem)
        //prints("mesh_library:", meshLibrary.resource_name)
        //prints("item_mesh:", itemName)

        //prints("orientation:", streets.GetTileItemOrientation(tilePos))
    }

    public void _OnEnter()
    {
        GD.Print($"InteractionContext {_contextName} entered");
        var material = new SpatialMaterial();
        material.FlagsTransparent = true;
        material.FlagsNoDepthTest = true;
        material.ParamsBillboardMode = SpatialMaterial.BillboardMode.Enabled;
        material.AlbedoTexture = PHANTOMTileTexture;

        phantomTile = new Sprite3D();
        phantomTile.Texture = PHANTOMTileTexture;
        phantomTile.PixelSize = 0.02f;
        phantomTile.MaterialOverride = material;
        AddChild(phantomTile);
        Input.SetCustomMouseCursor(Cursor.CURSORTear, Input.CursorShape.Arrow);

        Connect("tiles_changed", streets, "update_tiles");

        SetProcess(true);
    }

    public void _OnExit()
    {
        GD.Print($"InteractionContext {_contextName} exited");
        phantomTile.QueueFree();
        Input.SetCustomMouseCursor(Cursor.CURSORDefault, Input.CursorShape.Arrow);

        SetProcess(false);
    }

    public void _Process(float _delta)
    {
        mPos = _playerCamera.GetViewport().GetMousePosition();

        var tilePos = streets.GetTileAtMousePosition();

        if (tilePos == lastTilePos)
        {
            return;
        }

        ShowPhantomTile(tilePos);

        if (isDrawing)
        {
            //print_debug("Check if tiling is executed on valid terrain")
            if (drawPath.Count >= 4 && tilePos == drawPath[-4] ||
                streets.GetUsedTiles().Contains(tilePos)) // free tile?
            {
                GD.PrintS(tilePos);
                drawPath.Add(tilePos);
                streets.SetTileItem(tilePos, 0);
                EmitSignal("tiles_changed", drawPath);
            }
            else // occupied cell
            {
                if (drawPath.Count > 1)
                {
                    if (tilePos == drawPath[-2])
                    {
                        // drawPath.Remove(drawPath.Count - 1);
                        var cellToBeRemoved = drawPath[drawPath.Count - 1];
                        drawPath.Remove(cellToBeRemoved);
                        if (drawPath.Contains(cellToBeRemoved))
                        {
                            streets.SetTileItem(cellToBeRemoved, -1);
                        }

                        EmitSignal("tiles_changed", drawPath);

                        //prints("tile_pos:", tilePos, "last_tile_pos:", lastTilePos)
                    }
                }
            }
        }

        lastTilePos = tilePos;
        //prints(" === drawPath:", drawPath)
    }

    public void _OnMouseMotion(Node target, Vector2 position)
    {
    }

    public void _OnIaAltCommandPressed(Node target, Vector2 position)
    {
        if (!is_drawing)
        {
            GD.Print("Start tiling");
            isDrawing = true;
            lastTilePos.y = -1;
        }
        else
        {
            GD.Print("End tiling");
            isDrawing = false;
            drawPath = new Array<Vector2>() { };
            EmitSignal("tiles_changed");
        }
    }

    public void _OnIaAltCommandReleased(Node target, Vector2 position)
    {
        if (aborted)
        {
            GD.Print("End Tiling (aborted)");
            aborted = false;
            return;

            //	if !is_drawing:
            //		AbortContext()
        }
    }

    public void _OnIaMainCommandPressed(Node target, Vector2 position)
    {
    }

    public void _OnIaMainCommandReleased(Node target, Vector2 position)
    {
        GD.Print("Abort tiling");
        foreach (var cellPos in drawPath)
        {
            streets.UnsetTile(cellPos);
        }

        if (isDrawing)
        {
            isDrawing = false;
        }
        else
        {
            AbortContext();
        }

        drawPath = new Array<Vector2>() { };
        aborted = true;
        EmitSignal("tiles_changed");
    }
}