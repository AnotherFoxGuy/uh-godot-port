using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Config : Node
{
    public const string CONFIGFile = "user://unknown_horizons.ini";

    // System variables
    public ConfigFile config;

    // Graphic variables
    public static Global.WindowMode windowMode = Global.WindowMode.WINDOWED;
    public static string screenResolution = "1600x900";

    // Game variables
    public static string playerName = "Unknown Traveller";
    public static string language = "en";

    // Autosave
    public static int autosaveInterval = 10;
    public static int numberOfAutosaves = 10;
    public static int numberOfQuicksaves = 10;

    // Mouse controls
    public static bool scrollAtMapEdge = true;
    public static bool cursorCenteredZoom = false;
    public static bool middleMouseButtonPan = true;
    public static float mouseSensitivity = 3.0f;

    // Audio/Sound
    public static float masterVolume = 50.0f;
    public static float musicVolume = 75.0f;
    public static float effectsVolume = 80.0f;
    public static float voiceVolume = 80.0f;

    //var uninterruptedBuilding := false
    //var autoUnloadShip := true

    // TODO use JSON for saviing

    // Each setting with their respective initial value
    /*public Dictionary<string, Dictionary> settings = new Dictionary<string, Dictionary>()
    {
        {
            "System", new Dictionary()
            {
                { "window_mode", windowMode },
                { "screen_resolution", screenResolution },
            }
        },
        {
            "Game", new Dictionary()
            {
                { "player_name", playerName },
                { "language", language },
            }
        },
        {
            "Autosave", new Dictionary()
            {
                { "autosave_interval", autosaveInterval },
                { "number_of_autosaves", numberOfAutosaves },
                { "number_of_quicksaves", numberOfQuicksaves },
            }
        },
        {
            "Mouse", new Dictionary()
            {
                { "scroll_at_map_edge", scrollAtMapEdge },
                { "cursor_centered_zoom", cursorCenteredZoom },
                { "middle_mouse_button_pan", middleMouseButtonPan },
                { "mouse_sensitivity", mouseSensitivity },
            }
        },
        {
            "Sound", new Dictionary()
            {
                { "master_volume", masterVolume },
                { "music_volume", musicVolume },
                { "effects_volume", effectsVolume },
                { "voice_volume", voiceVolume },
            }
        }
    };

    public ConfigFile CreateConfigIfNotExisting()
    {
        config = new ConfigFile();
        var err = config.Load(CONFIGFile);
        if (err != Error.Ok)
        {
            var saved = SaveConfig();
            if (saved != Error.Ok)
            {
                GD.Print("The config could !be saved!");
                GetTree().Quit();
            }
        }

        return config;
    }*/

    public void LoadConfig()
    {
        /*config = CreateConfigIfNotExisting();
        var err = config.Load(CONFIGFile);
        if (err != Error.Ok)
        {
            GD.Print("Could !load config.");
            GetTree().Quit();
        }

        LoadConfigValues(settings);*/
    }

    public void LoadConfigValue(String section, String key, ConfigFile dev)
    {
        Set(key, config.GetValue(section, key, dev));
    }

    public void LoadConfigValues(Dictionary<string, Dictionary> sections)
    {
        //prints("Loading/Initializing settings...")
        /*foreach (var section in sections.Keys)
        {
            foreach (var key in sections[section])
            {
                var value = sections[section][key];
                LoadConfigValue(section, key, value);

                //prints(section, key, value)
            }
        }*/
    }

    public Error SaveConfig()
    {
        /*SaveConfigValues(settings);

        return config.Save(CONFIGFile);*/
        return Error.Ok;
    }

    public void SaveConfigValue(String section, String key, object value)
    {
        config.SetValue(section, key, value);
    }

    /*public void SaveConfigValues(Dictionary<string, Dictionary> sections)
    {
        foreach (var section in sections.Keys)
        {
            foreach (var key in sections[section])
            {
                SaveConfigValue(section, key, Get(key));
            }
        }
    }*/

    public void ResetToFactorySettings()
    {
        //prints("Load default settings...")
        /*var sections = settings;
        foreach (var section in sections.Keys())
        {
            foreach (var key in sections[section])
            {
                var value = sections[section][key];
                Set(key, value);

                //prints(section, key, value)
            }
        }*/
    }
}