
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class GameMusic : AudioStreamPlayer
{
	 
	// If this script somehow fails, "lose.ogg" will be played.
	
	// Above could possibly be displayed inside a music player/list GUI.
	private Array _musicFiles  = new Array(){};
	private Array _musicStreams  = new Array(){} ;// Note: Does !show up in remote inspector.
	
	public void _Ready()
	{  
		var dir  = new Directory()
		//warning-ignore:returnValueDiscarded
		dir.Open("res://Assets/Audio/Music/Ambient");
		//warning-ignore:returnValueDiscarded
		dir.ListDirBegin();
	
		// Load all the files from the Ambient folder.
		while(true)
		{
			String file = dir.GetNext();
			if(file == "")
			{
				break;
			}
			else if(file.EndsWith(".ogg"))
			{
				_musicFiles.Append(file);
	
			}
		}
		foreach(var i in _musicFiles)
		{
			_musicStreams.Append(GD.Load("Assets/Audio/Music/Ambient/" + i));
	
		// Always play a specific song when the game starts.
		}
		stream = GD.Load("res://Assets/Audio/Music/Ambient/newfrontier.ogg");
		Play();
	
		GD.Randomize() ;// Godot will always generate the same random numbers otherwise.
	
	}
	
	public void PlaySongRandom()
	{  
		PlaySongIndex(GD.Randi() % _musicStreams.Size());
	
	}
	
	public void PlaySongIndex(int index)
	{  
		Stop();
		stream = _musicStreams[index];
		Play();
	
	// All the functions below are untested.
	
	}
	
	public void AddSong(String fileName)
	{  
		_musicFiles.Append(fileName);
		_musicStreams.Append(
				GD.Load("res://Assets/Audio/Music/Ambient/" + fileName));
	
	}
	
	public void RemoveSong(String fileName)
	{  
		RemoveSongIndex(_musicFiles.Find(fileName));
	
	}
	
	public void RemoveSongIndex(int index)
	{  
		_musicStreams.Remove(index);
		_musicFiles.Remove(index);
	
	
	}
	
	
	
}