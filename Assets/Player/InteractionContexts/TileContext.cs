
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class TileContext : InteractionContext
{
	 
	[Signal] delegate void TilesChanged(scaffoldTiles, canBuilt);// Array, bool
	
	public const var PHANTOMTileTexture = GD.Load("res://Assets/World/Buildings/Streets/Sprites/trail_single.png");
	
	onready TileMap3D streets = GetNode("/root/World/AStarMap/Streets") as TileMap3D;
	
	public Vector2 mPos
	
	public Sprite3D phantomTile
	
	public Vector2 lastTilePos
	
	public bool isDrawing  = false;
	public Array drawPath  = new Array(){};
	public bool aborted  = false;
	
	public void _Ready()
	{  
		SetProcess(false);
	
	}
	
	public void ShowPhantomTile(Vector2 tilePos)
	{  
		phantomTile.translation = streets.MapToWorld(tilePos.x, 0, tilePos.y);
	
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
		GD.Print("InteractionContext %s entered" % _contextName);
		var material = new SpatialMaterial()
		material.flags_transparent = true;
		material.flags_no_depth_test = true;
		material.params_billboard_mode = SpatialMaterial.BILLBOARD_ENABLED;
		material.albedo_texture = PHANTOMTileTexture;
	
		phantomTile = new Sprite3D()
		phantomTile.texture = PHANTOMTileTexture;
		phantomTile.pixel_size = 0.02;
		phantomTile.material_override = material;
		AddChild(phantomTile);
		Input.SetCustomMouseCursor(Cursor.CURSOR_TEAR, Input.CURSOR_ARROW);
	
		Connect("tiles_changed", streets, "update_tiles");
	
		SetProcess(true);
	
	}
	
	public void _OnExit()
	{  
		GD.Print("InteractionContext %s exited" % _contextName);
		phantomTile.QueueFree();
		Input.SetCustomMouseCursor(Cursor.CURSOR_DEFAULT, Input.CURSOR_ARROW);
	
		SetProcess(false);
	
	}
	
	public void _Process(float _delta)
	{  
		mPos = _playerCamera.GetViewport().GetMousePosition();
	
		var tilePos = streets.GetTileAtMousePosition();
	
		if(tilePos == lastTilePos)
		{
			return;
	
		}
		ShowPhantomTile(tilePos);
	
		if(isDrawing)
		{
			//print_debug("Check if tiling is executed on valid terrain")
			if drawPath.Size() >= 4 && tilePos == drawPath[-4] || \
			!tile_pos in streets.GetUsedTiles(): // free tile?
				GD.PrintS(tilePos);
				drawPath.Append(tilePos);
				streets.SetTileItem(tilePos, 0);
				EmitSignal("tiles_changed", drawPath);
			else // occupied cell
			{
				if(drawPath.Size() > 1)
				{
					if(tilePos == drawPath[-2])
					{
						//draw_path.Remove(drawPath.Size() - 1)
						var cellToBeRemoved = drawPath.PopBack();
						if(!cell_to_be_removed in drawPath)
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
		if(!is_drawing)
		{
			PrintDebug("Start tiling");
			isDrawing = true;
			lastTilePos.y = -1;
		}
		else
		{
			PrintDebug("End tiling");
			isDrawing = false;
			drawPath = new Array(){};
			EmitSignal("tiles_changed");
	
		}
	}
	
	public void _OnIaAltCommandReleased(Node target, Vector2 position)
	{  
		if(aborted)
		{
			PrintDebug("End Tiling (aborted)");
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
		PrintDebug("Abort tiling");
		foreach(var cellPos in drawPath)
		{
			streets.UnsetTile(cellPos);
	
		}
		if(isDrawing)
		{
			isDrawing = false;
		}
		else
		{
			AbortContext();
	
		}
		drawPath = new Array(){};
		aborted = true;
		EmitSignal("tiles_changed");
	
	
	}
	
	
	
}