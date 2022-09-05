
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class OptionsGraphics : GridContainer
{
	 
	public void _Ready()
	{  
		$NameEdit.text = Global.player_name;
		// add language from Global
		int idx = 0;
		int i = 0;
		foreach(var n in Global._lang_array)
		{
			$LanguageEdit.AddItem(Global._languages[n])
			if(n == Global.language)
			{
				idx = i;
			}
			i += 1;
		}
		$LanguageEdit.text = Global._languages[Global.language];
		$LanguageEdit.Select(idx)
		idx = 0;
		i = 0;
		foreach(var x in Global._screen_res)
		{
			$ResolutionEdit.AddItem(x)
			if(x == Global.screen_res)
			{
				idx = i;
			}
			i += 1;
		}
		$ResolutionEdit.Select(idx)
	
	}
	
	public void _OnNameEditTextEntered(__TYPE newText)
	{  
		Global.player_name = newText;
	
	}
	
	public void _OnLanguageEditItemSelected(__TYPE id)
	{  
		var lang = Global._lang_array[id];
		Global.language = lang;
	
	}
	
	public void _OnResolutionEditItemSelected(__TYPE id)
	{  
		var res = Global._screen_res[id];
		Global.screen_res = res;
	
	
	}
	
	
	
}