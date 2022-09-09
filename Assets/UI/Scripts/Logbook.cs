using System;
using Godot;
using Godot.Collections;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Logbook : Control
{
    [Export]
    int currentPage
    {
        set { SetCurrentPage(value); }
    }

    private int _currentPage;

    //export(String) string captionText  = "This is a Book Title" {set{SetCaptionText(value);}}
    //export(String, MULTILINE) string bodyText  = "There is nothing written in your logbook yet!" {set{SetBodyText(value);}}
    [Export]
    public Array<Array<string>> pages
    {
        set { SetPages(value); }
    }

    private Array<Array<string>> _pages = new Array<Array<string>>()
    {
        new Array<string>() { "This is a Book Title", "There is nothing written in your logbook yet!" }
    };

    // onready var caption  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/CaptionBlock/Caption
    // onready var body  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/Body

    private CaptionBlock caption;
    private Label body;

    //onready var pageControl  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/PageControl
    Node pageControl;

    public void _Ready()
    {
        caption = GetNode<CaptionBlock>("CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/CaptionBlock/Caption");
        body = GetNode<Label>("CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/Body");

        pageControl = FindNode("PageControl");
        UpdateBook();
    }

    public void SetCurrentPage(int newCurrentPage)
    {
        currentPage = Mathf.Clamp(newCurrentPage, 0, _pages.Count - 1);
        UpdateBook();
    }

    public void UpdateBook()
    {
        UpdateText();
        UpdatePageControl();
    }

    public async void UpdateText()
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");

        if (_pages.Count > 0)
        {
            caption.text = _pages[_currentPage][0];
            body.Text = _pages[_currentPage][1];
        }
        else
        {
            caption.text = "";
            body.Text = "";
        }
    }

    public async void UpdatePageControl()
    {
        if (!IsInsideTree())
            await ToSignal(this, "ready");

        //	if pages.Size() <= 1:
        //		pageControl.GetNode("PrevButton").disabled = true;
        //		pageControl.GetNode("NextButton").disabled = true;
        pageControl.GetNode<Button>("PrevButton").Disabled = true;
        pageControl.GetNode<Button>("NextButton").Disabled = true;
        if (_pages.Count > 1)
        {
            if (0 < _currentPage)
            {
                pageControl.GetNode<Button>("PrevButton").Disabled = false;
            }

            if (_currentPage < _pages.Count - 1)
            {
                pageControl.GetNode<Button>("NextButton").Disabled = false;

                //func SetCaptionText(newCaptionText: String) -> void:
                //	captionText = newCaptionText;
                //
                //	if caption != null:
                //		caption.text = captionText;
                //
                //func SetBodyText(newBodyText: String) -> void:
                //	bodyText = newBodyText;
                //
                //	if body != null:
                //		body.text = bodyText;
            }
        }
    }

    public void SetPages(Array<Array<string>> newPages)
    {
        //	var oldPages = pages;
        _pages = newPages;
        //	if pages.Size() > oldPages.Size(): # new page has been added
        //		pages[pages.Size() - 1] = new Array(){"", ""} ;# always have Array.size == 2
        foreach (var page in _pages)
        {
            if (page.Count != 2)
            {
                page.Resize(2);
            }
        }

        if (!IsInsideTree()) // when setter is invoked too early
            return;
        UpdateBook();
    }

    public void _OnPrevButtonPressed()
    {
        _currentPage -= 1;
    }

    public void _OnNextButtonPressed()
    {
        _currentPage += 1;
    }

    public void _OnOKButtonPressed()
    {
        QueueFree();
    }
}