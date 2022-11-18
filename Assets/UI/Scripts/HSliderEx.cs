using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class HSliderEx : VBoxContainer
{
    // Horizontal slider with a description label && current value indicator

    // public signal changed
    [Signal]
    delegate void ValueChanged(float sliderValue); // 

    [Export]
    string description
    {
        get => _description;
        set => SetDescription(value);
    }

    private string _description = "Unknown Slider:";

    //export(int) var tickCount {set{SetTickCount(value);}}
    //export(bool) bool ticksOnBorders  = false {set{SetTicksOnBorders(value);}}
    [Export]
    float minValue
    {
        get => _minValue;
        set => SetMinValue(value);
    }

    private float _minValue = 0.0f;

    [Export]
    float maxValue
    {
        get => _maxValue;
        set => SetMaxValue(value);
    }

    private float _maxValue = 100.0f;

    [Export]
    float step
    {
        get => _step;
        set => SetStep(value);
    }

    private float _step = 1.0f;

    [Export]
    float value
    {
        get => _value;
        set => SetValue(value);
    }

    private float _value = 0.0f;

    // onready var labelDesc  = $HBoxContainer/LabelExDesc as Label
    // onready var labelValue  = $HBoxContainer/LabelExValue as Label
    // onready var slider  = $HSlider as HSlider

    private Label labelDesc;
    private Label labelValue;
    private HSlider slider;

    public async void SetDescription(String newDescription)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _description = newDescription;

        labelDesc.Text = _description;

        //func SetTickCount(newTickCount: int) -> void:
        //	if !is_inside_tree(): await ToSignal(this, "ready")
        //	tickCount = Mathf.Clamp(newTickCount, 0, maxValue);
        //
        //	slider.tick_count = tickCount;
        //
        //func SetTicksOnBorders(newTicksOnBorders: bool) -> void:
        //	if !is_inside_tree(): await ToSignal(this, "ready")
        //	ticksOnBorders = newTicksOnBorders;
        //
        //	slider.ticks_on_borders = ticksOnBorders;
    }

    public async void SetMinValue(float newMinValue)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _minValue = Mathf.Stepify(newMinValue, 0.01f);

        if (_minValue > _maxValue)
        {
            SetMaxValue(_minValue);
            slider.MaxValue = _minValue;
        }

        if (_minValue > _value)
        {
            _value = _minValue;
        }

        PropertyListChangedNotify();

        slider.MinValue = _minValue;
    }

    public async void SetMaxValue(float newMaxValue)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        maxValue = Mathf.Stepify(newMaxValue, 0.01f);

        if (_maxValue < _minValue)
        {
            SetMinValue(_maxValue);
            slider.MinValue = _maxValue;
        }

        if (_maxValue < _value)
        {
            _value = _maxValue;
        }

        PropertyListChangedNotify();

        //slider.tick_count = maxValue / 10;
        slider.MaxValue = _maxValue;
    }

    public async void SetStep(float newStep)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _step = Mathf.Stepify(newStep, 0.01f);

        slider.Step = _step;
    }

    public async void SetValue(float newValue)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _value = Mathf.Stepify(Mathf.Clamp(Mathf.Stepify(newValue, _step), _minValue, _maxValue), 0.01f);

        slider.Value = _value;
        labelValue.Text = GD.Str(_value);
    }

    public void _OnHSliderChanged()
    {
        EmitSignal("changed");
    }

    public void _OnHSliderValueChanged(float sliderValue)
    {
        _value = sliderValue;
        labelValue.Text = GD.Str(_value);
        EmitSignal("value_changed", _value);
    }

    public void _OnReady()
    {
        // if(!label_desc)
        // 	 labelDesc = $HBoxContainer/LabelExDesc
        // if(!label_value)
        // 	 labelValue = $HBoxContainer/LabelExValue
        // if(!slider)
        // 	 slider = $HSlider
    }
}