using System;
using System.Collections.Generic;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class GridMapCreatePathModes : EditorScript
{
    public Array nodes = new Array() { };

    public void _run()
    {
        var root_node = GetScene();
        var names = new List<string> { "TrailMeshes", "GravelPathMeshes", "StonePathMeshes" };

        if (names.Contains(root_node.Name) && root_node.GetClass() == "Spatial")
        {
            _clean_up_scene_tree();

            nodes = root_node.GetChildren();
            _create_sub_nodes_with_suffix("green");
            _create_sub_nodes_with_suffix("red");
        }
    }

    public void _clean_up_scene_tree()
    {
        GD.Print("Tidy up nodes");
        foreach (Node node in GetScene().GetChildren())
        {
            if (node.Name.Split("-").Length > 1)
            {
                node.Free();
            }
        }
    }

    public void _create_sub_nodes_with_suffix(String node_suffix)
    {
        var root_node = GetScene();
        Dictionary color = new Dictionary() { { "green", Colors.Green }, { "red", Colors.Red } };

        foreach (Node node in nodes)
        {
            var copy = node.Duplicate();
            copy.Name = copy.Name + "-" + node_suffix;

            var mesh = (Mesh)(node.GetNode<Mesh>("Node")).Duplicate();
            // var material = mesh.material.duplicate();

            // material.albedo_color = color[node_suffix];
            // mesh.material = material;
            // copy.mesh = mesh;

            GD.PrintS("Adding node", node.Name);
            root_node.AddChild(copy);
            copy.Owner = root_node;
        }
    }
}