
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class OptionsGraphics : GridContainer
{
	 
	public void _Ready()
	{
		((LineEdit)FindNode("NameEdit")).Text = Global.PlayerName;
		// add language from Global
		int idx = 0;
		int i = 0;

		var LanguageEdit = ((OptionButtonEx)FindNode("LanguageEdit"));
		foreach(string n in Global.LANGUAGES)
		{
			LanguageEdit.AddItem(n);
			if(n == Global.Language)
			{
				idx = i;
			}
			i += 1;
		}
		LanguageEdit.Text = Global.Language;
		LanguageEdit.Select(idx);
		
		// idx = 0;
		// i = 0;
		// var ResolutionEdit = ((OptionButtonEx)FindNode("ResolutionEdit"));
		// foreach(var x in Global.sc)
		// {
		// 	ResolutionEdit.AddItem(x);
		// 	if(x == Global.screen_res)
		// 	{
		// 		idx = i;
		// 	}
		// 	i += 1;
		// }
		//
		// ResolutionEdit.Select(idx);

	}
	
	public void _OnNameEditTextEntered(string newText)
	{  
		Global.PlayerName = newText;
	
	}
	
	public void _OnLanguageEditItemSelected(int id)
	{  
		var lang = Global.LANGUAGES[id] as string;
		Global.Language = lang;
	
	}
	
	public void _OnResolutionEditItemSelected(int id)
	{  
		// var res = Global._screen_res[id];
		// Global.screen_res = res;
	
	
	}
	
	
	
}