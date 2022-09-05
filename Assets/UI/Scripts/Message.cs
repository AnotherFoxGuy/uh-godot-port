
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Message : HBoxContainer
{
	 
	enum MessageType {
		ANCHOR,
		DISASTERFire,
		DISASTERPlague,
		LETTER,
		MONEY,
		SAVE,
		SYSTEM
	}
	
	Export(MessageType) var messageType  = MessageType.LETTER {set{SetMessageType(value);}}
	[Export(MULTILINE)]  String messageText {set{SetMessageText(value);}}
	
	onready var messageButton = $MessageButton
	onready var messageTextPanel  = $MessageText
	
	public void _Ready()
	{  
		SetMessageText(messageText);
		SetMessageType(messageType);
	
		if(!Engine.IsEditorHint())
		{
			Audio.PlaySnd("ships_bell");
	
		}
	}
	
	public void SetMessageType(int newMessageType)
	{  
		messageType = newMessageType;
		if(messageButton != null)
		{
			messageButton.message_type = messageType;
	
		}
	}
	
	public void SetMessageText(String newMessageText)
	{  
		messageText = newMessageText;
		if(messageTextPanel != null)
		{
			messageTextPanel.message_text = messageText;
	
		}
	}
	
	public void _OnMessageButtonPressed()
	{  
		QueueFree();
	
	}
	
	public void _OnMessageButtonMouseEntered()
	{  
		messageTextPanel.visible = true;
	
	}
	
	public void _OnMessageButtonMouseExited()
	{  
		messageTextPanel.visible = false;
	
	}
	
	public void _OnTimerTimeout()
	{  
		messageTextPanel.visible = false;
	
	
	}
	
	
	
}