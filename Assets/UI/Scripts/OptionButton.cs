
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class OptionButton : OptionButton
{
	 
	public void _OnOptionButtonItemSelected(int _index)
	{  
		Audio.PlaySndClick();
	
	}
	
	public void _AddHover()
	{  
		// Restore color override hack when previously unhovered
		//add_color_override("font_color_hover", null) # Why does !null work? How to clear properly?
		Set("custom_colors/font_color_hover", null) ;// use this then
	
		if(HasIcon("arrow_hover", "OptionButton") && !has_icon_override("arrow"))
		{
			AddIconOverride("arrow", theme.GetIcon("arrow_hover", "OptionButton"));
	
		}
	}
	
	public void _RemoveHover()
	{  
		// Assign normal color style reliably
		AddColorOverride("font_color_hover", theme.GetColor("font_color", "OptionButton"));
	
		if(HasIconOverride("arrow"))
		{
			AddIconOverride("arrow", null);
	
		}
	}
	
	public void _Notification(int what)
	{  
		switch( what)
		{
			case NOTIFICATIONDraw:
				if(!disabled && modulate != Color.white)
				{
					modulate = Color.white;
				}
				else if(disabled && modulate != Color.darkgray)
				{
					modulate = Color.darkgray;
				}
				break;
			case NOTIFICATIONMouseEnter:
				if(!disabled)
				{
					_AddHover();
				}
				break;
			case NOTIFICATIONMouseExit:
				if(!get_popup().visible)
				{
					_RemoveHover();
				}
				break;
			case NOTIFICATIONFocusEnter: // occurs when PopupMenu closes
				var mouseIsInside = GetGlobalRect().HasPoint(GetGlobalMousePosition());
	
				// Remove hover when PopupMenu closes && focus returns back to
				// OptionButton but the mouse has been moved away in the meantime
				if(!mouse_is_inside)
				{
					_RemoveHover();
	
	
				}
				break;
		}
	}
	
	
	
}