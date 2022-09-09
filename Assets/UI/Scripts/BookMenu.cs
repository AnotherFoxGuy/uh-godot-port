using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;


public class BookMenu : CenterContainer
{
    //signal tabIndexChanged

    // warning-ignore:unusedClassVariable
    public TabContainer parent = null;

    [Export]
    bool hasDeleteButton
    {
        set { SetHasDeleteButton(value); }
        get => _hasDeleteButton;
    }

    private bool _hasDeleteButton;

    [Export]
    bool hasCancelButton
    {
        set { SetHasCancelButton(value); }
        get => _hasCancelButton;
    }
    private bool _hasCancelButton;

    [Export]
    bool hasOkButton
    {
        set { SetHasOkButton(value); }
        get => _hasOkButton;
    }
    private bool _hasOkButton;

    TabContainer pages; //= $Pages as TabContainer

    public void _Ready()
    {
        pages = GetNode<TabContainer>("Pages");
        
        Spatial pageControl;
        foreach (Spatial page in pages.GetChildren())
        {
            if (pages.GetTabCount() > 1)
            {
                pageControl = page.FindNode("PageControl") as Spatial;
                pageControl.GetNode("PrevButton").Connect("pressed", this, "_on_PrevButton_pressed");
                pageControl.GetNode("NextButton").Connect("pressed", this, "_on_NextButton_pressed");

                pageControl.Visible = true;

                // warning-ignore:returnValueDiscarded
                //connect("tab_index_changed", this, "_on_Pages_tab_changed")
            }
        }

        pages.Connect("tab_changed", this, "_on_Pages_tab_changed");

        // Force-call to determine initial state of page Controls (enabled/disabled)
        pages.EmitSignal("tab_changed", pages.CurrentTab);
    }

    public async void SetHasDeleteButton(bool newHasDeleteButton)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _hasDeleteButton = newHasDeleteButton;

        string pressedSignal = "pressed";
        string callbackFunction = "_on_DeleteButton_pressed";

        foreach (Spatial page in pages.GetChildren())
        {
            var deleteButton = page.FindNode("DeleteButton") as Button;
            if (!deleteButton.IsConnected(pressedSignal, this, callbackFunction))
            {
                // warning-ignore:returnValueDiscarded
                deleteButton.Connect(pressedSignal, this, callbackFunction);
            }

            deleteButton.Visible = _hasDeleteButton;
        }
    }

    public async void SetHasCancelButton(bool newHasCancelButton)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _hasCancelButton = newHasCancelButton;

        string pressedSignal = "pressed";
        string callbackFunction = "_on_CancelButton_pressed";

        foreach (Node page in pages.GetChildren())
        {
            // Place CancelButton on
            //	left side for one-paged menus
            //	right side for multi-paged menus
            Button cancelButton;
            if (pages.GetChildCount() > 1)
            {
                cancelButton = page.FindNode("RightPage").FindNode("CancelButton") as Button;
            }
            else
            {
                cancelButton = page.FindNode("CancelButton") as Button;
            }

            if (!cancelButton.IsConnected(pressedSignal, this, callbackFunction))
            {
                // warning-ignore:returnValueDiscarded
                cancelButton.Connect(pressedSignal, this, callbackFunction);
            }

            cancelButton.Visible = _hasCancelButton;
        }
    }

    public async void SetHasOkButton(bool newHasOkButton)
    {
        if (!IsInsideTree())
        {
            await ToSignal(this, "ready");
            _OnReady();
        }

        _hasOkButton = newHasOkButton;

        string pressedSignal = "pressed";
        string callbackFunction = "_on_OKButton_pressed";

        foreach (Node page in pages.GetChildren())
        {
            var okButton = page.FindNode("OKButton") as Button;
            if (!okButton.IsConnected(pressedSignal, this, callbackFunction))
            {
                // warning-ignore:returnValueDiscarded
                okButton.Connect("pressed", this, "_on_OKButton_pressed");
            }

            okButton.Visible = _hasOkButton;
        }
    }

    public void _OnPrevButtonPressed()
    {
        //prints("_on_PrevButton_pressed", "current_tab:", pages.current_tab)
        Audio.Instance.PlaySndClick();

        pages.CurrentTab -= 1;
        //emit_signal("tab_index_changed")
        pages.EmitSignal("tab_changed", pages.CurrentTab);
    }

    public void _OnNextButtonPressed()
    {
        //prints("_on_NextButton_pressed", "current_tab:", pages.current_tab)
        Audio.Instance.PlaySndClick();

        pages.CurrentTab += 1;
        //emit_signal("tab_index_changed")
        pages.EmitSignal("tab_changed", pages.CurrentTab);
    }

    public void _OnPagesTabChanged(int tab)
    {
        //var tabCount = pages.GetTabCount();
        //var currentTab = pages.current_tab;
        var currentTabControl = pages.GetCurrentTabControl();
        var currentPageControl = currentTabControl.FindNode("PageControl");

        //	if pages.GetTabCount() <= 1:
        //		pageControl.GetNode("PrevButton").disabled = true;
        //		pageControl.GetNode("NextButton").disabled = true;
        currentPageControl.GetNode<Button>("PrevButton").Disabled = true;
        currentPageControl.GetNode<Button>("NextButton").Disabled = true;
        if (pages.GetTabCount() > 1)
        {
            if (0 < tab)
            {
                currentPageControl.GetNode<Button>("PrevButton").Disabled = false;
            }

            if (tab < pages.GetTabCount() - 1)
            {
                currentPageControl.GetNode<Button>("NextButton").Disabled = false;
            }
        }
    }

    public void _OnDeleteButtonPressed()
    {
        //print("_on_DeleteButton_pressed")
        Audio.Instance.PlaySndClick();
    }

    public void _OnCancelButtonPressed()
    {
        //print("_on_CancelButton_pressed")
        Audio.Instance.PlaySndClick();

        if (parent != null)
        {
            parent.Visible = true;
        }

        QueueFree();
    }

    public void _OnOKButtonPressed()
    {
        //print("_on_OKButton_pressed")
        Audio.Instance.PlaySndClick();

        if (parent != null)
        {
            parent.Visible = true;
        }

        QueueFree();
    }

    public void _OnReady()
    {
        // if(!pages)
        // 	 pages = $Pages
    }
}