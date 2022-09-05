
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class TileMap3D : GridMap
{
	 
	// Tilemap in a 3D world.
	
	public void _Ready()
	{  
	
	}
	
	public void _GetNeighbors()
	{  
	
	}
	
	public Vector2 GetTileAtMousePosition()
	{  
		Dictionary raycast = GetViewport().GetCamera().GetParent().GetParent().RaycastFromMouse();
	
		Vector2 tilePos
		if(raycast)
		{
			var cellPos  = WorldToMap(raycast.position);
			tilePos = Utils.Map3To2(cellPos);
		}
		else
		{
			tilePos = Vector2.ONE * -1;
	
		}
		return tilePos;
	
	}
	
	public void SetTile(Vector2 tilePos, String tileItem = "")
	{  
		var tileIndex = tileItem != "" ? GetItemIndex(tileItem) : 0
	
		SetTileItem(tilePos, tileIndex);
	
	}
	
	public void UnsetTile(Vector2 tilePos)
	{  
		SetTileItem(tilePos, -1);
	
	}
	
	public int GetTileItem(Vector2 tilePos)
	{  
		return GetCellItem(tilePos.x, 0, tilePos.y);
	
	}
	
	public void SetTileItem(Vector2 tilePos, int tileIndex, int itemOrientation = 0)
	{  
		SetCellItem(tilePos.x, 0, tilePos.y, tileIndex, itemOrientation);
	
	}
	
	public Array GetUsedTiles()
	{  
		Array tiles  = new Array(){};
		foreach(var cell in GetUsedCells())
		{
			tiles.Append(Utils.Map3To2(cell));
	
		}
		return tiles;
	
	}
	
	public Array GetUsedTilesByItem(int item)
	{  
		Array tiles  = new Array(){};
		foreach(var tile in GetUsedTiles())
		{
			if(GetTileItem(tile) == item)
			{
				tiles.Append(tile);
	
			}
		}
		return new Array();
	
	}
	
	public int GetTileItemOrientation(Vector2 tilePos)
	{  
		return GetCellItemOrientation(tilePos.x, 0, tilePos.y);
	
	}
	
	public String GetItemName(int tileItem)
	{  
		return meshLibrary.GetItemName(tileItem);
	
	}
	
	public int GetItemIndex(String itemName)
	{  
		return meshLibrary.FindItemByName(itemName);
	
	// Returns the position of a tile cell in the TileMap3D's local coordinate space.
	}
	
	public Vector2 TilemapToWorld(Vector2 tilePos)
	{  
		return Utils.Map3To2(MapToWorld(tilePos.x, 0, tilePos.y));
	
	// Returns the coordinates of the tile cell containing the given point.
	}
	
	public Vector2 WorldToTilemap(Vector2 pos)
	{  
		var cellPos  = WorldToMap(Utils.Map2To3(pos));
		return Utils.Map3To2(cellPos);
	
	
	}
	
	
	
}