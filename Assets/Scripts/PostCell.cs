using System;
using System.Collections;
using System.Collections.Generic;
using GameFlow;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
	public Sc11 sc11;
}