
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MessageButton : TextureButton
{
	 
	public static readonly Array MESSAGETextures = new Array(){
		new Dictionary(){	// Anchor
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_anchor.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_anchor_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_anchor_h.png")
		}},
		new Dictionary(){	// Disaster/Fire
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire_h.png")
		}},
		new Dictionary(){	// Disaster/Plague
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague_h.png")
		}},
		new Dictionary(){	// Letter
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_letter.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_letter_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_letter_h.png")
		}},
		new Dictionary(){	// Money
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_money.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_money_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_money_h.png")
		}},
		new Dictionary(){	// Save
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_save.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_save_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_save_h.png")
		}},
		new Dictionary(){	// System
			{"normal", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_system.png")},
			{"pressed", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_system_d.png")},
			{"hover", GD.Load("res://Assets/UI/Icons/Widgets/Messages/msg_system_h.png")
		}}
	};
	
	// Keep this alphabetically ordered
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
	
	public void SetMessageType(int newMessageType)
	{  
		messageType = newMessageType;
	
		textureNormal = MESSAGETextures[messageType]["normal"];
		texturePressed = MESSAGETextures[messageType]["pressed"];
		textureHover = MESSAGETextures[messageType]["hover"];
	
	
	}
	
	
	
}