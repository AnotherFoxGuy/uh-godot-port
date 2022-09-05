
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MovementContext : SelectionContext
{
	 
	public void MoveSelectedUnits(Vector2 mPos)
	{  
		var result = _playerCamera.RaycastFromMouse();
		if(result)
		{
			PrintDebug("Move Command selected units {0} ".Format(new Array(){result}));
			foreach(var unit in _playerCamera.selected_entities)
			{
				if(unit.faction == _playerCamera.player.faction)
				{
					unit.MoveTo(Utils.Map3To2(result.position));
	
				}
			}
		}
	}
	
	public void _OnIaMainCommandPressed(Node target, Vector2 position)
	{  
		//print_debug("Move action")
	
		var mPos = GetViewport().GetMousePosition();
		MoveSelectedUnits(mPos);
	
	
	}
	
	
	
}