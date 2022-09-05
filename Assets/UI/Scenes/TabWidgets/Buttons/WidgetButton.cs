
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class WidgetButton : TextureButton
{
	 
	// Base class for all widget buttons.
	//
	// All input events are catched by The (larger) child Node (background)
	// && passed only when the cursor lies in a valid / triggerable location
	// (i.e. inside the sprite's opaque region).
	//
	// Since there is currently no proper way to trigger the button to leave
	// the hovered state once the mouse left again, we force-disable it by
	// clearing the textureHover value, caching it inside the class && then
	// swap it back && forth into the texture slot whenever actually needed.
	
	// TODO: Investigate what's needed in total &&
	//		create several styles for various purposes.
	//		Unused for now, maybe !this much of variation needed after all?
	enum Style {
		NONE,
		ROUNDED,
		SQUAREDSmall,
		SQUAREDMedium,
		SQUAREDLarge,
	}
	
	public static readonly Array STYLES = new Array(){
		GD.Load("res://Assets/UI/Images/Buttons/msg_button.png"),
		GD.Load("res://Assets/UI/Images/Background/sq.png"),
		GD.Load("res://Assets/UI/Images/Background/square_80.png"),
		GD.Load("res://Assets/UI/Images/Background/square_120.png"),
	};
	
	public const var TEXTUREClickMaskRounded = GD.Load("res://Assets/UI/Images/Buttons/msg_button_mask.png");
	
	//export(Array, Texture) var stylesViewOnly  = STYLES;
	//export(Style) var style  = Style.ROUNDED ;#setget setStyle
	
	onready var textureRect  = $TextureRect as TextureRect
	onready var _textureHover  = textureHover;
	
	public void _Ready()
	{  
	//	GD.PrintS("texture_normal.GetSize()", textureNormal.GetSize())
	//	GD.PrintS("rect_size", rectSize)
		if(textureNormal)
		{
			if(textureClickMask)
			{
				if(textureNormal.GetSize() != textureClickMask.GetSize())
				{
					textureRect.mouse_filter = Control.MOUSE_FILTER_PASS;
	
				}
			}
		}
	}
	
	public void _Draw()
	{  
		if(textureNormal)
		{
			if(rectSize > textureNormal.GetSize())
			{
				rectSize = textureNormal.GetSize();
	
				PropertyListChangedNotify();
	
			}
		}
	}
	
	public void _Pressed()
	{  
		Audio.PlaySndClick();
	
	}
	
	public async void _Notification(int what)
	{  
		switch( what)
		{
			case NOTIFICATIONResized:
				rectPivotOffset = rectSize / 2 ;// always keep the pivot centered
				//texture_rect.rect_pivot_offset = textureRect.rect_size / 2;
	
	//func SetStyle(newStyle: int) -> void:
	//	if !is_inside_tree(): await ToSignal(this, "ready"); _OnReady()
	//
	//	Dictionary configuration  = new Dictionary(){
	//		Style.NONE:           new Array(){false, null, null},
	//		Style.ROUNDED:        [true, STYLES[Style.ROUNDED - 1], TEXTUREClickMaskRounded],
	//		Style.SQUARED_SMALL:  [true, STYLES[Style.SQUARED_SMALL - 1], null],
	//		Style.SQUARED_MEDIUM: [true, STYLES[Style.SQUARED_MEDIUM - 1], null],
	//		Style.SQUARED_LARGE:  [true, STYLES[Style.SQUARED_LARGE - 1], null],
	//	}.Get(newStyle) as Array;
	//
	//	textureRect.visible = configuration[0];
	//	textureRect.texture = configuration[1];
	//	textureClickMask = configuration[2];
	//
	//#	match newStyle:
	//#		Style.NONE:
	//#			textureRect.Hide()
	//#			textureRect.texture = null;
	//#			textureClickMask = null;
	//#		Style.ROUNDED:
	//#			textureRect.Show()
	//#			textureRect.texture = STYLES[Style.ROUNDED];
	//#			textureClickMask = TEXTUREClickMaskRounded;
	//#		Style.SQUARED_SMALL:
	//#			textureRect.Show()
	//#			textureRect.texture = STYLES[Style.SQUARED_SMALL];
	//#			textureClickMask = null;
	//#		Style.SQUARED_MEDIUM:
	//#			textureRect.Show()
	//#			textureRect.texture = STYLES[Style.SQUARED_MEDIUM];
	//#			textureClickMask = null;
	//#		Style.SQUARED_LARGE:
	//#			textureRect.Show()
	//#			textureRect.texture = STYLES[Style.SQUARED_LARGE];
	//#			textureClickMask = null;
	//
	//	style = newStyle;
	
				break;
		}
	}
	
	public bool _IsPixelOpaque(int tolerance = 145)
	{  
		var image  = textureRect.texture.GetData() as Image;
	
		var posRelativeToRect  =\
				GetLocalMousePosition() - textureRect.rect_position as Vector2;
	
		image.Lock();
		var color  = image.GetPixelv(posRelativeToRect) as Color;
		image.Unlock();
		if(color.a8 > tolerance)
		{
			//prints(posRelativeToRect, color.a8)
			return true;
		}
		else
		{
			return false;
	
		}
	}
	
	public void _OnActionButtonGuiInput(InputEvent _event)
	{  
		pass ;// Override in sub-class for specific behavior
	
	}
	
	public void _OnActionButtonMouseEntered()
	{  
		pass ;// Override in sub-class for specific behavior
		GD.PrintS("entered");
	
	}
	
	public void _OnActionButtonMouseExited()
	{  
		pass ;// Override in sub-class for specific behavior
		GD.PrintS("exited");
	
	}
	
	public void _OnTextureRectGuiInput(InputEvent _event)
	{  
		if(rectSize <= textureRect.rect_size)
		{
			if(_IsPixelOpaque())
			{
				//mouse_filter = Control.MOUSE_FILTER_STOP;
				textureRect.mouse_filter = Control.MOUSE_FILTER_PASS;
				textureHover = _textureHover;
				return;
	
			//mouse_filter = Control.MOUSE_FILTER_IGNORE;
			}
			textureHover = null;
			textureRect.mouse_filter = Control.MOUSE_FILTER_STOP;
	
		}
	}
	
	public void _OnReady()
	{  
		if(textureRect == null)
			 textureRect = $TextureRect as TextureRect
	
	
	}
	
	
	
}