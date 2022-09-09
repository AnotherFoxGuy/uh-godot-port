using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class CheckBoxEx : HBoxContainer
{
    // CheckBox with a descriptive Label component

    [Signal]
    delegate void Toggled(bool checkState); // 

    [Export]
    private string description
    {
        set { SetDescription(value); }
        get => _description;
    }

    private string _description = "Unknown CheckBox:";

    [Export]
    bool Checked
    {
        set { SetChecked(value); }
    }

    private bool _checked;

    // onready var descriptionNode  = $LabelEx
    private LabelEx descriptionNode;

    // onready var checkBoxNode  = $CheckBox
    private CheckBox checkBoxNode;

    public void _Ready()
    {
        //	guiInput.rect_size = rectSize;
    }

    public async void SetDescription(String newDescription)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        description = newDescription;

        descriptionNode.Text = description;
    }

    public async void SetChecked(bool newChecked)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _checked = newChecked;

        checkBoxNode.Pressed = _checked;
    }

    public void _OnCheckBoxToggled(bool checkState)
    {
        _checked = checkState;

        EmitSignal("toggled", _checked);
    }

    public void _Notification(int what)
    {
        switch (what)
        {
            case NotificationMouseEnter:
                descriptionNode.AddColorOverride("font_color",
                    descriptionNode.Theme.GetColor("font_color_hover", "CheckBox"));
                break;
            case NotificationMouseExit:
                descriptionNode.AddColorOverride("font_color",
                    descriptionNode.Theme.GetColor("font_color", "CheckBox"));

                break;
        }
    }

    public void _OnCheckBoxExGuiInput(InputEvent ev)
    {
        if (ev is InputEventMouseButton)
        {
            if (ev.IsActionReleased("alt_command"))
            {
                //print("Left click on CheckBox")
                Audio.Instance.PlaySndClick();
                checkBoxNode.Pressed = !checkBoxNode.Pressed;
            }
        }
    }

    public void _OnReady()
    {
        // if(!description_node)
        // 	 descriptionNode = $LabelEx
        // if(!check_box_node)
        // 	 checkBoxNode = $CheckBox
    }
}