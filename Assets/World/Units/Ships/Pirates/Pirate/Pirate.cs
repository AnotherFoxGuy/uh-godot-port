
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pirate : Ship
{
	 
	public const var PIRATEIdleAnim = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/Pirate_idle.png");
	
	public const var PIRATEBlackMove0 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_0.png");
	public const var PIRATEBlackMove45 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_45.png");
	public const var PIRATEBlackMove90 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_90.png");
	public const var PIRATEBlackMove135 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_135.png");
	public const var PIRATEBlackMove180 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_180.png");
	public const var PIRATEBlackMove225 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_225.png");
	public const var PIRATEBlackMove270 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_270.png");
	public const var PIRATEBlackMove315 = GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_315.png");
	
	public static readonly Array PIRATEMoveAnim = new Array(){
		PIRATEBlackMove0,
		PIRATEBlackMove45,
		PIRATEBlackMove90,
		PIRATEBlackMove135,
		PIRATEBlackMove180,
		PIRATEBlackMove225,
		PIRATEBlackMove270,
		PIRATEBlackMove315,
	};
	
	Export(bool) var debugIsMoving = isMoving;
	
	public float currentAnimPosition  = 0.0f;
	public string lastAnim = "fade_out";
	
	onready Sprite3D _reflection = $Reflection as Sprite3D
	onready Spatial waterOverlay = $WaterOverlay as Spatial
	onready Sprite3D waterOverlay1 = $WaterOverlay/WaterOverlay1 as Sprite3D
	onready Sprite3D waterOverlay2 = $WaterOverlay/WaterOverlay2 as Sprite3D
	onready AnimationPlayer animationPlayer = $AnimationPlayer as AnimationPlayer
	
	// Static (for now)
	onready Array patrolRoute = new Array(){
		new Vector2(-30,  30),
		new Vector2( 39,  40),
		new Vector2( 39, -38),
		new Vector2(-35, -38)
	};
	public int nextPatrolIndex = -1;
	
	public void _Ready()
	{  
		if(!Engine.IsEditorHint())
		{
			debugIsMoving = false;
	
		}
	}
	
	public void _Process(float _delta)
	{  
		Patrol() ;// DEBUG
	
		// TODO: Water Reflection (in AnimateMovement())
		// 		&& WaterOverlay effect
		//animate_water_overlay()
	
	}
	
	public void Patrol()
	{  
		if(Engine.IsEditorHint())
		{
			return;
	
	//	GD.PrintS("pirate:",
	//		(int)(Mathf.Round(globalTransform.origin.x)),
	//		(int)(Mathf.Round(globalTransform.origin.y))
	//	)
	//
	//	GD.PrintS("patrol_route",
	//		(int)(Mathf.Round(patrolRoute[nextPatrolIndex].x)),
	//		(int)(Mathf.Round(patrolRoute[nextPatrolIndex].y))
	//	)
		}
		if(path.Size() == 0)
		{
			nextPatrolIndex += 1;
			if(nextPatrolIndex >= patrolRoute.Size())
			{
				nextPatrolIndex = 0;
			}
			MoveTo(patrolRoute[nextPatrolIndex]);
	
		}
	}
	
	public void AnimateMovement()
	{  
		if(isMoving || debugIsMoving)
		{
			_billboard.vframes = 4;
			_billboard.hframes = 4;
			_billboard.region_rect = new Rect2(0, 0, 896, 896);
	
			_reflection.vframes = 4;
			_reflection.hframes = 4;
			_reflection.region_rect = new Rect2(0, 0, 896, 896);
			UpdateRotation();
	
			// For editor preview
			if(Engine.IsEditorHint())
			{
				rotationIndex = rotationDegree;
	
			}
			self.texture = PIRATEMoveAnim[rotationIndex];
			_reflection.texture = PIRATEMoveAnim[rotationIndex];
	
			_billboard.frame = NextFrame();
	
			if(rotationIndex == 1)
			{
				_reflection.rotation_degrees = new Vector3(0, 0, -60);
			}
			else if(rotationIndex == 3)
			{
				_reflection.rotation_degrees = new Vector3(0, 0, 30);
			}
			else
			{
				_reflection.rotation_degrees = new Vector3(0, -45, 0);
			}
			_reflection.frame = NextFrame(_reflection);
		}
		else
		{
			_billboard.vframes = 2;
			_billboard.hframes = 4;
			_billboard.region_rect = new Rect2(0, 0, 896, 448);
	
			_reflection.region_rect = new Rect2(0, 0, 896, 448);
			_reflection.vframes = 2;
			_reflection.hframes = 4;
			.UpdateRotation()
	
			self.texture = PIRATEIdleAnim;
			_reflection.texture = PIRATEIdleAnim;
	
			// For editor preview
			if(Engine.IsEditorHint())
			{
				rotationIndex = rotationDegree;
	
			}
			SetRotationDegree(Mathf.Wrap(rotationIndex, 0, _billboard.hframes * _billboard.vframes));
	
			if(rotationIndex == 1)
			{
				_reflection.material_override.Set("params_billboard_mode", SpatialMaterial.BILLBOARD_DISABLED);
				_reflection.offset = new Vector2(-4, -67);
				_reflection.rotation_degrees = new Vector3(0, 0, -60);
			}
			else if(rotationIndex == 3)
			{
				_reflection.material_override.Set("params_billboard_mode", SpatialMaterial.BILLBOARD_DISABLED);
				_reflection.offset = new Vector2(19, -81);
				_reflection.rotation_degrees = new Vector3(-36, -110, 70);
			}
			else
			{
				_reflection.material_override.Set("params_billboard_mode", SpatialMaterial.BILLBOARD_ENABLED);
				_reflection.offset = new Vector2(0, -90);
				//_reflection.rotation_degrees = new Vector3(0, -45, 0);
			}
			_reflection.frame = (Mathf.Wrap(rotationIndex, 0, _billboard.hframes * _billboard.vframes));
	
	// TODO: WaterOverlay fading transition effect
		}
	}
	
	public void AnimateWaterOverlay()
	{  
		if(animationPlayer.IsPlaying())
		{
			currentAnimPosition = animationPlayer.current_animation_position;
	
		}
		if(isMoving || debugIsMoving)
		{
			waterOverlay1.frame = Mathf.Wrap(waterOverlay1.frame + 1, 0, waterOverlay1.vframes * waterOverlay1.hframes);
			waterOverlay2.frame = Mathf.Wrap(waterOverlay2.frame + 1, 0, waterOverlay2.vframes * waterOverlay2.hframes);
	
			switch( rotationDegree)
			{
				case RotationDegree.ZERO:
					UpdateWaterOverlay(waterOverlay1, new Vector3(0, -45, 0), new Vector2(0, -90), false, true);
					UpdateWaterOverlay(waterOverlay2, new Vector3(0, -45, 0), new Vector2(0, 16), false, false);
					break;
				case RotationDegree.FORTY_FIVE:
					UpdateWaterOverlay(waterOverlay1, new Vector3(0, -90, 0), new Vector2(0, -90), false, true);
					UpdateWaterOverlay(waterOverlay2, new Vector3(0, -90, 0), new Vector2(0, 16), false, false);
					break;
				case RotationDegree.NINETY:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -135, 0), new Vector2(32, -45), false, true);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -135, 0), new Vector2(32, 48), false, false);
					break;
				case RotationDegree.ONE_THIRTY_FIVE:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -180, 0), new Vector2(32, 90), false, false);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, 0, 0), new Vector2(-32, 16), true, false);
					break;
				case RotationDegree.ONE_EIGHTY:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -225, 0), new Vector2(0, 104), false, false);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -45, 0), new Vector2(0, 0), true, false);
					break;
				case RotationDegree.TWO_TWENTY_FIVE:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 90, 0), new Vector2(-16, 90), false, false);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -90, 0), new Vector2(16, 16), true, false);
					break;
				case RotationDegree.TWO_SEVENTY:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 45, 0), new Vector2(-32, 51), false, false);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -135, 0), new Vector2(32, 48), true, false);
					break;
				case RotationDegree.THREE_FIFTEEN:
					UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 0, 0), new Vector2(-32, -90), false, true);
					UpdateWaterOverlay(waterOverlay2, new Vector3(-90, 0, 0), new Vector2(-32, 16), false, false);
	
					break;
			}
			if(!water_overlay.visible || animationPlayer.current_animation == "fade_out")
			{
				waterOverlay.visible = true;
				animationPlayer.Play("fade_in");
			}
		}
		else
		{
			if(waterOverlay.visible || animationPlayer.current_animation == "fade_in")
			{
				animationPlayer.Play("fade_out");
	
	// warning-ignore:shadowedVariable
			}
		}
	}
	
	public void UpdateWaterOverlay(
			waterOverlay: Sprite3D,
			rotation: Vector3,
			offset: Vector2,
			flipH: bool,
			flipV: bool)
	{  
		waterOverlay.rotation_degrees = rotation;
		waterOverlay.offset = offset;
		waterOverlay.flip_h = flipH;
		waterOverlay.flip_v = flipV;
	
	}
	
	public void UpdateRotation()
	{  
		rotationIndex = Mathf.Wrap(direction + rotationOffset, 0, PIRATEMoveAnim.Size());
	
	}
	
	public void _OnAnimationPlayerAnimationStarted(String animName)
	{  
		if(!is_inside_tree() || Engine.IsEditorHint())
		{
			return;
	
		}
		if(lastAnim != animationPlayer.current_animation)
		{
			animationPlayer.Seek(currentAnimPosition) ;// FIXME: PlayBackwards()
	//		GD.PrintS("Last animation:", lastAnim)
	//		GD.PrintS("Play animation:", animationPlayer.current_animation)
	//		GD.PrintS("Current position:", animationPlayer.current_animation_position)
		}
		lastAnim = animName;
	
	}
	
	public void _OnAnimationPlayerAnimationFinished(String animName)
	{  
		//prints("Animation finished:", animName)
		if(animName == "fade_out" && !is_moving)
		{
			waterOverlay.visible = false;
	
	
		}
	}
	
	
	
}