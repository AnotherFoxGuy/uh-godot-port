using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Global : Node
{
    public enum WindowMode
    {
        WINDOWED,
        FULLSCREEN
    }

    public enum ResourceType
    {
        // Taken from FIFE version
        NONE = 0,
        GOLD = 1,
        LAMBWool = 2,
        TEXTILE = 3,
        BOARDS = 4,
        FOOD = 5,
        TOOLS = 6,
        BRICKS = 7,
        TREES = 8,
        GRASS = 9,
        WOOL = 10,
        FAITH = 11,
        WILDANIMALFOOD = 12,
        DEERMeat = 13,
        HAPPINESS = 14,
        POTATOES = 15,
        EDUCATION = 16,
        RAWSugar = 17,
        SUGAR = 18,
        COMMUNITY = 19,
        RAWClay = 20,
        CLAY = 21,
        LIQUOR = 22,
        CHARCOAL = 23,
        RAWIron = 24,
        IRONOre = 25,
        IRONIngots = 26,
        GETTogether = 27,
        FISH = 28,
        SALT = 29,
        TOBACCOPlants = 30,
        TOBACCOLeaves = 31,
        TOBACCOProducts = 32,
        CATTLE = 33,
        PIGS = 34,
        CATTLESlaughter = 35,
        PIGSSlaughter = 36,
        HERBS = 37,
        MEDICALHerbs = 38,
        ACORNS = 39,
        CANNON = 40,
        SWORD = 41,
        GRAIN = 42,
        CORN = 43,
        FLOUR = 44,
        SPICEPlants = 45,
        SPICES = 46,
        CONDIMENTS = 47,

        //	MARBLEDeposit   = GOLD, # 48
        //	MARBLETops      = GOLD, # 49
        //	COALDeposit     = GOLD, # 50
        STONEDeposit = 51,
        STONETops = 52,
        COCOABeans = 53,
        COCOA = 54,
        CONFECTIONERY = 55,
        CANDLES = 56,
        VINES = 57,
        GRAPES = 58,
        ALVEARIES = 59,
        HONEYCOMBS = 60,

        //	GOLDDeposit     = GOLD, # 61
        //	GOLDOre         = GOLD, # 62
        //	GOLDIngots      = GOLD, # 63
        //	GEMDeposit      = GOLD, # 64
        //	ROUGHGems       = GOLD, # 65
        //	GEMS             = GOLD, # 66
        //	SILVERDeposit   = GOLD, # 67
        //	SILVEROre       = GOLD, # 68
        //	SILVERIngots    = GOLD, # 69
        //	COFFEEPlants    = GOLD, # 70
        //	COFFEEBeans     = GOLD, # 71
        //	COFFEE           = GOLD, # 72
        //	TEAPlants       = GOLD, # 73
        //	TEALeaves       = GOLD, # 74
        //	TEA              = GOLD, # 75
        //	FLOWERMeadows   = GOLD, # 76
        //	BLOSSOMS         = GOLD, # 77
        //	BRINE            = GOLD, # 78
        //	BRINEDeposit    = GOLD, # 79
        //	WHALES           = GOLD, # 80
        //	AMBERGRIS        = GOLD, # 81
        //	LAMPOil         = GOLD, # 82
        //	COTTONPlants    = GOLD, # 83
        //	COTTON           = GOLD, # 84
        //	INDIGOPlants    = GOLD, # 85
        //	INDIGO           = GOLD, # 86
        //	GARMENTS         = GOLD, # 87
        //	PERFUME          = GOLD, # 88
        HOPPlants = 89,
        HOPS = 90,
        BEER = 91,

        // 92-99 reserved for services
        //	REPRESENTATION   = GOLD, # 92
        //	SOCIETY          = GOLD, # 93
        //	FAITH2          = GOLD, # 94
        //	EDUCATION2      = GOLD, # 95
        HYGIENE = 96,

        //	RECREATION       = GOLD, # 97
        BLACKDEATH = 98,
        FIRE = 99,
        // 92-99 reserved for services
    }

    public enum Faction
    {
        NONE,
        RED,
        BLUE,
        DARKGreen,
        ORANGE,
        PURPLE,
        CYAN,
        YELLOW,
        MAGENTA,
        TEAL,
        LIMEGreen,
        BORDEAUX,
        WHITE,
        GRAY,
        BLACK,
    }

    public static readonly Array RESOURCETypes = new Array()
    {
        null,
        GD.Load("res://Assets/UI/Icons/Resources/32/001.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/002.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/003.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/004.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/005.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/006.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/007.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/008.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/009.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/010.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/011.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/012.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/013.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/014.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/015.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/016.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/017.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/018.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/019.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/020.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/021.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/022.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/023.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/024.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/025.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/026.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/027.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/028.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/029.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/030.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/031.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/032.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/033.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/034.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/035.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/036.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/037.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/038.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/039.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/040.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/041.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/042.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/043.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/044.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/045.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/046.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/047.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/048.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/049.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/050.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/051.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/052.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/053.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/054.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/055.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/056.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/057.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/058.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/059.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/060.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/061.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/062.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/063.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/064.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/065.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/066.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/067.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/068.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/069.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/070.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/071.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/072.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/073.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/074.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/075.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/076.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/077.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/078.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/079.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/080.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/081.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/082.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/083.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/084.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/085.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/086.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/087.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/088.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/089.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/090.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/091.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/092.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/093.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/094.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/095.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/096.png"),
        null, //preload("res://Assets/UI/Icons/Resources/32/097.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/098.png"),
        GD.Load("res://Assets/UI/Icons/Resources/32/099.png"),
    };

    public static readonly Array FACTIONS = new Array()
    {
        "None",
        "Red",
        "Blue",
        "Dark Green",
        "Orange",
        "Purple",
        "Cyan",
        "Yellow",
        "Pink",
        "Teal",
        "Lime Green",
        "Bordeaux",
        "White",
        "Gray",
        "Black",
    };

    public static readonly Array FACTIONFlags = new Array()
    {
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_no_player.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_red.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_blue.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_dark_green.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_orange.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_purple.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_cyan.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_yellow.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_pink.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_teal.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_lime_green.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_bordeaux.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_white.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_gray.png"),
        GD.Load("res://Assets/UI/Images/TabWidget/Emblems/emblem_black.png"),
    };

    public static readonly Array<Color> FACTIONColors = new Array<Color>()
    {
        Color.Color8(0, 0, 0, 0), // None (transparent black).
        Color.Color8(250, 10, 10, 255), // Red.
        Color.Color8(0, 71, 181, 255), // Sea Blue.
        Color.Color8(0, 158, 23, 255), // Dark Green.
        Color.Color8(224, 102, 0, 255), // Orange.
        Color.Color8(128, 0, 128, 255), // Purple.
        Color.Color8(0, 255, 255, 255), // Cyan.
        Color.Color8(255, 214, 0, 255), // Yellow.
        Color.Color8(255, 0, 255, 255), // Magenta.
        Color.Color8(0, 145, 140, 255), // Teal.
        Color.Color8(0, 255, 0, 255), // Lime Green.
        Color.Color8(150, 5, 41, 255), // Bordeaux Red.
        Color.Color8(255, 255, 255, 255), // White.
        Color.Color8(128, 128, 128, 255), // Gray.
        Color.Color8(0, 0, 0, 255), // Black.
    };

    //public const var MESSAGEScene = GD.Load("res://Assets/UI/Scenes/Message.tscn");

    //const WINDOWModes = new Array(){
    //	WindowMode.WINDOWED,
    //	WindowMode.FULLSCREEN
    //};

    public static readonly Dictionary<WindowMode, string> WINDOWModes = new Dictionary<WindowMode, string>()
    {
        { WindowMode.WINDOWED, "Windowed" },
        { WindowMode.FULLSCREEN, "Fullscreen" }
    };

    // Language choices
    //const LANGUAGES = new Dictionary(){
    //	{"Deutsch", "de"},
    //	{"English", "en"},
    //	{"Français", "fr"},
    //};

    public static readonly Array LANGUAGES = new Array()
    {
        "de",
        "en",
        "fr",
    };

    public static readonly Dictionary LANGUAGESReadable = new Dictionary()
    {
        { "de", "Deutsch" },
        { "en", "English" },
        { "fr", "Français" },
    };

    public static Message MESSAGE_SCENE;

    //warning-ignore-all:unusedClassVariable

    // Game variables
    public string gameType = "FreePlay";
    public Faction faction = Faction.RED;
    public PackedScene map;
    public int aiPlayers = 0; // default should be 3 once AI is functional
    public float resourceDensity = 1.0f;
    public bool hasTraders = false;
    public bool hasPirates = true;

    public bool hasDisasters = false;

    // -------
    public static Game Game = null;
    public static Spatial PlayerStart = null;

    private bool _warning = false; // DEBUG

    private Config cfg = new Config();

    public void _Ready()
    {
        Config.Instance.LoadConfig(); // initialize with stored settings if available

        var windowMode = Config.windowMode;
        var screenResolution = Config.screenResolution;

        OS.WindowFullscreen = windowMode == WindowMode.FULLSCREEN;
        SetScreenResolution(screenResolution);

        SetAudioVolumes();

        // pauseMode = Node.PAUSE_MODE_PROCESS;
    }

    public void SetScreenResolution(String screenResolution)
    {
        var sresolution = screenResolution.Split("x");
        var resolution = new Vector2(int.Parse(sresolution[0]), int.Parse(sresolution[1]));
        OS.SetWindowSize(resolution);
        OS.CenterWindow();
        Input.MouseMode = Input.MouseModeEnum.Confined;
    }

    public void SetAudioVolumes()
    {
        Audio.Instance.SetMasterVolume(Config.masterVolume);
        Audio.Instance.SetMusicVolume(Config.musicVolume);
        Audio.Instance.SetEffectsVolume(Config.effectsVolume);
        Audio.Instance.SetVoiceVolume(Config.voiceVolume);
    }

    public void _Input(InputEvent ev)
    {
        if (Engine.IsEditorHint())
        {
            return;

            // Only available during gameplay
        }

        if (GetTree().GetRoot().GetNodeOrNull("World/WorldEnvironment") != null)
        {
            if (ev.IsActionPressed("time_speed_up"))
            {
                Engine.TimeScale += Mathf.Clamp(.1f, 0, 2);
                GD.PrintS("Time Scale:", Engine.TimeScale);
            }

            if (ev.IsActionPressed("time_slow_down"))
            {
                Engine.TimeScale -= Mathf.Clamp(.1f, 0f, 2f);
                GD.PrintS("Time Scale:", Engine.TimeScale);
            }

            if (ev.IsActionPressed("time_reset"))
            {
                Engine.TimeScale = 1;
                GD.PrintS("Time Scale:", Engine.TimeScale);
            }

            if (ev.IsActionPressed("pause_scene"))
            {
                GetTree().Paused = !GetTree().Paused;
                GD.Print(GetTree().Paused);
            }

            if (ev.IsActionPressed("restart_scene"))
            {
                //warning-ignore:returnValueDiscarded
                GetTree().ReloadCurrentScene();
            }
        }

        if (ev.IsActionPressed("toggle_fullscreen"))
        {
            var windowMode = Config.windowMode;

            //windowMode = (windowMode + 1) % WINDOWModes.Count;
            GD.PrintS("window_mode:", windowMode);
            Input.MouseMode = Input.MouseModeEnum.Hidden;
            OS.WindowFullscreen = !OS.WindowFullscreen;

            Config.windowMode = windowMode;
            Input.MouseMode = Input.MouseModeEnum.Confined;
        }

        if (ev.IsActionPressed("quit_game"))
        {
            GetTree().Quit();
        }
    }

    private static readonly Lazy<Global> lazy =
        new Lazy<Global>(() => new Global());

    public static Global Instance => lazy.Value;
}