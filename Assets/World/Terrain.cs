using System;
using System.Linq;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Terrain : TileMap3D
{
    // mapSize = 1;
    // xx
    // xx
    //
    // mapSize = 2;
    // xxxx
    // xxxx
    // xxxx
    // xxxx

    public const int TILESPerSize = 4;
    public const int TILESPerAxis = TILESPerSize / 2;

    public static readonly Array DEFAULTLand = new Array() { 3, "straight", 45 };
    public static readonly Array SAND = new Array() { 6, "straight", 45 };
    public static readonly Array SHALLOWWater = new Array() { 1, "straight", 45 };
    public static readonly Array WATER = new Array() { 0, "straight", 45 };

    // sand to shallow water tiles
    public static readonly Array COASTSouth = new Array() { 5, "straight", 45 };
    public static readonly Array COASTEast = new Array() { 5, "straight", 135 };
    public static readonly Array COASTNorth = new Array() { 5, "straight", 225 };
    public static readonly Array COASTWest = new Array() { 5, "straight", 315 };
    public static readonly Array COASTSouthwest3 = new Array() { 5, "curve_in", 135 };
    public static readonly Array COASTNorthwest3 = new Array() { 5, "curve_in", 225 };
    public static readonly Array COASTNortheast3 = new Array() { 5, "curve_in", 315 };
    public static readonly Array COASTSoutheast3 = new Array() { 5, "curve_in", 45 };
    public static readonly Array COASTNortheast1 = new Array() { 5, "curve_out", 225 };
    public static readonly Array COASTSoutheast1 = new Array() { 5, "curve_out", 135 };
    public static readonly Array COASTSouthwest1 = new Array() { 5, "curve_out", 45 };
    public static readonly Array COASTNorthwest1 = new Array() { 5, "curve_out", 315 };

    // grass to sand tiles
    public static readonly Array SANDSouth = new Array() { 4, "straight", 45 };
    public static readonly Array SANDEast = new Array() { 4, "straight", 135 };
    public static readonly Array SANDNorth = new Array() { 4, "straight", 225 };
    public static readonly Array SANDWest = new Array() { 4, "straight", 315 };
    public static readonly Array SANDSouthwest3 = new Array() { 4, "curve_in", 135 };
    public static readonly Array SANDNorthwest3 = new Array() { 4, "curve_in", 225 };
    public static readonly Array SANDNortheast3 = new Array() { 4, "curve_in", 315 };
    public static readonly Array SANDSoutheast3 = new Array() { 4, "curve_in", 45 };
    public static readonly Array SANDNortheast1 = new Array() { 4, "curve_out", 225 };
    public static readonly Array SANDSoutheast1 = new Array() { 4, "curve_out", 135 };
    public static readonly Array SANDSouthwest1 = new Array() { 4, "curve_out", 45 };
    public static readonly Array SANDNorthwest1 = new Array() { 4, "curve_out", 315 };

    // shallow water to deep water tiles
    public static readonly Array DEEPWaterSouth = new Array() { 2, "straight", 45 };
    public static readonly Array DEEPWaterEast = new Array() { 2, "straight", 135 };
    public static readonly Array DEEPWaterNorth = new Array() { 2, "straight", 225 };
    public static readonly Array DEEPWaterWest = new Array() { 2, "straight", 315 };
    public static readonly Array DEEPWaterSouthwest3 = new Array() { 2, "curve_in", 135 };
    public static readonly Array DEEPWaterNorthwest3 = new Array() { 2, "curve_in", 225 };
    public static readonly Array DEEPWaterNortheast3 = new Array() { 2, "curve_in", 315 };
    public static readonly Array DEEPWaterSoutheast3 = new Array() { 2, "curve_in", 45 };
    public static readonly Array DEEPWaterNortheast1 = new Array() { 2, "curve_out", 225 };
    public static readonly Array DEEPWaterSoutheast1 = new Array() { 2, "curve_out", 135 };
    public static readonly Array DEEPWaterSouthwest1 = new Array() { 2, "curve_out", 45 };
    public static readonly Array DEEPWaterNorthwest1 = new Array() { 2, "curve_out", 315 };

    //current_coords_set: new Dictionary(){(0, 0)}
    //current_coords_set: new Dictionary(){(0, 1), (1, 0), (0, 0), (1, 1)}

    public static readonly Array TILEOffsets = new Array()
    {
        // Direct connections
        new Vector2(0, -1), // East
        new Vector2(+1, 0), // North
        new Vector2(0, +1), // South
        new Vector2(-1, 0), // West
        // Remote connections
        new Vector2(+1, -1), // North West
        new Vector2(+1, +1), // North East
        new Vector2(-1, +1), // South East
        new Vector2(-1, -1), // South West
    };

    public Array<Vector2> tileMap;

    [Export] public bool btnUpdateTiles = false;
    [Export] public bool btnFillTerrain = false;
    [Export] public bool btnUnfillTerrain = false;
    [Export] public bool btnCleanTerrain = false;

    public async void _Ready()
    {
        //if GetParent().IsInsideTree(): await ToSignal(GetParent(), "ready"); _OnReady()

        var mapSize = 512; // GetParent().map_size as int;
        _ResizeTileMap(mapSize);

        UpdateTiles();
    }

    public void _Process(float _delta)
    {
        if (Engine.IsEditorHint())
        {
            if (btnUpdateTiles)
            {
                UpdateTiles();
                btnUpdateTiles = false;
            }

            if (btnFillTerrain)
            {
                FillTerrain();
                btnFillTerrain = false;
            }

            if (btnUnfillTerrain)
            {
                UnfillTerrain();
                btnUnfillTerrain = false;
            }

            if (btnCleanTerrain)
            {
                CleanTerrain();
                btnCleanTerrain = false;
            }
        }
        else
        {
            SetProcess(false);
        }
    }

    public void UpdateTiles()
    {
        //print("update_tiles()")
        //for tile in GetUsedTiles():
        //print(tile)

        //for tileNeighbor in TILEOffsets:
        //	GD.Print(tileNeighbor)
    }

    public void FillTerrain()
    {
        GD.Print("fill_terrain");
        foreach (var tilePos in tileMap)
        {
            //print("(new Dictionary(){0}, new Dictionary(){1}) | mapToWorld: new Dictionary(){2}".Format(new Array(){x, y, MapToWorld(x, 0, y)}))
            // NOTEFORME: mapToWorld: center of Cell (e.g. 0, 0 -> 0.5, 0.5)
            SetTile(tilePos, "deep");
        }
    }

    public void UnfillTerrain()
    {
        GD.Print("unfill_terrain");
        foreach (var tilePos in tileMap)
        {
            UnsetTile(tilePos);
        }
    }

    public void CleanTerrain()
    {
        GD.Print("clean_terrain");
        Array<Vector2> tileMap = new Array<Vector2>();
        foreach (var tile in tileMap)
        {
            tileMap.Append(tile);

            //prints("tile_map:", tileMap)
        }

        foreach (var tile in GetUsedTiles())
        {
            // Vector2 tile = new Vector2(cell.x, cell.z);
            //	if !tile in tileMap:
            //		UnsetTile(tile)
            if (tileMap.Contains(tile))
            {
                UnsetTile(tile);
            }
        }
    }

    public void _ResizeTileMap(int mapSize)
    {
        tileMap = new Array<Vector2>();
        for (int y = 0; y < mapSize * TILESPerAxis; y++)
        {
            for (int x = 0; x < mapSize * TILESPerAxis; x++)
            {
                tileMap.Append(new Vector2(x, y));
            }
        }
    }

    public void _OnAStarMapMapSizeChanged(int newMapSize)
    {
        var mapSize = newMapSize;

        _ResizeTileMap(mapSize);
    }
}