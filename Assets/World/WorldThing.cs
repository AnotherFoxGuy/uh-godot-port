using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class WorldThing : Spatial
{
    public static readonly Array<Vector3> TRANSLATIONPerAngle = new Array<Vector3>
    {
        new Vector3(-50, 49.51f, 50),
        new Vector3(50, 49.51f, 50),
        new Vector3(50, 49.51f, -50),
        new Vector3(-50, 49.51f, -50),
    };

    public enum RotationStep
    {
        NINETY = 1,
        FOURTYFive = 2,
    }

    public enum RotationDegree
    {
        ZERO,
        FORTYFive,
        NINETY,
        ONEThirtyFive,
        ONEEighty,
        TWOTwentyFive,
        TWOSeventy,
        THREEFifteen
    }

    [Export]
    internal Texture texture
    {
        set => SetTexture(value);
        get => _texture;
    }

    private Texture _texture;

    [Export]
    private RotationStep rotationStep
    {
        set => SetRotationStep(value);
        get => _rotationStep;
    }

    private RotationStep _rotationStep;

    [Export]
    internal RotationDegree rotationDegree
    {
        set => SetRotationDegree(value);
        get => _rotationDegree;
    }

    private RotationDegree _rotationDegree;

    internal Sprite3D _billboard;
    Sprite3D _outline;

    public int currentRotation = 0;
    public bool visible ;

    public void _Ready()
    {
        _outline = _billboard.GetNode("Outline") as Sprite3D;
        // Retry exported properties setters after all nodes are ready.
        SetTexture(texture);
        SetRotationStep(rotationStep);
        SetRotationDegree(rotationDegree);

        if (!Engine.IsEditorHint())
        {
            _RecalculateTranslation(null);
        }
    }

    public void _Process(float _delta)
    {
        if (Engine.IsEditorHint())
        {
            if (_billboard == null)
            {
                GD.Print($"Please reload the scene [new Dictionary(){Name}].");
                SetProcess(false);
                return;

                // Prevent things "falling" through the GridMap when drag'n'dropping
                // nodes from the hierarchy to the map;
                // keep everything on the same height at all time.
            }

            if (Translation.y != 0)
            {
                var x = Translation;
                x.y = 0;
                Translation = x;
            }
        }
    }

    public override void _UnhandledInput(InputEvent ev)
    {
        _RecalculateTranslation(ev);
        _OnInput(ev);
    }

    public void _OnInput(InputEvent ev)
    {
        // Switch frame accordingly with the world rotation.
        if (ev.IsActionPressed("rotate_left"))
        {
            _billboard.Frame = Mathf.Wrap(_billboard.Frame - (int)rotationStep, 0,
                _billboard.Hframes * _billboard.Vframes);
        }
        else if (ev.IsActionPressed("rotate_right"))
        {
            _billboard.Frame = Mathf.Wrap(_billboard.Frame + (int)rotationStep, 0,
                _billboard.Hframes * _billboard.Vframes);
        }
    }

    public void _RecalculateTranslation(InputEvent ev = null)
    {
        if (ev == null)
        {
            _billboard.Translation = TRANSLATIONPerAngle[0];
            return;
        }

        if (ev.IsActionPressed("rotate_left"))
        {
            currentRotation = Mathf.Wrap(currentRotation - 1, 0, TRANSLATIONPerAngle.Count);
            _billboard.Translation = TRANSLATIONPerAngle[currentRotation];
            //prints(this, "translation:", _billboard.translation)
        }
        else if (ev.IsActionPressed("rotate_right"))
        {
            currentRotation = Mathf.Wrap(currentRotation + 1, 0, TRANSLATIONPerAngle.Count);
            _billboard.Translation = TRANSLATIONPerAngle[currentRotation];
            //prints(this, "translation:", _billboard.translation)
        }
    }

    public int NextFrame(Sprite3D sp = null)
    {
        var sprite = sp ?? _billboard;
        return Mathf.Wrap(sprite.Frame + 1, 0, sprite.Vframes * sprite.Hframes);
    }

    public int PrevFrame(Sprite3D sp = null)
    {
        var sprite = sp ?? _billboard;
        return Mathf.Wrap(sprite.Frame - 1, 0, sprite.Vframes * sprite.Hframes);
    }

    public int GetRandomFrame(Sprite3D sp = null)
    {
        var sprite = sp ?? _billboard;
        return (int)(GD.Randi() % (sprite.Vframes * sprite.Hframes));
    }

    public void SetTexture(Texture newTexture)
    {
        texture = newTexture;

        if (!IsInsideTree() || _billboard == null)
        {
            return;
        }

        _billboard.Texture = texture;

        // Set up outline for object highlighting
        if (texture != null)
        {
            _outline.Texture = _billboard.Texture;
            _outline.Hframes = _billboard.Hframes;
            _outline.Vframes = _billboard.Vframes;
            _outline.RegionRect = _billboard.RegionRect;
            _outline.RegionEnabled = _billboard.RegionEnabled;
            _outline.Offset = _billboard.Offset;

            var material = new SpatialMaterial();
            material.FlagsTransparent = true;
            //material.flags_no_depth_test = true;
            material.ParamsBillboardMode = SpatialMaterial.BillboardMode.Enabled;
            material.ParamsUseAlphaScissor = true;
            material.ParamsAlphaScissorThreshold = 0.05f;
            material.AlbedoTexture = texture;
            material.EmissionEnabled = true;
            material.Emission = new Color(1, 1, 1, 1);
            _outline.MaterialOverride = material;
        }
        else
        {
            _outline.MaterialOverride = null;

            // Every Sprite3D should be a billboard
        }

        _billboard.Billboard = SpatialMaterial.BillboardMode.Enabled;
        _billboard.Transparent = true;
        _billboard.MaterialOverride = null;
    }

    public void SetRotationStep(RotationStep newStep)
    {
        rotationStep = newStep;

        if (!IsInsideTree() || _billboard == null)
        {
            return;

            //match newStep:
            //	RotationStep.FOURTY_FIVE:
            //		_billboard.Hframes = 4;
            //	RotationStep.NINETY:
            //		_billboard.Hframes = 2;
        }
    }

    public void SetRotationDegree(RotationDegree newRotation)
    {
        rotationDegree = newRotation;

        if (!IsInsideTree() || _billboard == null)
        {
            return;
        }

        switch (rotationStep)
        {
            case RotationStep.FOURTYFive: // Units.
                _billboard.Frame = (int)rotationDegree;
                break;
            case RotationStep.NINETY: // Buildings.
                if ((int)rotationDegree % 2 != 0)
                {
                    GD.PrintErr(GD.Str(Name) +
                                " - Invalid rotation for current rotation step.");

                    return;

                    //warning-ignore:integerDivision
                }

                _billboard.Frame = (int)rotationDegree / 2;

                //
                // TODO: Cursor callback logic actually goes into the Interaction system &&
                // shouldn't be controlled by the WorldThing classes themselves.
                //
                break;
        }
    }

    public void _OnAreaInputEvent(Node camera, InputEvent ev, Vector3 position, Vector3 _normal, int _shapeIdx)
    {
        //prints("WorldThing::_OnAreaInputEvent()")
        //print("{0} {1} {2} {3} {4}".Format(new Array(){camera, event, clickPosition, clickNormal, shapeIdx}))
        //var playerCamera := camera as PlayerCamera
        //player_camera.hovered_object = this;
    }

    public void _OnAreaMouseEntered()
    {
        GD.PrintS("WorldThing::_OnAreaMouseEntered()");
        if (Global.Game.player != null && Global.Game.player.camera != null)
        {
            Global.Game.player.camera._OnWorldThingMouseEntered(this);
            //_billboard.alpha_cut = SpriteBase3D.ALPHA_CUT_OPAQUE_PREPASS;
        }

        _outline.Visible = true;
    }

    public void _OnAreaMouseExited()
    {
        GD.Print("WorldThing::_OnAreaMouseExited()");
        if (Global.Game.player != null && Global.Game.player.camera != null)
        {
            Global.Game.player.camera._OnWorldThingMouseExited(this);
            //_billboard.alpha_cut = SpriteBase3D.ALPHA_CUT_DISABLED;
        }

        _outline.Visible = false;
    }

    public void _OnBillboardFrameChanged()
    {
        if (_billboard == null)
        {
            return;

            // Sync frames
            //prints("_outline:", _outline, "_billboard:", _billboard)
            //prints("_outline.frame:", _outline.frame, "_billboard.Frame:", _billboard.Frame)
        }

        _outline.Frame = _billboard.Frame;
    }

    public void _OnExit()
    {
        
    }

    public void _OnEnter()
    {
        
    }
}