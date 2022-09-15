
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class OptionsUI : BookMenu
{
	/* 
	// Screen resolution choices
	public static readonly Array SCREENResolutions = new Array(){
		"800x600",
		"1024x768",
		"1280x1024",
		"1280x720",
		"1280x800",
		"1360x768",
		"1366x768",
		"1440x900",
		"1600x900",
		"1680x1050",
		"1920x1200",
		"1920x1080",
		"2560x1080",
		"2560x1440",
		"3440x1440",
		"3840x2160",
	};
	
	 Dictionary settings = new Dictionary(){
		{"AutosaveInterval", FindNode("AutosaveInterval") as HSliderEx},
		{"NumberOfAutosaves", FindNode("NumberOfAutosaves") as HSliderEx},
		{"NumberOfQuicksaves", FindNode("NumberOfQuicksaves") as HSliderEx},
	
		{"PlayerName", FindNode("PlayerName") as LineEditEx},
		{"GameLanguage", FindNode("GameLanguage") as OptionButtonEx},
	
		{"ScrollAtMapEdge", FindNode("ScrollAtMapEdge") as CheckBoxEx},
		{"CursorCenteredZoom", FindNode("CursorCenteredZoom") as CheckBoxEx},
		{"MiddleMouseButtonPan", FindNode("MiddleMouseButtonPan") as CheckBoxEx},
		{"MouseSensitivity", FindNode("MouseSensitivity") as HSliderEx},
	
		{"WindowMode", FindNode("WindowMode") as OptionButtonEx},
		{"ScreenResolution", FindNode("ScreenResolution") as OptionButtonEx},
	
		{"MasterVolume", FindNode("MasterVolume") as HSliderEx},
		{"MusicVolume", FindNode("MusicVolume") as HSliderEx},
		{"EffectsVolume", FindNode("EffectsVolume") as HSliderEx},
		{"VoiceVolume", FindNode("VoiceVolume") as HSliderEx},
	};
	
	public void _Ready()
	{  
		if(Engine.IsEditorHint())
		{
			return;
	
		// Autosaving
		}
		settings["AutosaveInterval"].value = Config.autosave_interval;
		settings["NumberOfAutosaves"].value = Config.number_of_autosaves;
		settings["NumberOfQuicksaves"].value = Config.number_of_quicksaves;
	
		// Player name
		settings["PlayerName"].text = Config.player_name;
	
		// Populate with languages
		settings["GameLanguage"].options = Global.LANGUAGES_READABLE.Values();
		foreach(var languageIndex in Global.LANGUAGES.Size())
		{
			if(Config.language == Global.LANGUAGES[languageIndex])
			{
				settings["GameLanguage"].selected = languageIndex;
	
		// Mouse settings
			}
		}
		settings["ScrollAtMapEdge"].checked = Config.scroll_at_map_edge;
		settings["CursorCenteredZoom"].checked = Config.cursor_centered_zoom;
		settings["MiddleMouseButtonPan"].checked = Config.middle_mouse_button_pan;
		settings["MouseSensitivity"].value = Config.mouse_sensitivity;
	
		// Window mode
		settings["WindowMode"].options = Global.WINDOW_MODES.Values();
		settings["WindowMode"].selected = Config.window_mode;
		settings["WindowMode"].Connect("item_selected", this, "_on_WindowMode_item_selected");
		settings["WindowMode"].EmitSignal("item_selected", Config.window_mode);
	
		// Populate with available resolutions
		settings["ScreenResolution"].options = SCREENResolutions;
		foreach(var screenResolutionIndex in SCREENResolutions.Size())
		{
			if(Config.screen_resolution == SCREENResolutions[screenResolutionIndex])
			{
				settings["ScreenResolution"].selected = screenResolutionIndex;
			}
		}
		settings["ScreenResolution"].Connect("item_selected", this, "_on_ScreenResolution_item_selected");
	
		// Audio parameters
		settings["MasterVolume"].value = Config.master_volume;
		settings["MasterVolume"].Connect("value_changed", this, "_on_MasterVolume_value_changed");
	
		settings["MusicVolume"].value = Config.music_volume;
		settings["MusicVolume"].Connect("value_changed", this, "_on_MusicVolume_value_changed");
	
		settings["EffectsVolume"].value = Config.effects_volume;
		settings["EffectsVolume"].Connect("value_changed", this, "_on_EffectsVolume_value_changed");
	
		settings["VoiceVolume"].value = Config.voice_volume;
		settings["VoiceVolume"].Connect("value_changed", this, "_on_VoiceVolume_value_changed");
	
	}
	
	public void PopulateDropdown(OptionButton dropdown, Dictionary items)
	{  
		foreach(var item in items.Values())
		{
			dropdown.AddItem(item);
	
		}
	}
	
	public void _OnWindowModeItemSelected(__TYPE index)
	{  
		OS.window_fullscreen = index;
		settings["ScreenResolution"].GetNode("OptionButton").disabled = !index == Global.WindowMode.WINDOWED;
		Global.SetScreenResolution(Config.screen_resolution);
	
	}
	
	public void _OnScreenResolutionItemSelected(__TYPE index)
	{  
		if(index != -1)
		{
			Global.SetScreenResolution(settings["ScreenResolution"].options[index]);
	
		}
	}
	
	public void _OnMasterVolumeValueChanged(float sliderValue)
	{  
		Audio.SetMasterVolume(sliderValue);
	
	}
	
	public void _OnMusicVolumeValueChanged(float sliderValue)
	{  
		Audio.SetMusicVolume(sliderValue);
	
	}
	
	public void _OnEffectsVolumeValueChanged(float sliderValue)
	{  
		Audio.SetEffectsVolume(sliderValue);
	
	}
	
	public void _OnVoiceVolumeValueChanged(float sliderValue)
	{  
		Audio.SetVoiceVolume(sliderValue);
	
	}
	
	public void _OnDeleteButtonPressed()
	{  
		GD.Print("Confirm TODO Action (modal dialog) before resetting everything.");
		Config.ResetToFactorySettings();
		_Ready();
	
		base._OnDeleteButtonPressed()
	
	}
	
	public void _OnCancelButtonPressed()
	{  
		Config.LoadConfig();
	
		// Revert temporary screen resolution change
		Global.SetScreenResolution(Config.screen_resolution);
		OS.window_fullscreen = Config.window_mode;
	
		// revert volume changes
		_Ready();
	
		base._OnCancelButtonPressed()
	
	}
	
	public void _OnOKButtonPressed()
	{  
		Config.autosave_interval = settings["AutosaveInterval"].value;
		Config.number_of_autosaves = settings["NumberOfAutosaves"].value;
		Config.number_of_quicksaves = settings["NumberOfQuicksaves"].value;
	
		Config.player_name = settings["PlayerName"].text;
		Config.language = Global.LANGUAGES[settings["GameLanguage"].selected];
	
		Config.scroll_at_map_edge = settings["ScrollAtMapEdge"].checked;
		Config.cursor_centered_zoom = settings["CursorCenteredZoom"].checked;
		Config.middle_mouse_button_pan = settings["MiddleMouseButtonPan"].checked;
		Config.mouse_sensitivity = settings["MouseSensitivity"].value;
	
		Config.window_mode = settings["WindowMode"].selected;
		Config.screen_resolution = SCREENResolutions[settings["ScreenResolution"].selected];
	
		Config.master_volume = settings["MasterVolume"].value;
		Config.music_volume = settings["MusicVolume"].value;
		Config.effects_volume = settings["EffectsVolume"].value;
		Config.voice_volume = settings["VoiceVolume"].value;
	
		var saved = Config.SaveConfig();
		if(saved != OK)
		{
			GD.Print("Could !save config!");
	
		}
		base._OnOKButtonPressed()
	
	
	}
	
	*/
	
}