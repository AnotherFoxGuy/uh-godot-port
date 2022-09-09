using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class uOptionButton : OptionButton
{
    public void _OnOptionButtonItemSelected(int _index)
    {
        Audio.Instance.PlaySndClick();
    }

    public void _AddHover()
    {
        // Restore color override hack when previously unhovered
        //add_color_override("font_color_hover", null) # Why does !null work? How to clear properly?
        Set("custom_colors/font_color_hover", null); // use this then

        if (HasIcon("arrow_hover", "OptionButton") && !HasIconOverride("arrow"))
        {
            AddIconOverride("arrow", Theme.GetIcon("arrow_hover", "OptionButton"));
        }
    }

    public void _RemoveHover()
    {
        // Assign normal color style reliably
        AddColorOverride("font_color_hover", Theme.GetColor("font_color", "OptionButton"));

        if (HasIconOverride("arrow"))
        {
            AddIconOverride("arrow", null);
        }
    }

    public void _Notification(int what)
    {
        switch (what)
        {
            case NotificationDraw:
                if (!Disabled && Modulate != Colors.White)
                {
                    Modulate = Colors.White;
                }
                else if (Disabled && Modulate != Colors.DarkGray)
                {
                    Modulate = Colors.DarkGray;
                }

                break;
            case NotificationMouseEnter:
                if (!Disabled)
                {
                    _AddHover();
                }

                break;
            case NotificationMouseExit:
                if (!GetPopup().Visible)
                {
                    _RemoveHover();
                }

                break;
            case NotificationFocusEnter: // occurs when PopupMenu closes
                var mouseIsInside = GetGlobalRect().HasPoint(GetGlobalMousePosition());

                // Remove hover when PopupMenu closes && focus returns back to
                // OptionButton but the mouse has been moved away in the meantime
                if (!mouseIsInside)
                {
                    _RemoveHover();
                }

                break;
        }
    }
}