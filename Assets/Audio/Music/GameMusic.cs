using System;
using System.Linq;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class GameMusic : AudioStreamPlayer
{
    // If this script somehow fails, "lose.ogg" will be played.

    // Above could possibly be displayed inside a music player/list GUI.
    private Array<string> _musicFiles = new Array<string>() { };
    private Array<AudioStream> _musicStreams = new Array<AudioStream>() { }; // Note: Does !show up in remote inspector.

    public void _Ready()
    {
        var dir = new Directory();
        //warning-ignore:returnValueDiscarded
        dir.Open("res://Assets/Audio/Music/Ambient");
        //warning-ignore:returnValueDiscarded
        dir.ListDirBegin();

        // Load all the files from the Ambient folder.
        while (true)
        {
            String file = dir.GetNext();
            if (file == "")
            {
                break;
            }
            else if (file.EndsWith(".ogg"))
            {
                _musicFiles.Add(file);
            }
        }

        foreach (var i in _musicFiles)
        {
            _musicStreams.Add(GD.Load<AudioStream>("Assets/Audio/Music/Ambient/" + i));

            // Always play a specific song when the game starts.
        }

        Stream = GD.Load<AudioStream>("res://Assets/Audio/Music/Ambient/newfrontier.ogg");
        Play();

        GD.Randomize(); // Godot will always generate the same random numbers otherwise.
    }

    public void PlaySongRandom()
    {
        PlaySongIndex((int)(GD.Randi() % _musicStreams.Count));
    }

    public void PlaySongIndex(int index)
    {
        Stop();
        Stream = _musicStreams[index] as AudioStream;
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
        RemoveSongIndex(_musicFiles.IndexOf(fileName));
    }

    public void RemoveSongIndex(int index)
    {
        _musicStreams.Remove(_musicStreams[index]);
        _musicFiles.Remove(_musicFiles[index]);
    }
}