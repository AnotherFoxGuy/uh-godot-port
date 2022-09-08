using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Pirate : Ship
{
    public Texture PIRATEIdleAnim;
    public static Array<Texture> PIRATEMoveAnim = new Array<Texture>();

    [Export] bool debugIsMoving = isMoving;

    public float currentAnimPosition = 0.0f;
    public string lastAnim = "fade_out";

    // onready Sprite3D _reflection = $Reflection as Sprite3D
    // onready Spatial waterOverlay = $WaterOverlay as Spatial
    // onready Sprite3D waterOverlay1 = $WaterOverlay/WaterOverlay1 as Sprite3D
    // onready Sprite3D waterOverlay2 = $WaterOverlay/WaterOverlay2 as Sprite3D
    // onready AnimationPlayer animationPlayer = $AnimationPlayer as AnimationPlayer

    private Sprite3D _reflection;
    private Spatial waterOverlay;
    private Sprite3D waterOverlay1;
    private Sprite3D waterOverlay2;
    private AnimationPlayer animationPlayer;

    // Static (for now)
    Array<Vector2> patrolRoute = new Array<Vector2>()
    {
        new Vector2(-30, 30),
        new Vector2(39, 40),
        new Vector2(39, -38),
        new Vector2(-35, -38)
    };

    public int nextPatrolIndex = -1;

    public void _Ready()
    {
        PIRATEIdleAnim =
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/Pirate_idle.png") as Texture;

        PIRATEMoveAnim = new Array<Texture>()
        {
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_0.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_45.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_90.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_135.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_180.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_225.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_270.png") as Texture,
            GD.Load("res://Assets/World/Units/Ships/Pirates/Pirate/Sprites/PirateBlack_move_315.png") as Texture,
        };

        if (!Engine.IsEditorHint())
        {
            debugIsMoving = false;
        }
    }

    public void _Process(float _delta)
    {
        Patrol(); // DEBUG

        // TODO: Water Reflection (in AnimateMovement())
        // 		&& WaterOverlay effect
        //animate_water_overlay()
    }

    public void Patrol()
    {
        if (Engine.IsEditorHint())
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

        if (path.Length == 0)
        {
            nextPatrolIndex += 1;
            if (nextPatrolIndex >= patrolRoute.Count)
            {
                nextPatrolIndex = 0;
            }

            MoveTo(patrolRoute[nextPatrolIndex]);
        }
    }

    public void AnimateMovement()
    {
        if (isMoving || debugIsMoving)
        {
            _billboard.Vframes = 4;
            _billboard.Hframes = 4;
            _billboard.RegionRect = new Rect2(0, 0, 896, 896);

            _reflection.Vframes = 4;
            _reflection.Hframes = 4;
            _reflection.RegionRect = new Rect2(0, 0, 896, 896);
            UpdateRotation();

            // For editor preview
            if (Engine.IsEditorHint())
            {
                rotationIndex = (int)rotationDegree;
            }

            texture = PIRATEMoveAnim[rotationIndex];
            _reflection.Texture = PIRATEMoveAnim[rotationIndex];

            _billboard.Frame = NextFrame();

            if (rotationIndex == 1)
            {
                _reflection.RotationDegrees = new Vector3(0, 0, -60);
            }
            else if (rotationIndex == 3)
            {
                _reflection.RotationDegrees = new Vector3(0, 0, 30);
            }
            else
            {
                _reflection.RotationDegrees = new Vector3(0, -45, 0);
            }

            _reflection.Frame = NextFrame(_reflection);
        }
        else
        {
            _billboard.Vframes = 2;
            _billboard.Hframes = 4;
            _billboard.RegionRect = new Rect2(0, 0, 896, 448);

            _reflection.RegionRect = new Rect2(0, 0, 896, 448);
            _reflection.Vframes = 2;
            _reflection.Hframes = 4;
            UpdateRotation();

            texture = PIRATEIdleAnim;
            _reflection.Texture = PIRATEIdleAnim;

            // For editor preview
            if (Engine.IsEditorHint())
            {
                rotationIndex = (int)rotationDegree;
            }

            SetRotationDegree((RotationDegree)Mathf.Wrap(rotationIndex, 0, _billboard.Hframes * _billboard.Vframes));

            if (rotationIndex == 1)
            {
                _reflection.MaterialOverride.Set("params_billboard_mode", SpatialMaterial.BillboardMode.Disabled);
                _reflection.Offset = new Vector2(-4, -67);
                _reflection.RotationDegrees = new Vector3(0, 0, -60);
            }
            else if (rotationIndex == 3)
            {
                _reflection.MaterialOverride.Set("params_billboard_mode", SpatialMaterial.BillboardMode.Disabled);
                _reflection.Offset = new Vector2(19, -81);
                _reflection.RotationDegrees = new Vector3(-36, -110, 70);
            }
            else
            {
                _reflection.MaterialOverride.Set("params_billboard_mode", SpatialMaterial.BillboardMode.Disabled);
                _reflection.Offset = new Vector2(0, -90);
                //_reflection.RotationDegrees = new Vector3(0, -45, 0);
            }

            _reflection.Frame = (Mathf.Wrap(rotationIndex, 0, _billboard.Hframes * _billboard.Vframes));

            // TODO: WaterOverlay fading transition effect
        }
    }

    public void AnimateWaterOverlay()
    {
        if (animationPlayer.IsPlaying())
        {
            currentAnimPosition = animationPlayer.CurrentAnimationPosition;
        }

        if (isMoving || debugIsMoving)
        {
            waterOverlay1.Frame = Mathf.Wrap(waterOverlay1.Frame + 1, 0, waterOverlay1.Vframes * waterOverlay1.Hframes);
            waterOverlay2.Frame = Mathf.Wrap(waterOverlay2.Frame + 1, 0, waterOverlay2.Vframes * waterOverlay2.Hframes);

            switch (rotationDegree)
            {
                case RotationDegree.ZERO:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(0, -45, 0), new Vector2(0, -90), false, true);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(0, -45, 0), new Vector2(0, 16), false, false);
                    break;
                case RotationDegree.FORTYFive:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(0, -90, 0), new Vector2(0, -90), false, true);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(0, -90, 0), new Vector2(0, 16), false, false);
                    break;
                case RotationDegree.NINETY:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -135, 0), new Vector2(32, -45), false, true);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -135, 0), new Vector2(32, 48), false, false);
                    break;
                case RotationDegree.ONEThirtyFive:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -180, 0), new Vector2(32, 90), false, false);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, 0, 0), new Vector2(-32, 16), true, false);
                    break;
                case RotationDegree.ONEEighty:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, -225, 0), new Vector2(0, 104), false, false);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -45, 0), new Vector2(0, 0), true, false);
                    break;
                case RotationDegree.TWOTwentyFive:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 90, 0), new Vector2(-16, 90), false, false);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -90, 0), new Vector2(16, 16), true, false);
                    break;
                case RotationDegree.TWOSeventy:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 45, 0), new Vector2(-32, 51), false, false);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, -135, 0), new Vector2(32, 48), true, false);
                    break;
                case RotationDegree.THREEFifteen:
                    UpdateWaterOverlay(waterOverlay1, new Vector3(-90, 0, 0), new Vector2(-32, -90), false, true);
                    UpdateWaterOverlay(waterOverlay2, new Vector3(-90, 0, 0), new Vector2(-32, 16), false, false);

                    break;
            }

            if (!waterOverlay.Visible || animationPlayer.CurrentAnimation == "fade_out")
            {
                waterOverlay.Visible = true;
                animationPlayer.Play("fade_in");
            }
        }
        else
        {
            if (waterOverlay.Visible || animationPlayer.CurrentAnimation == "fade_in")
            {
                animationPlayer.Play("fade_out");

                // warning-ignore:shadowedVariable
            }
        }
    }

    public void UpdateWaterOverlay(
        Sprite3D waterOverlay,
        Vector3 rotation,
        Vector2 offset,
        bool flipH,
        bool flipV)
    {
        waterOverlay.RotationDegrees = rotation;
        waterOverlay.Offset = offset;
        waterOverlay.FlipH = flipH;
        waterOverlay.FlipV = flipV;
    }

    public void UpdateRotation()
    {
        rotationIndex = Mathf.Wrap(direction + rotationOffset, 0, PIRATEMoveAnim.Count);
    }

    public void _OnAnimationPlayerAnimationStarted(String animName)
    {
        if (!IsInsideTree() || Engine.IsEditorHint())
        {
            return;
        }

        if (lastAnim != animationPlayer.CurrentAnimation)
        {
            animationPlayer.Seek(currentAnimPosition); // FIXME: PlayBackwards()
            //		GD.PrintS("Last animation:", lastAnim)
            //		GD.PrintS("Play animation:", animationPlayer.current_animation)
            //		GD.PrintS("Current position:", animationPlayer.current_animation_position)
        }

        lastAnim = animName;
    }

    public void _OnAnimationPlayerAnimationFinished(String animName)
    {
        //prints("Animation finished:", animName)
        if (animName == "fade_out" && !isMoving)
        {
            waterOverlay.Visible = false;
        }
    }
}