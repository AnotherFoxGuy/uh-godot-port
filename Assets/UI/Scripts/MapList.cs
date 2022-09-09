using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MapList : ItemList
{
    // TODO: Make this dynamic
    public Dictionary<string, PackedScene> maps = new Dictionary<string, PackedScene>()
    {
        { "WorldDev", GD.Load<PackedScene>("res://Assets/World/WorldDev.tscn") },
        { "World", GD.Load<PackedScene>("res://Assets/World/World.tscn") },
    };

    public void _Ready()
    {
        int index = 0;
        foreach (var map in maps)
        {
            AddItem(map.Key);
            if (map.Value == Global.Instance.map)
            {
                Select(index);
            }

            index += 1;
        }
    }

    public void _OnItemListItemSelected(int index)
    {
        Global.Instance.map = maps[GetItemText(index)];
    }
}