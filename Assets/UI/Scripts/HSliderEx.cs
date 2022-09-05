
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class HSliderEx : VBoxContainer
{
	 
	// Horizontal slider with a description label && current value indicator
	
	public signal changed
	[Signal] delegate void ValueChanged(sliderValue);// float
	
	Export(String) string description  = "Unknown Slider:" {set{SetDescription(value);}}
	//export(int) var tickCount {set{SetTickCount(value);}}
	//export(bool) bool ticksOnBorders  = false {set{SetTicksOnBorders(value);}}
	Export(float) float minValue  = 0.0f {set{SetMinValue(value);}}
	Export(float) float maxValue  = 100.0f {set{SetMaxValue(value);}}
	Export(float) float step  = 1.0f {set{SetStep(value);}}
	Export(float) float value  = 0.0f {set{SetValue(value);}}
	
	onready var labelDesc  = $HBoxContainer/LabelExDesc as Label
	onready var labelValue  = $HBoxContainer/LabelExValue as Label
	onready var slider  = $HSlider as HSlider
	
	public async void SetDescription(String newDescription)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		description = newDescription;
	
		labelDesc.text = description;
	
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
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		minValue = Mathf.Stepify(newMinValue, 0.01);
	
		if(minValue > maxValue)
		{
			self.SetMaxValue(minValue);
			slider.max_value = minValue;
	
		}
		if(minValue > value)
		{
			self.value = minValue;
	
		}
		PropertyListChangedNotify();
	
		slider.min_value = minValue;
	
	}
	
	public async void SetMaxValue(float newMaxValue)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		maxValue = Mathf.Stepify(newMaxValue, 0.01);
	
		if(maxValue < minValue)
		{
			self.SetMinValue(maxValue);
			slider.min_value = maxValue;
	
		}
		if(maxValue < value)
		{
			self.value = maxValue;
	
		}
		PropertyListChangedNotify();
	
		//slider.tick_count = maxValue / 10;
		slider.max_value = maxValue;
	
	}
	
	public async void SetStep(float newStep)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		step = Mathf.Stepify(newStep, 0.01);
	
		slider.step = step;
	
	}
	
	public async void SetValue(float newValue)
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready"); _OnReady()
		value = Mathf.Stepify(Mathf.Clamp(Mathf.Stepify(newValue, step), minValue, maxValue), 0.01);
	
		slider.value = value;
		labelValue.text = GD.Str(value);
	
	}
	
	public void _OnHSliderChanged()
	{  
		EmitSignal("changed");
	
	}
	
	public void _OnHSliderValueChanged(float sliderValue)
	{  
		value = sliderValue;
		labelValue.text = GD.Str(value);
		EmitSignal("value_changed", value);
	
	}
	
	public void _OnReady()
	{  
		if(!label_desc)
			 labelDesc = $HBoxContainer/LabelExDesc
		if(!label_value)
			 labelValue = $HBoxContainer/LabelExValue
		if(!slider)
			 slider = $HSlider
	
	
	}
	
	
	
}