using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class OptionButtonEx : HBoxContainer
{
    // OptionButton with a descriptive Label component

    [Signal]
    delegate void ItemFocused(int index); // 

    [Signal]
    delegate void ItemSelected(int index); // 

    [Export]
    string description
    {
        set { SetDescription(value); }
    }

    private string _description = "Descriptive Label:";

    [Export]
    Array options
    {
        set { SetOptions(value); }
    }

    private Array _options;

    [Export]
    int selected
    {
        set { SetSelected(value); }
    }

    private int _selected = -1;

    [Export]
    public string alignStyle
    {
        set { SetAlignStyle(value); }
    }

    private string _alignStyle = "Left";

    private LabelEx descriptionNode;
    private OptionButton optionButtonNode;

    public async void SetDescription(String newDescription)
    {
        descriptionNode = GetNode<LabelEx>("LabelEx");
        optionButtonNode = GetNode<OptionButton>("OptionButton");
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _description = newDescription;

        descriptionNode.Text = _description;
    }

    public async void SetOptions(Array newOptions)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _options = newOptions;

        //prints("Set options:", options)
        optionButtonNode.Clear();
        foreach (string option in _options)
        {
            optionButtonNode.AddItem(option);

            // Reassign in case the size has Changed (e.g. reduce index if invalid now)
        }
        // _selected = _selected;

        PropertyListChangedNotify();
    }

    public async void SetSelected(int newSelected)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        selected = Mathf.Clamp(newSelected, -1, _options.Count - 1);

        optionButtonNode.Selected = _selected;
    }

    public async void SetAlignStyle(String newAlignStyle)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _alignStyle = newAlignStyle;

        switch (_alignStyle)
        {
            case "Left":
                MoveChild(optionButtonNode, descriptionNode.GetIndex() + 1);
                descriptionNode.Align = Label.AlignEnum.Left;
                descriptionNode.Visible = true;
                optionButtonNode.Align = Button.TextAlign.Left;
                break;
            case "Center":
                descriptionNode.Visible = false;
                break;
            case "Right":
                MoveChild(descriptionNode, optionButtonNode.GetIndex() + 1);
                descriptionNode.Align = Label.AlignEnum.Right;
                descriptionNode.Visible = true;
                optionButtonNode.Align = Button.TextAlign.Right;
                break;
        }
    }

    public void _OnOptionButtonItemFocused(int index)
    {
        EmitSignal("item_focused", index);
    }

    public void _OnOptionButtonItemSelected(int index)
    {
        selected = index;
        EmitSignal("item_selected", _selected);
    }

    public void _OnReady()
    {
        // if(!description_node)
        // 	 descriptionNode = $LabelEx
        // if(!option_button_node)
        // 	 optionButtonNode = $OptionButton
    }
}