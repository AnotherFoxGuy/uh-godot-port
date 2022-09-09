using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class SelectionBox : Control
{
    public Vector2 selPosStart = new Vector2(); // first click position

    [Export] Color lineColor = new Color(1, 1, 1);
    [Export] int lineWidth = 1;

    public void _Process(float _delta)
    {
        Update();
    }

    public void _Draw()
    {
        if (IsVisible())
        {
            var mPos = GetViewport().GetMousePosition();
            //Vector2 topLeft = GetViewport().GetCamera().UnprojectPosition(Utils.Map2To3(selPosStart));
            Vector2 topLeft = selPosStart;
            if (topLeft != mPos)
            {
                DrawLine(topLeft, new Vector2(mPos.x, topLeft.y), lineColor, lineWidth); // upper right
                DrawLine(topLeft, new Vector2(topLeft.x, mPos.y), lineColor, lineWidth); // lower left
                DrawLine(mPos, new Vector2(mPos.x, topLeft.y), lineColor, lineWidth); // upper left
                DrawLine(mPos, new Vector2(topLeft.x, mPos.y), lineColor, lineWidth); // lower right
            }
        }
    }
}