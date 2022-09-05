using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Utils : Godot.Object
{
    public static Vector2 Map3To2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }

    public static Vector3 Map2To3(Vector2 vector2)
    {
        return new Vector3(vector2.x, 0, vector2.y);
    }
}