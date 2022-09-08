
using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Streets : TileMap3D
{

	// public signal cellItemChanged;
	
	//        -z
	//        / \
	//         |
	//       .....
	// <- -x ..... +x ->
	//       .....
	//         |
	//        \ /
	//        +z
	public static readonly Dictionary<string, Array<int>> TILEOffsets = new Dictionary<string, Array<int>>(){
		// Direct connections
		{"a", new Array<int>(){ 0, -1}},
		{"b", new Array<int>(){+1,  0}},
		{"c", new Array<int>(){ 0, +1}},
		{"d", new Array<int>(){-1,  0}},
		// Remote connections
		{"e", new Array<int>(){+1, -1}},
		{"f", new Array<int>(){+1, +1}},
		{"g", new Array<int>(){-1, +1}},
		{"h", new Array<int>(){-1, -1}},
	};
	
	public static readonly Dictionary<string, Dictionary<string, int>> TILESets = new Dictionary<string, Dictionary<string, int>>(){
		{"single", new Dictionary<string, int>(){{"item", 0}, {"rotation", 0}}},
	
		{"a", new Dictionary<string, int>(){{"item", 1}, {"rotation", 270}}},
		{"b", new Dictionary<string, int>(){{"item", 1}, {"rotation", 180}}},
		{"c", new Dictionary<string, int>(){{"item", 1}, {"rotation", 90}}},
		{"d", new Dictionary<string, int>(){{"item", 1}, {"rotation", 0}}},
	
		{"ab", new Dictionary<string, int>(){{"item", 2}, {"rotation", 270}}},
		{"bc", new Dictionary<string, int>(){{"item", 2}, {"rotation", 180}}},
		{"cd", new Dictionary<string, int>(){{"item", 2}, {"rotation", 90}}},
		{"ad", new Dictionary<string, int>(){{"item", 2}, {"rotation", 0}}},
	
		{"abc", new Dictionary<string, int>(){{"item", 3}, {"rotation", 270}}},
		{"bcd", new Dictionary<string, int>(){{"item", 3}, {"rotation", 180}}},
		{"acd", new Dictionary<string, int>(){{"item", 3}, {"rotation", 90}}},
		{"abd", new Dictionary<string, int>(){{"item", 3}, {"rotation", 0}}},
	
		{"abcd", new Dictionary<string, int>(){{"item", 4}, {"rotation", 0}}},
	
		{"abcde", new Dictionary<string, int>(){{"item", 5}, {"rotation", 270}}},
		{"abcdf", new Dictionary<string, int>(){{"item", 5}, {"rotation", 180}}},
		{"abcdg", new Dictionary<string, int>(){{"item", 5}, {"rotation", 90}}},
		{"abcdh", new Dictionary<string, int>(){{"item", 5}, {"rotation", 0}}},
	
		{"abcdef", new Dictionary<string, int>(){{"item", 6}, {"rotation", 270}}},
		{"abcdfg", new Dictionary<string, int>(){{"item", 6}, {"rotation", 180}}},
		{"abcdgh", new Dictionary<string, int>(){{"item", 6}, {"rotation", 90}}},
		{"abcdeh", new Dictionary<string, int>(){{"item", 6}, {"rotation", 0}}},
	
		{"abcdefg", new Dictionary<string, int>(){{"item", 7}, {"rotation", 270}}},
		{"abcdfgh", new Dictionary<string, int>(){{"item", 7}, {"rotation", 180}}},
		{"abcdegh", new Dictionary<string, int>(){{"item", 7}, {"rotation", 90}}},
		{"abcdefh", new Dictionary<string, int>(){{"item", 7}, {"rotation", 0}}},
	
		{"abcdefgh", new Dictionary<string, int>(){{"item", 8}, {"rotation", 0}}},
	
		{"abcdeg", new Dictionary<string, int>(){{"item", 9}, {"rotation", 90}}},
		{"abcdfh", new Dictionary<string, int>(){{"item", 9}, {"rotation", 0}}},
	
		{"abce", new Dictionary<string, int>(){{"item", 10}, {"rotation", 270}}},
		{"bcdf", new Dictionary<string, int>(){{"item", 10}, {"rotation", 180}}},
		{"acdg", new Dictionary<string, int>(){{"item", 10}, {"rotation", 90}}},
		{"abdh", new Dictionary<string, int>(){{"item", 10}, {"rotation", 0}}},
	
		{"abcef", new Dictionary<string, int>(){{"item", 11}, {"rotation", 270}}},
		{"bcdfg", new Dictionary<string, int>(){{"item", 11}, {"rotation", 180}}},
		{"acdgh", new Dictionary<string, int>(){{"item", 11}, {"rotation", 90}}},
		{"abdeh", new Dictionary<string, int>(){{"item", 11}, {"rotation", 0}}},
	
		{"abcf", new Dictionary<string, int>(){{"item", 12}, {"rotation", 270}}},
		{"bcdg", new Dictionary<string, int>(){{"item", 12}, {"rotation", 180}}},
		{"acdh", new Dictionary<string, int>(){{"item", 12}, {"rotation", 90}}},
		{"abde", new Dictionary<string, int>(){{"item", 12}, {"rotation", 0}}},
	
		{"abe", new Dictionary<string, int>(){{"item", 13}, {"rotation", 270}}},
		{"bcf", new Dictionary<string, int>(){{"item", 13}, {"rotation", 180}}},
		{"cdg", new Dictionary<string, int>(){{"item", 13}, {"rotation", 90}}},
		{"adh", new Dictionary<string, int>(){{"item", 13}, {"rotation", 0}}},
	
		{"ac", new Dictionary<string, int>(){{"item", 14}, {"rotation", 90}}},
		{"bd", new Dictionary<string, int>(){{"item", 14}, {"rotation", 0}}},
	};
	
	public void _Ready()
	{  
		UpdateTiles();
	
	}
	
	public void _Process(float _delta)
	{  
		if(Engine.IsEditorHint())
		{
			UpdateTiles();
		}
		else
		{
			SetProcess(false);
	
		}
	}
	
	public void UpdateTiles(Array scaffoldTiles = null, bool canBuilt = true)
	{  
		//prints(GetNode("..").GetChildren())
		//var sprite = GetNode("../../TileMarker") ;#new Sprite3D()
		//add_child(sprite)
	
		//sprite.Show()
		foreach(var tile in GetUsedTiles())
		{
			//sprite.global_transform.origin = Callv("map_to_world", Vector2ToArray3(tile));
			//var cell := Vector2To3(tile) # TODO: Pass directly into MapToWorld() in Godot 4
			//sprite.global_transform.origin = MapToWorld(cell.x, cell.y, cell.z);
			//prints("current cell:\t", cell)
	
			string tileSet = "";
			foreach(var tileOffset in TILEOffsets)
			{
				//prints("check for tileOffset:\t", TILEOffsets[tileOffset])
	
				//yield(GetTree().CreateTimer(.1), "timeout")
				var checkedTile = GetTileItem(new Vector2(tile.x + TILEOffsets[tileOffset][0], tile.y + TILEOffsets[tileOffset][1]));
				if(checkedTile > -1) // Is there a road?
				{
					if(tileOffset in "abcd")
					{
						tileSet += tileOffset;
					}
					if(tileOffset in "efgh")
					{
						var fillLeft = Char.ConvertFromUtf32(Char.ConvertToUtf32(tileOffset) - 4) in tileSet;
	
						var fillRight = Char.ConvertFromUtf32(Char.ConvertToUtf32(tileOffset) - 3 - 4 * (int)(tileOffset == "h")) in tileSet;
						if(fillLeft && fillRight)
						{
							tileSet += tileOffset;
	
			//print("tile set for position {0}: new Dictionary(){1}".Format(new Array(){cell, tileSet}))
						}
					}
				}
			}
			if(tileSet in [""])
			{
				tileSet = "single";
	
			}
			Quat quaternion = new Quat(new Vector3(0, 1, 0), Mathf.Deg2Rad(TILESets[tileSet]["rotation"]));
			Basis tileItemOrientation = new Basis(quaternion).GetOrthogonalIndex();
	
			int item = TILESets[tileSet]["item"];
			if(new Vector2(tile.x, tile.y) in scaffoldTiles)
			{
				if(canBuilt)
				{
					item += 15;
				}
				else
				{
					item += 15 * 2;
	
				}
			}
			SetTileItem(tile, item, tileItemOrientation);
	
		//yield(GetTree().CreateTimer(2), "timeout")
		//sprite.Hide()
	
	//func Vector2ToArray3(vector2: Vector2) -> Array:
	//	return new Array(){vector2.x, 0, vector2.y}
	
	
		}
	}
	
	
	
}