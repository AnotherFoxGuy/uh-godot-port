
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class Audio : AudioStreamPlayer
{
	 
	public static readonly Dictionary SOUNDS = new Dictionary(){
		// Events/Scenario
		{"lose", GD.Load("res://Assets/Audio/Sounds/Events/Scenario/lose.ogg")},
		{"win", GD.Load("res://Assets/Audio/Sounds/Events/Scenario/win.ogg")},
	
		// Events
		{"new_era", GD.Load("res://Assets/Audio/Sounds/Events/new_era.ogg")},
		{"new_settlement", GD.Load("res://Assets/Audio/Sounds/Events/new_settlement.ogg")},
	
		// .
		{"build", GD.Load("res://Assets/Audio/Sounds/build.ogg")},
		{"chapel", GD.Load("res://Assets/Audio/Sounds/chapel.ogg")},
		{"click", GD.Load("res://Assets/Audio/Sounds/click.ogg")},
		{"flippage", GD.Load("res://Assets/Audio/Sounds/flippage.ogg")},
		{"invalid", GD.Load("res://Assets/Audio/Sounds/invalid.ogg")},
		{"lumberjack", GD.Load("res://Assets/Audio/Sounds/lumberjack.ogg")},
		{"lumberjack_long", GD.Load("res://Assets/Audio/Sounds/lumberjack_long.ogg")},
		{"main_square", GD.Load("res://Assets/Audio/Sounds/main_square.ogg")},
		{"refresh", GD.Load("res://Assets/Audio/Sounds/refresh.ogg")},
		{"sheepfield", GD.Load("res://Assets/Audio/Sounds/sheepfield.ogg")},
		{"ships_bell", GD.Load("res://Assets/Audio/Sounds/ships_bell.ogg")},
		{"smith", GD.Load("res://Assets/Audio/Sounds/smith.ogg")},
		{"stonemason", GD.Load("res://Assets/Audio/Sounds/stonemason.ogg")},
		{"success", GD.Load("res://Assets/Audio/Sounds/success.ogg")},
		{"tavern", GD.Load("res://Assets/Audio/Sounds/tavern.ogg")},
		{"warehouse", GD.Load("res://Assets/Audio/Sounds/warehouse.ogg")},
		{"windmill", GD.Load("res://Assets/Audio/Sounds/windmill.ogg")},
	
		// TODO: Possibly into distinct const?
		{"de_0", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/0.ogg")},
		{"de_1", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/1.ogg")},
		{"de_2", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/2.ogg")},
		{"de_3", GD.Load("res://Assets/Audio/Voice/de/0/NewWorld/3.ogg")},
	
		{"en_0", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/0.ogg")},
		{"en_1", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/1.ogg")},
		{"en_2", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/2.ogg")},
		{"en_3", GD.Load("res://Assets/Audio/Voice/en/0/NewWorld/3.ogg")},
	
		{"fr_0", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/0.ogg")},
		{"fr_1", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/1.ogg")},
		{"fr_2", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/2.ogg")},
		{"fr_3", GD.Load("res://Assets/Audio/Voice/fr/0/NewWorld/3.ogg")},
	};
	
	public __TYPE aspClick = new AudioStreamPlayer()
	public __TYPE aspBuild = new AudioStreamPlayer()
	public __TYPE aspVoice = new AudioStreamPlayer()
	
	public void _Ready()
	{  
		pauseMode = Node.PAUSE_MODE_PROCESS;
	
		aspClick.bus = "Effects";
		aspBuild.bus = "Effects";
		aspVoice.bus = "Voice";
	
		aspClick.stream = SOUNDS["click"];
		aspBuild.stream = SOUNDS["build"];
	
	}
	
	public void PlaySnd(String sndName, AudioStream stream = null)
	{  
		AudioStreamPlayer asp = new Dictionary(){
			{"click", aspClick},
			{"build", aspBuild},
			{"voice", aspVoice
		}}.Get(sndName);
	
		// If a distinct AudioStreamPlayer exists for the requested sound,
		// use that one
		if(asp != null)
		{
			if(stream) // Currently only used to pass different voice messages
			{
				asp.stream = stream;
			}
			if(!asp.name)
			{
				AddChild(asp);
			}
			asp.Play();
			//print_debug("Playing {0}".Format(new Array(){sndName}))
	
		// Otherwise play it through the generic AudioStreamPlayer
		}
		else if(SOUNDS[sndName])
		{
			self.stream = SOUNDS[sndName];
			//if !name: # "@@2"
			//	AddChild(this)
			Play();
			//print_debug("Playing {0}".Format(new Array(){sndName}))
		}
		else
		{
			GD.PrintErr("Sound {0} !found.".Format(new Array(){sndName}));
	
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
		aspVoice.stream = SOUNDS["{0}_{1}".Format(new Array(){Config.language, GD.Randi() % 4})];
		if(!asp_voice.name)
		{
			AddChild(aspVoice);
		}
		aspVoice.Play();
	
	}
	
	public void SetVolume(float volume, String busName)
	{  
		var index = AudioServer.GetBusIndex(busName);
		GD.Print("Set volume for bus {0}(new Dictionary(){1}): new Dictionary(){2}".Format(new Array(){busName, index, volume}));
		AudioServer.SetBusVolumeDb(index, GD.Linear2Db(volume / 100.0));
	
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
	
	
	
}