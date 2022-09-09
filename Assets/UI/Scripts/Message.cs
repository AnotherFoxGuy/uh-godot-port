using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Message : HBoxContainer
{
    public enum MessageType
    {
        ANCHOR,
        DISASTERFire,
        DISASTERPlague,
        LETTER,
        MONEY,
        SAVE,
        SYSTEM
    }

    [Export]
    MessageType messageType
    {
        set { SetMessageType(value); }
    }

    private MessageType _messageType = MessageType.LETTER;

    [Export]
    string messageText
    {
        set { SetMessageText(value); }
    }

    private string _messageText;

    // onready var messageButton = $MessageButton
    // onready var messageTextPanel  = $MessageText

    private MessageButton messageButton;
    private MessageText messageTextPanel;

    public void _Ready()
    {
        messageButton = GetNode<MessageButton>("MessageButton");
        messageTextPanel = GetNode<MessageText>("MessageText");

        SetMessageText(_messageText);
        SetMessageType(_messageType);

        if (!Engine.IsEditorHint())
        {
            Audio.Instance.PlaySnd("ships_bell");
        }
    }

    public void SetMessageType(MessageType newMessageType)
    {
        _messageType = newMessageType;
        if (messageButton != null)
        {
            messageButton.messageType = _messageType;
        }
    }

    public void SetMessageText(String newMessageText)
    {
        _messageText = newMessageText;
        if (messageTextPanel != null)
        {
            messageTextPanel.messageText = _messageText;
        }
    }

    public void _OnMessageButtonPressed()
    {
        QueueFree();
    }

    public void _OnMessageButtonMouseEntered()
    {
        messageTextPanel.Visible = true;
    }

    public void _OnMessageButtonMouseExited()
    {
        messageTextPanel.Visible = false;
    }

    public void _OnTimerTimeout()
    {
        messageTextPanel.Visible = false;
    }
}