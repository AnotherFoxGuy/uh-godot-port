
using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class MessageButton : TextureButton
{
	 
	public static readonly Array<Dictionary<string, Texture>> MESSAGETextures = new Array<Dictionary<string, Texture>>(){
		new Dictionary<string, Texture>(){	// Anchor
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_anchor.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_anchor_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_anchor_h.png")
		}},
		new Dictionary<string, Texture>(){	// Disaster/Fire
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_fire_h.png")
		}},
		new Dictionary<string, Texture>(){	// Disaster/Plague
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_disaster_plague_h.png")
		}},
		new Dictionary<string, Texture>(){	// Letter
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_letter.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_letter_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_letter_h.png")
		}},
		new Dictionary<string, Texture>(){	// Money
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_money.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_money_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_money_h.png")
		}},
		new Dictionary<string, Texture>(){	// Save
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_save.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_save_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_save_h.png")
		}},
		new Dictionary<string, Texture>(){	// System
			{"normal", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_system.png")},
			{"pressed", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_system_d.png")},
			{"hover", GD.Load<Texture>("res://Assets/UI/Icons/Widgets/Messages/msg_system_h.png")
		}}
	};
	

	
	[Export] public Message.MessageType messageType {set{SetMessageType(value);}}
	private Message.MessageType _messageType = Message.MessageType.LETTER;
	
	public void SetMessageType(Message.MessageType newMessageType)
	{  
		_messageType = newMessageType;
	
		TextureNormal = MESSAGETextures[(int)_messageType]["normal"];
		TexturePressed = MESSAGETextures[(int)_messageType]["pressed"];
		TextureHover = MESSAGETextures[(int)_messageType]["hover"];
	
	
	}
	
	
	
}