using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
	private void OnEnable()
	{
		GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("point").ToString() + " Pt";
	}
}
