
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class LineEdit : LineEdit
{
	 
	// Single-line input field
	
	public static readonly Dictionary ALIGN = new Dictionary(){
		{"Left", LineEdit.ALIGN_LEFT},
		{"Center", LineEdit.ALIGN_CENTER},
		{"Right", LineEdit.ALIGN_RIGHT
	}};
	
	[Export("Left", "Center", "Right")]  public String alignStyle  = "Center" {set{SetAlignStyle(value);}}
	
	private __TYPE _currentEditable;
	
	public void _Process(float _delta)
	{  
		if(!Engine.IsEditorHint())
		{
			if(_currentEditable != editable)
			{
				selectingEnabled = editable;
				mouseDefaultCursorShape = editable ? CURSORIbeam : CURSORArrow
	
				_currentEditable = editable;
				PropertyListChangedNotify();
	
			}
		}
	}
	
	public void SetAlignStyle(String newAlignStyle)
	{  
		alignStyle = newAlignStyle;
	
		// Text alignment
		align = ALIGN[alignStyle];
	//	AddStyleboxOverride( # StyleBox alignment
	//			"normal",
	//			theme.GetStylebox(
	//				"normal_" + alignStyle.ToLower() if alignStyle != "Center"
	//				else
	//				"normal",
	//					"LineEdit"))
	
		// StyleBox alignment
		_ApplyStyle("focus");
		_ApplyStyle("normal");
		_ApplyStyle("read_only");
	
		PropertyListChangedNotify();
	
	}
	
	public void _ApplyStyle(String name)
	{  
		AddStyleboxOverride(
				name,
				theme.GetStylebox(
					name + "_" + alignStyle.ToLower() if alignStyle != "Center";
					else
					name,
						"LineEdit"));
	
	
	}
	
	
	
}