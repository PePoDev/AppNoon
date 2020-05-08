using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sc10 : MonoBehaviour
{
	public Sc8 sc8;
	
	public Image calenda;
	public Cake cake;
	public Image[] days;

	public Sprite[] months;
	public Sprite[] topping;

	public GameObject dialog;
	public Image picture;
	public TextMeshProUGUI decs;
	public TextMeshProUGUI hp;
	
	private int m_curentMonth = 0;

	private void OnEnable()
	{
		m_curentMonth = DateTime.Now.Month - 1;
		ChangeMonth(0);
	}

	public void ChangeMonth(int i)
	{
		m_curentMonth += i;
		if (m_curentMonth < 0)
			m_curentMonth = 0;
		if (m_curentMonth > 11)
			m_curentMonth = 11;
		
		Debug.Log("current month: " + m_curentMonth);
		
		calenda.overrideSprite = months[m_curentMonth];

		if (PlayerPrefs.GetInt("lastMonth", 0) == m_curentMonth + 1)
		{
			Debug.Log("this month");

			cake.NotCustom();
			cake.OnEnable();
		}
		else
		{
			Debug.Log("another month");
			
			cake.LoadMonth(m_curentMonth);
		}

		foreach (var day in days)
		{
			day.enabled = false;
			day.raycastTarget = false;
		}

		if (!Database.HasDatabase()) return;
		var db = Database.Get();

		var toppingsHistory = db.toppingHistory[m_curentMonth];
		var j = 0;
		var k = 0;
		foreach (var day in days)
		{
			if (k < totalSkip(m_curentMonth + 1))
			{
				k += 1;
				continue;
			}

			if (toppingsHistory.days[j] > 0)
			{
				day.enabled = true;
				day.raycastTarget = true;
				day.overrideSprite = topping[toppingsHistory.days[j] - 1];
				day.GetComponent<day>().index = j;
			}
			
			j++;

			if (j > 30)
			{
				break;
			}
		}

		int totalSkip(int month)
		{
			var x = 0;
			switch (month)
			{
				case 1:
					x = 3;
					break;
				case 2:
					x = 6;
					break;
				case 3:
					x = 0;
					break;
				case 4:
					x = 3;
					break;
				case 5:
					x = 5;
					break;
				case 6:
					x = 1;
					break;
				case 7:
					x = 3;
					break;
				case 8:
					x = 6;
					break;
				case 9:
					x = 2;
					break;
				case 10:
					x = 4;
					break;
				case 11:
					x = 0;
					break;
				case 12:
					x = 2;
					break;
			}
			return x;
		}
	}

	public void OpenDialog(int day)
	{
		var db = Database.Get();
		var pId = db.toppingHistory[DateTime.Now.Month - 1].pictureId[DateTime.Now.Day - 1];
		var pG = db.toppingHistory[DateTime.Now.Month - 1].pictureGroup[DateTime.Now.Day - 1];
		
		hp.text = db.toppingHistory[DateTime.Now.Month - 1].hp[DateTime.Now.Day - 1];
		decs.text = db.toppingHistory[DateTime.Now.Month - 1].decs[DateTime.Now.Day - 1];

		if (hp.text.Equals(""))
		{
			return;
		}
		
		picture.overrideSprite = sc8.items2[pG].items[pId].sprite;
		
		dialog.SetActive(true);
	}
}