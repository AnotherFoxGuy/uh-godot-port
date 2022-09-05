
using System;
using Godot;
using Dictionary = Godot.Collections.Dictionary;
using Array = Godot.Collections.Array;

[Tool]
public class Logbook : Control
{
	 
	Export(int) var currentPage {set{SetCurrentPage(value);}}
	//export(String) string captionText  = "This is a Book Title" {set{SetCaptionText(value);}}
	//export(String, MULTILINE) string bodyText  = "There is nothing written in your logbook yet!" {set{SetBodyText(value);}}
	[Export(Array, String, MULTILINE)]  public Array pages  = new Array(){new Array(){"This is a Book Title", "There is nothing written in your logbook yet!"}} {set{SetPages(value);}}
	
	onready var caption  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/CaptionBlock/Caption
	onready var body  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/Body
	
	//onready var pageControl  = $CenterContainer/TextureRect/MarginContainer/HBoxContainer/LeftPage/PageControl
	onready var pageControl  = FindNode("PageControl");
	
	public void _Ready()
	{  
		UpdateBook();
	
	}
	
	public void SetCurrentPage(int newCurrentPage)
	{  
		currentPage = Mathf.Clamp(newCurrentPage, 0, pages.Size() - 1);
		UpdateBook();
	
	}
	
	public void UpdateBook()
	{  
		UpdateText();
		UpdatePageControl();
	
	}
	
	public async void UpdateText()
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
	
		if(pages.Size() > 0)
		{
			caption.text = pages[currentPage][0];
			body.text = pages[currentPage][1];
		}
		else
		{
			caption.text = "";
			body.text = "";
	
		}
	}
	
	public async void UpdatePageControl()
	{  
		if(!is_inside_tree())
			 await ToSignal(this, "ready")
	
	//	if pages.Size() <= 1:
	//		pageControl.GetNode("PrevButton").disabled = true;
	//		pageControl.GetNode("NextButton").disabled = true;
		pageControl.GetNode("PrevButton").disabled = true;
		pageControl.GetNode("NextButton").disabled = true;
		if(pages.Size() > 1)
		{
			if(0 < currentPage)
			{
				pageControl.GetNode("PrevButton").disabled = false;
			}
			if(currentPage < pages.Size() - 1)
			{
				pageControl.GetNode("NextButton").disabled = false;
	
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
	
	public void SetPages(Array newPages)
	{  
	//	var oldPages = pages;
		pages = newPages;
	//	if pages.Size() > oldPages.Size(): # new page has been added
	//		pages[pages.Size() - 1] = new Array(){"", ""} ;# always have Array.size == 2
		foreach(var page in pages)
		{
			if(page.Size() != 2)
			{
				page.Resize(2);
	
			}
		}
		if(!is_inside_tree()) // when setter is invoked too early
			 return;
		UpdateBook();
	
	}
	
	public void _OnPrevButtonPressed()
	{  
		self.current_page -= 1;
	
	}
	
	public void _OnNextButtonPressed()
	{  
		self.current_page += 1;
	
	}
	
	public void _OnOKButtonPressed()
	{  
		QueueFree();
	
	
	}
	
	
	
}