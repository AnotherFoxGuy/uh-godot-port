using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class LineEditEx : HBoxContainer
{
    // LineEdit with a descriptive Label component

    // public signal textChangeRejected
    [Signal]
    delegate void TextChanged(string newText); // 

    [Signal]
    delegate void TextEntered(string newText); // 

    [Export]
    string description
    {
        set { SetDescription(value); }
    }

    private string _description = "Descriptive Label:";

    [Export]
    public string text
    {
        set { SetText(value); }
    }

    private string _text = "Example Text";

    [Export]
    public LineEdit.AlignEnum alignStyle
    {
        set { SetAlignStyle(value); }
    }

    private LineEdit.AlignEnum _alignStyle = LineEdit.AlignEnum.Left;

    //export(NodePath) var descriptionNodePath {set{SetDescriptionNodePath(value);}}
    //export(NodePath) var inputNodePath {set{SetInputNodePath(value);}}
    //onready var descriptionNode = GetNode(descriptionNodePath);
    //onready var inputNode = GetNode(inputNodePath);

    public void SetDescriptionNodePath(string newDescriptionNodePath)
    {
        //	descriptionNodePath = newDescriptionNodePath;
        //	descriptionNode = GetNode(descriptionNodePath);

        //func SetInputNodePath(newInputNodePath):
        //	inputNodePath = newInputNodePath;
        //	inputNode = GetNode(inputNodePath);
    }

    // onready var descriptionNode  = $LabelEx
    // onready var inputNode  = $LineEdit

    private LabelEx descriptionNode;
    LineEdit inputNode;

    public async void SetDescription(String newDescription)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _description = newDescription;

        descriptionNode.Text = _description;
    }

    public async void SetText(String newText)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _text = newText;

        inputNode.Text = _text;
    }

    public async void SetAlignStyle(LineEdit.AlignEnum newAlignStyle)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _alignStyle = newAlignStyle;

        switch (_alignStyle)
        {
            case LineEdit.AlignEnum.Left:
                MoveChild(inputNode, descriptionNode.GetIndex() + 1);
                descriptionNode.Align = Label.AlignEnum.Left;
                descriptionNode.Visible = true;
                break;
            case LineEdit.AlignEnum.Center:
                descriptionNode.Visible = false;
                break;
            case LineEdit.AlignEnum.Right:
                MoveChild(descriptionNode, inputNode.GetIndex() + 1);
                descriptionNode.Align = Label.AlignEnum.Right;
                descriptionNode.Visible = true;
                break;
        }

        inputNode.Align = _alignStyle;
    }

    public void _OnLineEditTextChangeRejected()
    {
        EmitSignal("text_change_rejected");
    }

    public void _OnLineEditTextChanged(String newText)
    {
        _text = newText;
        EmitSignal("text_changed", _text);
    }

    public void _OnLineEditTextEntered(String newText)
    {
        _text = newText;
        EmitSignal("text_entered", _text);
    }

    public void _OnReady()
    {
        // if(!description_node)
        // 	 descriptionNode = $LabelEx
        // if(!input_node)
        // 	 inputNode = $LineEdit
    }
}