using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class CameraControls : Node
{
    public const int ZOOMInLimit = 10;
    public const int ZOOMOutLimit = 60;
    public const int ZOOMValue = 5;
    public const int RAYLength = 1000;

    public const int MOVESpeed = 1;
    public const int MOVEFasterMult = 2;

    public NodePath originPath;
    public NodePath cameraPath;
    public NodePath rotationYPath;

    private Spatial _origin;
    private Camera _camera;
    private Spatial _rotationY;
    private Viewport _viewport;
    private Vector2 _viewportSize;
    private float _viewportAspect;

    private Basis _basis;
    private Vector2 _dragPos;

    public bool enabled
    {
        get { return GetEnabled(); }
        set { SetEnabled(value); }
    }

    public void Ready()
    {
        _origin = GetNode(originPath) as Spatial;
        _camera = GetNode(cameraPath) as Camera;
        _rotationY = GetNode(rotationYPath) as Spatial;
        _viewport = GetViewport();
        _viewportSize = _viewport.Size;
        _viewportAspect = _viewportSize.Aspect();
        if (_viewport.Connect("size_changed", this, "_on_viewport_size_changed") != Error.Ok)
        {
            GD.PushError("Failed To Connect Viewport");
        }

        _basis = _GetBasis();
    }

    public void _Process(float delta)
    {
        _Move(delta);
        _MoveDrag();
    }

    public void _Input(InputEvent ev)
    {
        if (ev.IsActionPressed("rotate_left"))
        {
            _Rotate((float)(-Math.PI / 2));
        }
        else if (ev.IsActionPressed("rotate_right"))
        {
            _Rotate((float)(Math.PI / 2));
        }
        else if (ev.IsActionPressed("zoom_in"))
        {
            if (_camera.Size > ZOOMInLimit)
            {
                _Zoom(-ZOOMValue);
            }
        }
        else if (ev.IsActionPressed("zoom_out"))
        {
            if (_camera.Size < ZOOMOutLimit)
            {
                _Zoom(ZOOMValue);
            }
        }
    }

    public void _Move(float delta)
    {
        float movementScale = delta * MOVESpeed * _camera.Size;
        if (Input.IsActionPressed("move_faster"))
        {
            movementScale *= MOVEFasterMult;
        }

        var x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        var y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        Vector2 movementVelocity = new Vector2(x, y * _viewportAspect);
        _origin.Translate(_basis.Xform(UUtils.Map2To3(movementVelocity)) * movementScale);
    }

    public void _MoveDrag()
    {
        if (Input.IsActionPressed("move_drag"))
        {
            var newDragPos = _viewport.GetMousePosition();
            if (Input.IsActionJustPressed("move_drag"))
            {
                _dragPos = newDragPos;
            }
            else
            {
                // DEBUG
                //if newDragPos != _dragPos:
                //	GD.PrintS(_dragPos, "=>", newDragPos)
                var dragDir = (_dragPos - newDragPos) * _camera.Size / _viewportSize * 6;
                var moveDir = _basis.Xform(UUtils.Map2To3(dragDir));
                _origin.Translate(moveDir);
                _dragPos = newDragPos;
            }
        }
    }

    public void _Rotate(float rotation)
    {
        _rotationY.RotateY(rotation);
        _basis = _GetBasis();
    }

    public void _Zoom(float zoomValue)
    {
        var mPos = _viewport.GetMousePosition();
        var startResult = _RaycastFromMouse(mPos, 1);
        _camera.Size += zoomValue;
        var endResult = _RaycastFromMouse(mPos, 1);
        if (startResult.Equals(endResult))
        {
            var moveDir = (Vector3)startResult["position"] - (Vector3)endResult["position"];
            _origin.Translate(moveDir);
        }
    }

    public Dictionary _RaycastFromMouse(Vector2 mPos, uint collisionMask)
    {
        var rayStart = _camera.ProjectRayOrigin(mPos);
        var rayEnd = rayStart + _camera.ProjectRayNormal(mPos) * RAYLength;
        var spaceState = _origin.GetWorld().DirectSpaceState;
        return spaceState.IntersectRay(rayStart, rayEnd, null, collisionMask);
    }

    public Basis _GetBasis()
    {
        return _rotationY.GetTransform().basis;
    }

    public void SetEnabled(bool newValue)
    {
        enabled = newValue;

        SetProcess(enabled);
        SetProcessInput(enabled);
    }

    public bool GetEnabled()
    {
        return enabled;
    }

    public void _OnViewportSizeChanged()
    {
        _viewportSize = _viewport.Size;
        _viewportAspect = _viewportSize.Aspect();
    }
}