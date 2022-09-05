using System;
using System.Linq;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class AStarMap : Spatial
{
    [Signal]
    delegate void MapSizeChanged(int newMapSize);

    public Dictionary allPoints = new Dictionary() { };
    public AStar2D asNode = null;

    [Export]
    public int mapSize
    {
        set { SetMapSize(value); }
    }

    [Export] NodePath gridMapPath;

    private TileMap3D gridMap;
    private StaticBody staticBody;
    private CollisionShape collisionShape;

    //#var rayPlane := new MeshInstance() as MeshInstance

    public void _Ready()
    {
        gridMap = GetNode(gridMapPath) as TileMap3D;
        // staticBody = StaticBody as StaticBody;
        collisionShape = staticBody.GetNode("CollisionShape") as CollisionShape;

        //#ray_plane.mesh = new PlaneMesh()
        //#ray_plane.visible = true;

        //#ray_plane.scale = Vector3.ONE * 128 ;# TODO: Adapt size dynamically to GridMap's outer bounds

        //ray_plane.CreateConvexCollision() # crashes for GLES2 in the export build

        //var staticBody = new StaticBody()
        //var collisionShape = new CollisionShape()
        //collision_shape.shape = new PlaneShape()

        //#ray_plane.Set("material/0", new SpatialMaterial())
        //#ray_plane.Get("material/0").Set("flags_no_depth_test", true)
        //#ray_plane.Get("material/0").Set("albedo_color", new Color("1863d3"))
        //#add_child(rayPlane)

        asNode = new AStar2D();
        // TODO: Make use of Vector2i in Godot 4.0.
        var tiles = gridMap.GetUsedTiles();

        string[] tnc = { "deep", "shallow_curve_in" };
        foreach (Vector2 tile in tiles)
        {
            if (tnc.Contains(_GetTileItemName(tile)))
            {
                var index = asNode.GetAvailablePointId();
                asNode.AddPoint(index, gridMap.TilemapToWorld(tile));
                allPoints[V2ToIndex(tile)] = index;
            }
        }

        foreach (Vector2 tile in tiles)
        {
            if (tnc.Contains(_GetTileItemName(tile)))
            {
                int[] it = { -1, 0, 1 };
                foreach (var x in it)
                {
                    foreach (var y in it)
                    {
                        Vector2 v2 = new Vector2(x, y);

                        if (v2 == Vector2.Zero)
                        {
                            continue;
                        }

                        if (allPoints.Contains(V2ToIndex(v2 + tile)))
                        {
                            Vector2 ind1 = (Vector2)allPoints[V2ToIndex(tile)];
                            Vector2 ind2 = (Vector2)allPoints[V2ToIndex(tile + v2)];
                            if (!asNode.ArePointsConnected(ind1, ind2))
                            {
                                asNode.ConnectPoints(ind1, ind2, true);
                            }
                        }
                    }
                }
            }
        }
    }

    public String _GetTileItemName(Vector2 tile)
    {
        var tileItemIndex = gridMap.GetTileItem(tile);
        return gridMap.GetItemName(tileItemIndex);
    }

    public String V2ToIndex(Vector2 v2)
    {
        // TODO: Make use of Vector2i in Godot 4.0.
        v2 = v2.Round();
        return GD.Str((int)(v2.x)) + "," + GD.Str((int)(v2.y));
    }

    public Vector2[] GetTilemapPath(Vector2 start, Vector2 end)
    {
        //print_debug(start, end)
        var gmStart = V2ToIndex(gridMap.WorldToTilemap(start));
        var gmEnd = V2ToIndex(gridMap.WorldToTilemap(end));
        int startId = 0;
        int endId = 0;
        if ( allPoints.Contains(gmStart))
        {
            startId = allPoints[gmStart];
        }
        else
        {
            startId = asNode.GetClosestPoint(start);
        }
        if (allPoints.Contains(gmEnd))
        {
            endId = allPoints[gmEnd];
        }
        else
        {
            endId = asNode.GetClosestPoint(end);
        }
        return asNode.GetPointPath(startId, endId);
    }

    public async void SetMapSize(int newMapSize)
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");
        _OnReady();

        mapSize = newMapSize > 0 ? newMapSize : 0;

        staticBody.Translation = new Vector3(mapSize, 0, mapSize);
        // collisionShape.Shape.extents = new Vector3(mapSize, 0, mapSize); 

        EmitSignal("map_size_changed", mapSize);
    }

    public void _OnReady()
    {
        // if (staticBody == null)
        //     staticBody = $StaticBody as StaticBody
        
        if (collisionShape == null )
            collisionShape = staticBody.GetNode("CollisionShape") as CollisionShape;
    }
}