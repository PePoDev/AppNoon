using System;
using System.Collections;
using System.Collections.Generic;
using GameFlow;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Toggle = UnityEngine.UIElements.Toggle;

public class PostCell : MonoBehaviour
{
	public Image picture;
	public TextMeshProUGUI name;
	public TextMeshProUGUI story;
	public TextMeshProUGUI date;
	public Image image;
	public Image react1;
	public Image react2;
	public Image react3;

	public Sprite on, off;

	public Database db;
	public Post post;

	public void reactButton1()
	{
		if (post.react1) return;
		
		react1.overrideSprite = on;
		post.react1 = true;
		
		PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + 1);
		PlayerPrefs.Save();
		
		Database.Set(db);
	}
	
	public void reactButton2()
	{
		if (post.react2) return;
		
		react2.overrideSprite = on;
		post.react2 = true;
		
		PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + 1);
		PlayerPrefs.Save();
		
		Database.Set(db);
	}
	
	public void reactButton3()
	{
		if (post.react3) return;
		
		react3.overrideSprite = on;
		post.react3 = true;
		
		PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + 1);
		PlayerPrefs.Save();
		
		Database.Set(db);
	}
}