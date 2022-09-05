
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Bookmark : TextureButton
{
	 
	public const var BOOKMARKLeft = GD.Load("res://Assets/UI/Images/Background/pickbelt_left.png");
	public const var BOOKMARKRight = GD.Load("res://Assets/UI/Images/Background/pickbelt_right.png");
	
	public static readonly Array SIDES = new Array(){
		BOOKMARKLeft,
		BOOKMARKRight
	};
	
	[Export("Left", "Right")]  public int side  = 0 {set{SetSide(value);}}
	
	public void SetSide(__TYPE newSide)
	{  
		side = newSide;
		textureNormal = SIDES[side];
	
	
	}
	
	
	
}