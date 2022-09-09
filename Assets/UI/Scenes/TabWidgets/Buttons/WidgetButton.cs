using Godot;
using Godot.Collections;

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
    enum Style
    {
        NONE,
        ROUNDED,
        SQUAREDSmall,
        SQUAREDMedium,
        SQUAREDLarge,
    }

    public static readonly Array<Texture> STYLES = new Array<Texture>
    {
        GD.Load("res://Assets/UI/Images/Buttons/msg_button.png") as Texture,
        GD.Load("res://Assets/UI/Images/Background/sq.png") as Texture,
        GD.Load("res://Assets/UI/Images/Background/square_80.png") as Texture,
        GD.Load("res://Assets/UI/Images/Background/square_120.png") as Texture,
    };

    public Texture TEXTUREClickMaskRounded;

    //export(Array, Texture) var stylesViewOnly  = STYLES;
    //export(Style) var style  = Style.ROUNDED ;#setget setStyle

    TextureRect textureRect; //= $TextureRect as TextureRect

    private Texture _textureHover;

    private Vector2 rectSize;

    public void _Ready()
    {
        _textureHover = TextureHover;
        TEXTUREClickMaskRounded = GD.Load("res://Assets/UI/Images/Buttons/msg_button_mask.png") as Texture;
        //	GD.PrintS("texture_normal.GetSize()", textureNormal.GetSize())
        //	GD.PrintS("rect_size", rectSize)
        if (TextureNormal != null)
        {
            if (TextureClickMask != null)
            {
                if (TextureNormal.GetSize() != TextureClickMask.GetSize())
                {
                    textureRect.MouseFilter = MouseFilterEnum.Pass;
                }
            }
        }
    }

    public void _Draw()
    {
        if (TextureNormal != null)
        {
            if (rectSize > TextureNormal.GetSize())
            {
                rectSize = TextureNormal.GetSize();

                PropertyListChangedNotify();
            }
        }
    }

    public void _Pressed()
    {
        Audio.Instance.PlaySndClick();
    }

    public async void _Notification(int what)
    {
        switch (what)
        {
            case NotificationResized:
                RectPivotOffset = rectSize / 2; // always keep the pivot centered
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
        var image = textureRect.Texture.GetData();

        var posRelativeToRect = GetLocalMousePosition() - textureRect.RectPosition;

        image.Lock();
        var color = image.GetPixelv(posRelativeToRect);
        image.Unlock();
        if (color.a8 > tolerance)
        {
            //prints(posRelativeToRect, color.a8)
            return true;
        }

        return false;
    }

    public void _OnActionButtonGuiInput(InputEvent _event)
    {
        // Override in sub-class for specific behavior
    }

    public void _OnActionButtonMouseEntered()
    {
        // Override in sub-class for specific behavior
        GD.PrintS("entered");
    }

    public void _OnActionButtonMouseExited()
    {
        // Override in sub-class for specific behavior
        GD.PrintS("exited");
    }

    public void _OnTextureRectGuiInput(InputEvent _event)
    {
        if (rectSize <= textureRect.RectSize)
        {
            if (_IsPixelOpaque())
            {
                //mouse_filter = Control.MOUSE_FILTER_STOP;
                textureRect.MouseFilter = MouseFilterEnum.Pass;
                TextureHover = _textureHover;
                return;

                //mouse_filter = Control.MOUSE_FILTER_IGNORE;
            }

            TextureHover = null;
            textureRect.MouseFilter = MouseFilterEnum.Stop;
        }
    }

    public void _OnReady()
    {
        // if(textureRect == null)
        // 	 textureRect = $TextureRect as TextureRect
    }
}