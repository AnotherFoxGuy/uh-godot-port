
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MessageText : Label
{
	 
	[Export]  string messageText {set{SetMessageText(value);}}
	private string _messageText;
	
	public void _Ready()
	{  
		SetMessageText(_messageText);
	
	}
	
	public void SetMessageText(String newMessageText)
	{  
		_messageText = newMessageText;
		Text = _messageText;
	
		// After the text has been updated, decide whether
		// resizing of the font is appropriate || !var font = Get("custom_fonts/font");
		/* font.Set("size", 17) ;// default size to check against

		if(GetLineCount() > 2)
		{
			// Make font unique so it won't mistakenly update other instances
			font = font.Duplicate(true);
			AddFontOverride("font", font);
			font.Set("size", 15);
		}
		else
		{
			font.Set("size", 17);
	
		}
		if(GetLineCount() > 3)
		{
			GD.PrintErr("Text [new Dictionary(){0}] at {1} is too long.".Format(new Array(){text, self.name}));
	
	
		}*/
	}
	
	
	
}