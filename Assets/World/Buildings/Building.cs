
using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Building : WorldThing
{
	 
	// Base class for all buildings.

	internal Array<Texture> currentAnim;// if !null, action can be animated, otherwise static
	public Array<Texture> previousAnim;

	internal int rotationIndex {get{return GetRotationIndex();}}
	public int rotationOffset  = 0;

	private Timer timer = new Timer(); // to play an animation in a sane speed
	
	[Export]
	public string action  {set => SetAction(value);
		get => _action;
	}
	private string _action;
	[Export]  public float animSpeed  {set => SetAnimSpeed(value);
		get => _animSpeed;
	}
	private float _animSpeed;
	
	[Export] bool debugAnimate  = false;
	
	public void _Ready()
	{  
		AddChild(timer);
		// warning-ignore:returnValueDiscarded
		timer.Connect("timeout", this, "_on_Timer_timeout");
		timer.Start(1.001f - animSpeed);
	
	}
	
	public void _Process(float _delta)
	{  
		if(Engine.IsEditorHint())
		{
			if(!debugAnimate && currentAnim != null)
			{
				_billboard.Frame = 0;
				return;
			}
		}
		else
		{
			SetProcess(false);
	
	//func SetFaction(newFaction: int) -> void:
	//	faction = newFaction;
	
		}
	}
	
	public void Select()
	{  
		GD.PrintS("SELECT", this);
		Audio.PlaySndClick();
		// TODO: Highlighting effect
		_billboard.Modulate = Colors.Gold;
	
	}
	
	public void Deselect()
	{  
		GD.PrintS("DESELECT", this);
		_billboard.Modulate = Colors.White;
	
	}
	
	public void Animate()
	{   // to be overridden
		if(previousAnim != currentAnim && currentAnim == null)
		{
			_billboard.Frame = rotationIndex;
	
		}
		previousAnim = currentAnim;
	
	}
	
	public void _OnInput(InputEvent ev)
	{  
		if(currentAnim == null)
		{
			_OnInput(ev);
			return;
	
		// Switch texture accordingly with the world rotation.
		}
		if(ev.IsActionPressed("rotate_left"))
		{
			rotationOffset = Mathf.Wrap(rotationOffset - 1, 0, 4);
			if((currentAnim).GetType() == typeof(Array))
			{
				texture = currentAnim[rotationIndex];
			}
			else // HACK
			{
				_billboard.Frame = Mathf.Wrap(_billboard.Frame - 1, 0, _billboard.Vframes * _billboard.Hframes);
				Animate();
			}
		}
		else if(ev.IsActionPressed("rotate_right"))
		{
			rotationOffset = Mathf.Wrap(rotationOffset + 1, 0, 4);
			if((currentAnim).GetType() == typeof(Array))
			{
				texture = currentAnim[rotationIndex];
			}
			else // HACK
			{
				_billboard.Frame = Mathf.Wrap(_billboard.Frame - 1, 0, _billboard.Vframes * _billboard.Hframes);
				Animate();
	
	// Return the object's rotation with current camera rotation taken into account
			}
		}
	}
	
	public int GetRotationIndex()
	{  
		// warning-ignore:shadowedVariable
		var rotationIndex = 0;
	
		switch( rotationDegree)
		{
			case RotationDegree.ZERO:
				rotationIndex = 0;
				break;
			case RotationDegree.NINETY:
				rotationIndex = 1;
				break;
			case RotationDegree.ONEEighty:
				rotationIndex = 2;
				break;
			case RotationDegree.TWOSeventy:
				rotationIndex = 3;
	
		// Explanation:
		// rotationDegree	-> WorldThing Rotation (8 Rotations (0 - 7))
		// rotationIndex	-> Building Rotation (4 Rotations (0 - 3))
		// rotationOffset	-> Camera rotation offset relative to Building rotation
		//
		// Returned rotationIndex is rotationIndex + rotationOffset
		//	=> actual/current rotation
	
		//prints("rotation_degree:", rotationDegree)
		//prints("rotation_index:", rotationIndex)
		//prints("rotation_offset:", rotationOffset)
	
				break;
		}
		return (rotationIndex + rotationOffset) % 4;
	
	}
	
	public void SetAction(string newAction)
	{  
		action = newAction;
	
	}
	
	public void SetAnimSpeed(float newAnimSpeed)
	{  
		animSpeed = newAnimSpeed;
	
		if(timer == null)
			 return;
		if(animSpeed > 0)
		{
			timer.WaitTime = 1.001f - animSpeed;
			if(timer.IsStopped())// && currentAnim != null:
			{
				timer.Start();
			}
		}
		else
		{
			timer.Stop();
	
		}
	}
	
	public void _OnTimerTimeout()
	{  
		if(_billboard == null)
		{
			return;
	
	//	if Engine.IsEditorHint():
	//		if !Global._warning:
	//			GD.PrintS("Please reload the scene [new Dictionary(){0}].".Format(new Array(){name}))
	//			Global._warning = true;
	//		timer.Stop() # The timer does !stop. Why?
	//		return
	
		}
		Animate();
	
	
	}
	
	
	
}