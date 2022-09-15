using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class NewGameUI : BookMenu
{
    private LineEditEx playerName;

    public void _Ready()
    {
        playerName = FindNode("PlayerName") as LineEditEx;
        // Deactivate everything irrelevant for the time being
        Dictionary nodes = new Dictionary()
        {
            { "Scenario", null },
            { "RandomMap", null },
            { "ResourceDensitySlider", null },
            { "Disasters", null },
        };

        FindNodes(GetTree().Root, nodes);

        ((Node)nodes["Scenario"]).GetChild<CheckBox>(0).Disabled = true;
        ((Node)nodes["RandomMap"]).GetChild<CheckBox>(0).Disabled = true;
        ((Slider)nodes["ResourceDensitySlider"]).Editable = false;
        ((Button)nodes["Disasters"]).Disabled = true;

        if (Engine.IsEditorHint())
        {
            return;
        }

        playerName.text = Config.playerName;
    }

    public void FindNodes(Node rootNode, Dictionary nodesToBeFound)
    {
        foreach (Node n in rootNode.GetChildren())
        {
            if (n.GetChildCount() > 0)
            {
                FindNodes(n, nodesToBeFound);
            }

            if (nodesToBeFound.Contains(n.Name))
            {
                nodesToBeFound[n.Name] = n;
            }
        }
    }

    public void _OnCancelButtonPressed()
    {
        base._OnCancelButtonPressed();
    }

    public void _OnOKButtonPressed()
    {
        if (Global.Instance.map != null)
        {
            QueueFree();
            //warning-ignore:returnValueDiscarded
            GetTree().ChangeSceneTo(Global.Instance.map);
        }
        else
        {
            Audio.Instance.PlaySndFail();
        }
    }
}