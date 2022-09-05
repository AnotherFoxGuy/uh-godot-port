
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class MapList : ItemList
{
	 
	// TODO: Make this dynamic
	public Dictionary maps = new Dictionary(){
		{"WorldDev", GD.Load("res://Assets/World/WorldDev.tscn")},
		{"World", GD.Load("res://Assets/World/World.tscn")},
	};
	
	public void _Ready()
	{  
		int index = 0;
		foreach(var map in maps)
		{
			AddItem(map);
			if(maps[map] == Global.map)
			{
				Select(index);
			}
			index += 1;
	
		}
	}
	
	public void _OnItemListItemSelected(int index)
	{  
		Global.map = maps[GetItemText(index)];
	
	
	}
	
	
	
}