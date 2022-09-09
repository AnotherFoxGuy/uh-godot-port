using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class LabelEx : Label
{
    // Label supporting various font styles

    public static readonly Array FONTStyles = new Array()
    {
        "font_title_capitalize",
        "font_title_capitalize_inline",
        "font_small", // "font" in Label theme settings
        "font_medium",
        "font_large",
        "font_small_bold",
        "font_medium_bold",
        "font_large_bold",
        "font_small_italic",
        "font_medium_italic",
        "font_large_italic",
        "font_small_bold_italic",
        "font_medium_bold_italic",
        "font_large_bold_italic",
    };

    public enum FontStyle
    {
        TITLECapitalize,
        TITLECapitalizeInline,
        SMALL,
        MEDIUM,
        LARGE,
        SMALLBold,
        MEDIUMBold,
        LARGEBold,
        SMALLItalic,
        MEDIUMItalic,
        LARGEItalic,
        SMALLBoldItalic,
        MEDIUMBoldItalic,
        LARGEBoldItalic
    }

    [Export]
    FontStyle fontStyle
    {
        set { SetFontStyle(value); }
    }

    private FontStyle _fontStyle = FontStyle.SMALL;

    public void SetFontStyle(FontStyle newFontStyle)
    {
        _fontStyle = newFontStyle;

        AddFontOverride("font", Theme.GetFont((string)FONTStyles[(int)_fontStyle], "Label"));

        PropertyListChangedNotify();
    }
}