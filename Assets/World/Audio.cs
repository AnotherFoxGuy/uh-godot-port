using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Audio : AudioStreamPlayer
{
    public static readonly Dictionary<string, AudioStream> SOUNDS = new Dictionary<string, AudioStream>()
    {
        // Events/Scenario
        { "lose", GD.Load("res://Assets/Audio/Sounds/Events/Scenario/lose.ogg") as AudioStream },
        { "win", GD.Load("res://Assets/Audio/Sounds/Events/Scenario/win.ogg") as AudioStream },

        // Events
        { "new_era", GD.Load("res://Assets/Audio/Sounds/Events/new_era.ogg") as AudioStream },
        { "new_settlement", GD.Load("res://Assets/Audio/Sounds/Events/new_settlement.ogg") as AudioStream },

        // .
        { "build", GD.Load("res://Assets/Audio/Sounds/build.ogg") as AudioStream },
        { "chapel", GD.Load("res://Assets/Audio/Sounds/chapel.ogg") as AudioStream },
        { "click", GD.Load("res://Assets/Audio/Sounds/click.ogg") as AudioStream },
        { "flippage", GD.Load("res://Assets/Audio/Sounds/flippage.ogg") as AudioStream },
        { "invalid", GD.Load("res://Assets/Audio/Sounds/invalid.ogg") as AudioStream },
        { "lumberjack", GD.Load("res://Assets/Audio/Sounds/lumberjack.ogg") as AudioStream },
        { "lumberjack_long", GD.Load("res://Assets/Audio/Sounds/lumberjack_long.ogg") as AudioStream },
        { "main_square", GD.Load("res://Assets/Audio/Sounds/main_square.ogg") as AudioStream },
        { "refresh", GD.Load("res://Assets/Audio/Sounds/refresh.ogg") as AudioStream },
        { "sheepfield", GD.Load("res://Assets/Audio/Sounds/sheepfield.ogg") as AudioStream },
        { "ships_bell", GD.Load("res://Assets/Audio/Sounds/ships_bell.ogg") as AudioStream },
        { "smith", GD.Load("res://Assets/Audio/Sounds/smith.ogg") as AudioStream },
        { "stonemason", GD.Load("res://Assets/Audio/Sounds/stonemason.ogg") as AudioStream },
        { "success", GD.Load("res://Assets/Audio/Sounds/success.ogg") as AudioStream },
        { "tavern", GD.Load("res://Assets/Audio/Sounds/tavern.ogg") as AudioStream },
        { "warehouse", GD.Load("res://Assets/Audio/Sounds/warehouse.ogg") as AudioStream },
        { "windmill", GD.Load("res://Assets/Audio/Sounds/windmill.ogg") as AudioStream },

        // TODO: Possibly into distinct const?
        { "de_0", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/0.ogg") as AudioStream },
        { "de_1", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/1.ogg") as AudioStream },
        { "de_2", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/2.ogg") as AudioStream },
        { "de_3", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/3.ogg") as AudioStream },

        { "en_0", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/0.ogg") as AudioStream },
        { "en_1", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/1.ogg") as AudioStream },
        { "en_2", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/2.ogg") as AudioStream },
        { "en_3", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/3.ogg") as AudioStream },

        { "fr_0", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/0.ogg") as AudioStream },
        { "fr_1", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/1.ogg") as AudioStream },
        { "fr_2", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/2.ogg") as AudioStream },
        { "fr_3", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/3.ogg") as AudioStream },
    };

    public AudioStreamPlayer aspClick = new AudioStreamPlayer();
    public AudioStreamPlayer aspBuild = new AudioStreamPlayer();
    public AudioStreamPlayer aspVoice = new AudioStreamPlayer();

    public void _Ready()
    {
        PauseMode = Node.PauseModeEnum.Process;

        aspClick.Bus = "Effects";
        aspBuild.Bus = "Effects";
        aspVoice.Bus = "Voice";

        aspClick.Stream = SOUNDS["click"];
        aspBuild.Stream = SOUNDS["build"];
    }

    public void PlaySnd(String sndName, AudioStream stream = null)
    {
        AudioStreamPlayer asp = new Dictionary<string, AudioStreamPlayer>()
        {
            { "click", aspClick },
            { "build", aspBuild },
            { "voice", aspVoice }
        }[sndName]; //.Get(sndName);

        // If a distinct AudioStreamPlayer exists for the requested sound,
        // use that one
        if (asp != null)
        {
            if (stream != null) // Currently only used to pass different voice messages
            {
                asp.Stream = stream;
            }

            if (!asp.Name.Empty())
            {
                AddChild(asp);
            }

            asp.Play();
            //print_debug("Playing {0}".Format(new Array(){sndName}))

            // Otherwise play it through the generic AudioStreamPlayer
        }
        else if (SOUNDS[sndName] != null)
        {
            stream = SOUNDS[sndName];
            //if !name: # "@@2"
            //	AddChild(this)
            Play();
            //print_debug("Playing {0}".Format(new Array(){sndName}))
        }
        else
        {
            GD.PrintErr($"Sound {sndName} !found.");
        }
    }

    public void PlaySndClick()
    {
        PlaySnd("click");
    }

    public void PlaySndFail()
    {
        PlaySnd("build");
    }

    public void PlaySndVoice(String voiceCode)
    {
        PlaySnd("voice", SOUNDS[voiceCode]);
    }

    public void PlayEntrySnd()
    {
        aspVoice.Stream = SOUNDS[$"{Config.language}_{GD.Randi() % 4}"];
        if (aspVoice.Name != null)
        {
            AddChild(aspVoice);
        }

        aspVoice.Play();
    }

    public void SetVolume(float volume, String busName)
    {
        var index = AudioServer.GetBusIndex(busName);
        // GD.Print("Set volume for bus {0}(new Dictionary(){1}): new Dictionary(){2}".Format(new Array()
        //     { busName, index, volume }));
        AudioServer.SetBusVolumeDb(index, GD.Linear2Db(volume / 100.0f));
    }

    public void SetMasterVolume(float volume)
    {
        SetVolume(volume, "Master");
    }

    public void SetVoiceVolume(float volume)
    {
        SetVolume(volume, "Voice");
    }

    public void SetEffectsVolume(float volume)
    {
        SetVolume(volume, "Effects");
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(volume, "Music");
    }

    private static readonly Lazy<Audio> lazy =
        new Lazy<Audio>(() => new Audio());

    public static Audio Instance => lazy.Value;
}