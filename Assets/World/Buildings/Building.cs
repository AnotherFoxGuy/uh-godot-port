
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Building : WorldThing
{
	 
	// Base class for all buildings.
	
	var currentAnim // if !null, action can be animated, otherwise static
	public __TYPE previousAnim;
	
	var rotationIndex {get{return GetRotationIndex();}}
	public int rotationOffset  = 0;
	
	onready var timer  = new Timer() // to play an animation in a sane speed
	
	Export(String) string action  = "idle" {set{SetAction(value);}}
	[Export(0, 1)]  public float animSpeed  = 0.95 {set{SetAnimSpeed(value);}}
	
	Export(bool) bool debugAnimate  = false;
	
	public void _Ready()
	{  
		AddChild(timer);
		// warning-ignore:returnValueDiscarded
		timer.Connect("timeout", this, "_on_Timer_timeout");
		timer.Start(1.001 - animSpeed);
	
	}
	
	public void _Process(float _delta)
	{  
		if(Engine.IsEditorHint())
		{
			if(!debug_animate && currentAnim != null)
			{
				_billboard.frame = 0;
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
		_billboard.modulate = Color.gold;
	
	}
	
	public void Deselect()
	{  
		GD.PrintS("DESELECT", this);
		_billboard.modulate = Color.white;
	
	}
	
	public void Animate()
	{   // to be overridden
		if(previousAnim != currentAnim && currentAnim == null)
		{
			_billboard.frame = self.rotation_index;
	
		}
		previousAnim = currentAnim;
	
	}
	
	public void _OnInput(InputEvent event)
	{  
		if(currentAnim == null)
		{
			._OnInput(event)
			return;
	
		// Switch texture accordingly with the world rotation.
		}
		if(event.IsActionPressed("rotate_left"))
		{
			rotationOffset = Mathf.Wrap(rotationOffset - 1, 0, 4);
			if((currentAnim).GetType() == typeof(Array))
			{
				self.texture = currentAnim[self.rotation_index];
			}
			else // HACK
			{
				_billboard.frame = Mathf.Wrap(_billboard.frame - 1, 0, _billboard.vframes * _billboard.hframes);
				Animate();
			}
		}
		else if(event.IsActionPressed("rotate_right"))
		{
			rotationOffset = Mathf.Wrap(rotationOffset + 1, 0, 4);
			if((currentAnim).GetType() == typeof(Array))
			{
				self.texture = currentAnim[self.rotation_index];
			}
			else // HACK
			{
				_billboard.frame = Mathf.Wrap(_billboard.frame - 1, 0, _billboard.vframes * _billboard.hframes);
				Animate();
	
	// Return the object's rotation with current camera rotation taken into account
			}
		}
	}
	
	public int GetRotationIndex()
	{  
		// warning-ignore:shadowedVariable
		var rotationIndex;
	
		switch( rotationDegree)
		{
			case RotationDegree.ZERO:
				rotationIndex = 0;
				break;
			case RotationDegree.NINETY:
				rotationIndex = 1;
				break;
			case RotationDegree.ONE_EIGHTY:
				rotationIndex = 2;
				break;
			case RotationDegree.TWO_SEVENTY:
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
	
	public void SetAction(__TYPE newAction)
	{  
		action = newAction;
	
	}
	
	public void SetAnimSpeed(__TYPE newAnimSpeed)
	{  
		animSpeed = newAnimSpeed;
	
		if(timer == null)
			 return;
		if(animSpeed > 0)
		{
			timer.wait_time = 1.001 - animSpeed;
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