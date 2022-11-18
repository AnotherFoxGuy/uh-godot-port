using System;
using System.Linq;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class PlayerHUD : Control
{
    // public signal buttonTearPressed
    // public signal buttonLogbookPressed
    // public signal buttonBuildMenuPressed
    // public signal buttonDiplomacyPressed
    // public signal buttonGameMenuPressed

    public enum UIContext
    {
        NONE,
        TROOP,
        SHIP,
        SHIPForeign,
        BUILDING,
        BAKERY,
        BARRACKS,
        BATH,
        BLENDER,
        BOATBuilder,
        BREWERY,
        BRICKYARD,
        BUTCHERY,
        CANNONFoundry,
        CHAPEL,
        CHARCOALBurning,
        CLAYPit,
        DISTILLERY,
        DOCTOR,
        FARM,
        FIREStation,
        FISHERMAN,
        HUNTER,
        LOOKOUT,
        LUMBERJACK,
        MAINSquare,
        PASTRYShop,
        PIGSTY,
        SCHOOL,
        SMELTERY,
        STONEMASON,
        STONEPit,
        STORAGE,
        TAVERN,
        TOBACCONIST,
        TOOLMAKER,
        WAREHOUSE,
        WEAPONSMITH,
        WEAVER,
        WINDMILL,
        WINERY,
        WOODENTower,
    }

    //export(Array, NodePath) var uiContexts;
    [Export]
    UIContext uiContext
    {
        get => _uiContext;
        set { SetUiContext(value); }
    }

    private UIContext _uiContext;

    public Dictionary contextData = new Dictionary() { };

    // All widget nodes cached here for quick use whenever context switches
    public Array<Spatial> widgets;

    public Array queuedMessages = new Array() { };

    public bool printDebugMessages = true;

    private Array<Array> _debugMessages = new Array<Array>()
    {
        new Array() { 5, "Your game has been autosaved." },
        new Array() { 3, "Some of your inhabitants have no access to the main square." },
        new Array() { 2, "I'm just cleaning up here." },
        new Array() { 1, "Some of your inhabitants have diarrhea." },
        new Array() { 6, "A problem has occured. Do you want to send an error report?" },
        new Array() { 4, "This is a very long text. That much, that it easily takes up to 3 lines. Believe it || not." }
    };

    Spatial balanceInfoButton;
    Spatial cityInfo;
    Spatial messages;

    public void _Ready()
    {
        balanceInfoButton = FindNode("BalanceInfoButton") as Spatial;
        cityInfo = FindNode("CityInfo") as Spatial;
        messages = FindNode("Messages") as Spatial;

        //	for context in uiContexts:
        //		widgets.Append(GetNode(context))

        /*foreach(var widget in $MarginContainer/HBoxContainer/Widgets.GetChildren())
        {
            widgets.Append(widget);
    
        }*/
        // GD.PrintS("UIContext count:", UIContext.Size());
        GD.PrintS("widgets count:", widgets.Count);

        if (Engine.IsEditorHint())
        {
            return;
        }

        uiContext = UIContext.NONE;
    }

    public async void SetUiContext(UIContext newUiContext)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        GD.PrintS("Set UI context to", newUiContext);

        for (var index = 0; index < widgets.Count; index++)
        {
            if (index == (int)newUiContext)
            {
                widgets[index].Visible = true;
                // widgets[index].UpdateData(contextData);
            }
            else
            {
                widgets[index].Visible = false;
            }
        }

        _uiContext = newUiContext;
    }

    public void RaiseNotification(int messageType, String messageText)
    {
        var _debugMessage = _debugMessages[(int)(GD.Randi() % _debugMessages.Count)];

        if (messages.GetChildCount() < 6)
        {
            var message = Global.MESSAGE_SCENE;

            if (printDebugMessages)
            {
                messageType = (int)_debugMessage[0];
                messageText = (string)_debugMessage[1];
            }

            // message.message_type = messageType;
            // message.message_text = messageText;
            messages.AddChild(message);
            //	else:
            //		queuedMessages.Append()
        }
    }

    public void _OnPlayerCameraHovered()
    {
        cityInfo.Show();
    }

    public void _OnPlayerCameraUnhovered()
    {
        cityInfo.Hide();
    }

    public void _OnPlayerCameraSelected(Array selectedEntities)
    {
        GD.PrintS("_on_PlayerCamera_selected", selectedEntities);

        var newContext = UIContext.NONE;
        foreach (WorldThing entity in selectedEntities)
        {
            if (entity is Troop)
            {
                newContext = UIContext.TROOP;
                break;
            }

            if (entity is Ship)
            {
                var en = (Ship)entity;
                if (en.faction == Global.Game.player.faction)
                {
                    newContext = UIContext.SHIP;
                }
                else
                {
                    newContext = UIContext.SHIPForeign;
                }

                contextData = new Dictionary()
                {
                    { "FactionIndicator", Global.FACTIONFlags[(int)en.faction] },
                    { "Caption", en.unitName },
                };

                break;
            }

            if (entity is Building)
            {
                // newContext = _GetContextType(entity);

                contextData = new Dictionary()
                {
                    { "TownName", "Lübeck" },
                };
            }
        }

        uiContext = newContext;
    }

    public String _GetContextType(WorldThing entity)
    {
        return entity.GetClass();
    }

    public void _OnPlayerCameraUnselected()
    {
        GD.PrintS("_on_PlayerCamera_unselected");
        uiContext = UIContext.NONE;
    }

    public void _OnTabWidgetButtonTearPressed()
    {
        EmitSignal("button_tear_pressed");
    }

    public void _OnTabWidgetButtonLogbookPressed()
    {
        EmitSignal("button_logbook_pressed");
    }

    public void _OnTabWidgetButtonBuildMenuPressed()
    {
        EmitSignal("button_build_menu_pressed");
    }

    public void _OnTabWidgetButtonDiplomacyPressed()
    {
        EmitSignal("button_diplomacy_pressed");
    }

    public void _OnTabWidgetButtonGameMenuPressed()
    {
        EmitSignal("button_game_menu_pressed");
    }

    public void _OnReady()
    {
        if (widgets.Count != 0)
        {
            //		for context in uiContexts:
            //			widgets.Append(GetNode(context))
            // foreach(var widget in $MarginContainer/HBoxContainer/Widgets.GetChildren())
            // {
            // 	widgets.Append(widget);
            //
            // // Debug
            // }
            Array<string> debugWidgets = new Array<string>() { };
            foreach (var tabWidget in widgets)
            {
                debugWidgets.Append(tabWidget.Name);
            }

            GD.PrintS("Widgets:", debugWidgets);
        }
    }
}