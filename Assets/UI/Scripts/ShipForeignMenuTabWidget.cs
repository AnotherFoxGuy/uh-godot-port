using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class ShipForeignMenuTabWidget : TabWidget
{
    //onready var factionIndicator = $WidgetDetail/Body/ShipMenu/MarginContainer/FactionIndicator
    TextureRect factionIndicator;

    public void _Ready()
    {
        factionIndicator = FindNode("FactionIndicator") as TextureRect;
        if (Engine.IsEditorHint())
        {
            return;
        }

        factionIndicator.Texture = Global.FACTIONFlags[(int)Global.faction];
    }

    public void UpdateData(Dictionary contextData)
    {
        foreach (string data in contextData)
        {
            GD.PrintS("data:", data); // TownName
            var node = FindNode(data);

            if (node is Label)
            {
                var x = node as Label;
                x.Text = contextData[data] as string;
            }

            if (data == "FactionIndicator")
            {
                factionIndicator.Texture = contextData[data] as Texture;
            }
        }
    }
}