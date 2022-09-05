
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Cursor : Node
{
	 
	enum CursorType {
		CURSORDefault,
		CURSORAttack,
		CURSORPipette,
		CURSORRename,
		CURSORTear,
	}
	
	public const var CURSORDefault = GD.Load("res://Assets/UI/Images/Cursors/cursor.png");
	public const var CURSORAttack = GD.Load("res://Assets/UI/Images/Cursors/cursor_attack.png");
	public const var CURSORPipette = GD.Load("res://Assets/UI/Images/Cursors/cursor_pipette.png");
	public const var CURSORRename = GD.Load("res://Assets/UI/Images/Cursors/cursor_rename.png");
	public const var CURSORTear = GD.Load("res://Assets/UI/Images/Cursors/cursor_tear.png");
	
	public Dictionary cursors = new Dictionary(){
		CursorType.CURSOR_DEFAULT: CURSORDefault,
		CursorType.CURSOR_ATTACK: CURSORAttack,
		CursorType.CURSOR_PIPETTE: CURSORPipette,
		CursorType.CURSOR_RENAME: CURSORRename,
		CursorType.CURSOR_TEAR: CURSORTear
	};
	
	public int cursor = CursorType.CURSOR_DEFAULT {get{return GetCursor();} set{SetCursor(value);}}
	
	public void _Ready()
	{  
		self.cursor = CursorType.CURSOR_DEFAULT;
	
	}
	
	public void SetCursor(int newCursor)
	{  
		cursor = newCursor;
		Input.SetCustomMouseCursor(cursors[cursor]);
	
	}
	
	public int GetCursor()
	{  
		return cursor;
	
	
	}
	
	
	
}