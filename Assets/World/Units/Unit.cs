
using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;
using Object = Godot.Object;

[Tool]
public class Unit : WorldThing
{
	 
	// Base class for all units.
	
	// public signal positionChanged
	
	// public const var Global = GD.Load("res://Assets/World/Global.gd");
	// public const var Buoy = GD.Load("res://Assets/World/Buoy/Buoy.tscn");
	
	// All units are 8-directional.
	// Vector items are aligned according to the default camera Rotation (-45°)
	// && must be shifted increasingly by 2 for each further camera rotation.
	//
	// DIRECTION[direction + rotationOffset]
	//
	// Example: to keep RIGHT direction for each camera angle
	//
	//    -45° -> DIRECTION[index + 0] -> new Vector2( 1,  1)
	//     45° -> DIRECTION[index + 2] -> new Vector2(-1,  1)
	//    135° -> DIRECTION[index + 4] -> new Vector2(-1, -1)
	//   -135° -> DIRECTION[index + 6] -> new Vector2( 1, -1)
	
	public static readonly Array<Vector2> DIRECTION = new Array<Vector2>(){
		new Vector2( 1,  1), // RIGHT
		new Vector2( 0,  1), // DOWNRight
		new Vector2(-1,  1), // DOWN
		new Vector2(-1,  0), // DOWNLeft
		new Vector2(-1, -1), // LEFT
		new Vector2( 0, -1), // UPLeft
		new Vector2( 1, -1), // UP
		new Vector2( 1,  0)} ;// UPRight
	
	//warning-ignore-all:unusedClassVariable
	
	// Generic properties
	[Export] public string unitName = "Untitled" ;// user defined name for the unit
	public int faction;
	public int health = -1 ;// health must be set || it won't auto destroy itself
	
	// Pathfinding
	public Array<Vector2> path = new Array<Vector2>(){};
	public int pathIndex = 0;
	
	public Vector2 moveVector = new Vector2();
	
	// Sprite rotation
	public int direction = -1 ;// for non-animated movements, this is the frameIndex
	public int rotationOffset = 0;
	public RotationDegree rotationIndex;
	
	public Buoy buoy = null;

	private Spatial rotationY;
	private Spatial _asMap;
	private Spatial world;
	
	public bool isMoving = false;
	
	public void _Ready()
	{  
		  rotationY = GetNodeOrNull("/root/World/PlayerCamera/RotationY") as Spatial;
		  _asMap = GetNodeOrNull("/root/World/AStarMap") as Spatial;
		  world = GetNodeOrNull("/root/World") as Spatial;
		
		direction = (int)rotationDegree;
	
	}
	
	
	public void Select()
	{  
		Audio.PlaySndClick();
		// SelectionRing.visible = true;
		// TODO: Highlighting effect
		//$AnimationPlayer.Play("selected")
		if(buoy != null)
		{
			buoy.visible = true;
	
		}
	}
	
	public void Deselect()
	{  
		// $SelectionRing.visible = false;
		if(buoy!= null)
		{
			buoy.visible = false;
		//$AnimationPlayer.Stop()
	
		}
	}
	
	public void MoveTo(Vector2 targetPos)
	{  
		path = _asMap.GetTilemapPath(UUtils.Map3To2(GlobalTransform.origin), targetPos);
		pathIndex = 0;
		if(faction == world.player.faction && !path.Empty())
		{
			// Only show when the unit actually moves
			if(path.Count > 2)
			{
				CreateBuoy(path[-1]);
				Audio.PlaySndClick();
	
			}
		}
	}
	
	public void UpdatePath()
	{
		Vector2 moveVec;
		Vector2 dirVec;
		int dir = 0;
	
		if(pathIndex < path.Count)
		{
			moveVec = (path[pathIndex] - Utils.Map3To2(GlobalTransform.origin));
			if(moveVec.Length() < 1) // set next target node || proceed to the current one
			{
				pathIndex += 1;
				EmitSignal("position_changed", GlobalTransform.origin);// + moveVector)
			}
			else
			{
				isMoving = true;
	
				dirVec = new Vector2(Mathf.Sign(Mathf.Round(moveVec.x)), Mathf.Sign(Mathf.Round(moveVec.y)));
				// dir = DIRECTION.Find(dirVec);
				dir = DIRECTION.IndexOf(dirVec);
				//prints("Direction:", dir)
	
				moveVector = moveVec;
				direction = dir;
			}
		}
		else
		{
			pathIndex = 0;
			path = new Array<Vector2>();
			isMoving = false;
			DestroyBuoy();
	
		}
	}
	
	public void RecalculateDirections()
	{  
		if(Engine.IsEditorHint())
		{
			return;
	
		}
		if(rotationY == null)
		{
			rotationY = (Spatial)GetNode("/root/World/PlayerCamera/RotationY");
	
		}
		
		switch ((int)Mathf.Round(rotationY.RotationDegrees.y))
		{
			case -45:
				rotationOffset = 0;
				break;
			case 45:
				rotationOffset = 2;
				break;
			case 135:
				rotationOffset = 4;
				break;
			case -135:
				rotationOffset = 6;
				break;
		}
	}
	
	public void UpdateRotation()
	{  
		//prints("direction:", direction)
		//prints("rotation_offset:", rotationOffset)
		rotationIndex = (RotationDegree)Mathf.Wrap(direction + rotationOffset, 0, _billboard.Hframes * _billboard.Vframes);
	
	}
	
	public void CreateBuoy(Vector2 targetPos)
	{  
		if(IsInstanceValid(buoy))
		{
			buoy.QueueFree();
		}
		buoy = Buoy.Instance();
		buoy.SetTranslation(Utils.Map2To3(targetPos));
		world.AddChild(buoy);
	
	}
	
	public void DestroyBuoy()
	{  
		if(IsInstanceValid(buoy))
		{
			buoy.QueueFree();
		}
		buoy = null;
	
	}
	
	public void AnimateMovement()
	{  
		// For editor preview
		if(Engine.IsEditorHint())
		{
			return;
	
		}
		UpdateRotation();
	
		SetRotationDegree(rotationIndex);
	
	}
	
	public void TakeDamage(int damage)
	{  
		if((health - damage) < 0)
		{
			health = 0;
		}
		else
		{
			health -= damage;
	
		}
		if(health == 0)
		{
			QueueFree();
	
	
		}
	}
	
	
	
}