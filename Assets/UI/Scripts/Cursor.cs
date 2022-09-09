using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Cursor : Node
{
    public enum CursorType
    {
        CURSORDefault,
        CURSORAttack,
        CURSORPipette,
        CURSORRename,
        CURSORTear,
    }

    public static Dictionary<CursorType, Texture> cursors = new Dictionary<CursorType, Texture>()
    {
        { CursorType.CURSORDefault, GD.Load<Texture>("res://Assets/UI/Images/Cursors/cursor.png") },
        { CursorType.CURSORAttack, GD.Load<Texture>("res://Assets/UI/Images/Cursors/cursor_attack.png") },
        { CursorType.CURSORPipette, GD.Load<Texture>("res://Assets/UI/Images/Cursors/cursor_pipette.png") },
        { CursorType.CURSORRename, GD.Load<Texture>("res://Assets/UI/Images/Cursors/cursor_rename.png") },
        { CursorType.CURSORTear, GD.Load<Texture>("res://Assets/UI/Images/Cursors/cursor_tear.png") }
    };

    public CursorType cursor
    {
        get { return GetCursor(); }
        set { SetCursor(value); }
    }

    private CursorType _cursor;

    public void _Ready()
    {
        cursor = CursorType.CURSORDefault;
    }

    public void SetCursor(CursorType newCursor)
    {
        _cursor = newCursor;
        Input.SetCustomMouseCursor(cursors[_cursor]);
    }

    public CursorType GetCursor()
    {
        return _cursor;
    }
}