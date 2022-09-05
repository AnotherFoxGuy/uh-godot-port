
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class AStarMap : Spatial
{
	 
	[Signal] delegate void MapSizeChanged(newMapSize);// int
	
	public Dictionary allPoints  = new Dictionary(){};
	public AStar2D asNode = null;
	
	[Export] public int mapSize  = 100 {set{SetMapSize(value);}}
	Export(NodePath) onready var gridMapPath;
	
	onready var gridMap  = GetNode(gridMapPath) as TileMap3D;
	onready StaticBody staticBody = $StaticBody as StaticBody
	onready CollisionShape collisionShape = staticBody.GetNode("CollisionShape") as CollisionShape;
	
	//#var rayPlane := new MeshInstance() as MeshInstance
	
	public void _Ready()
	{  
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
	
		asNode = new AStar2D()
		// TODO: Make use of Vector2i in Godot 4.0.
		var tiles = gridMap.GetUsedTiles();
		foreach(var tile in tiles)
		{
			if(_GetTileItemName(tile) in ["deep", "shallow_curve_in"])
			{
				var index = asNode.GetAvailablePointId();
				asNode.AddPoint(index, gridMap.TilemapToWorld(tile));
				allPoints[V2ToIndex(tile)] = index;
	
			}
		}
		foreach(var tile in tiles)
		{
			if(_GetTileItemName(tile) in ["deep", "shallow_curve_in"])
			{
				foreach(var x in [-1, 0, 1])
				{
					foreach(var y in [-1, 0, 1])
					{
							Vector2 v2 = new Vector2(x, y);
	
							if(v2 == Vector2.ZERO)
							{
								continue;
	
							}
							if(V2ToIndex(v2 + tile) in allPoints)
							{
								var ind1 = allPoints[V2ToIndex(tile)];
								var ind2 = allPoints[V2ToIndex(tile + v2)];
								if(!as_node.ArePointsConnected(ind1, ind2))
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
	
	public PoolVector2Array GetTilemapPath(Vector2 start, Vector2 end)
	{  
		//print_debug(start, end)
		var gmStart  = V2ToIndex(gridMap.WorldToTilemap(start));
		var gmEnd  = V2ToIndex(gridMap.WorldToTilemap(end));
		int startId  = 0;
		int endId  = 0;
		if(gmStart in allPoints)
		{
			startId = allPoints[gmStart];
		}
		else
		{
			startId = asNode.GetClosestPoint(start);
		}
		if(gmEnd in allPoints)
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
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
	
		mapSize = newMapSize > 0 ? newMapSize : 0
	
		staticBody.translation = new Vector3(mapSize, 0, mapSize);
		collisionShape.shape.extents = new Vector3(mapSize, 0, mapSize);
	
		EmitSignal("map_size_changed", mapSize);
	
	}
	
	public void _OnReady()
	{  
		if(!static_body)
			 staticBody = $StaticBody as StaticBody
		if(!collision_shape)
			 collisionShape = staticBody.GetNode("CollisionShape") as CollisionShape;
	
	
	}
	
	
	
}