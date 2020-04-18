using System;
using FancyScrollView.Example02;
using UnityEngine;

public class Sc6 : MonoBehaviour
{
	public ScrollView scrollView = default;
	
	public Cake cake;
	
	public ItemData[] items;

	private void OnEnable()
	{
		var isNewDay = PlayerPrefs.GetInt("lastDay") != DateTime.Now.Day;
		// scrollView.gameObject.SetActive(isNewDay);
		if (!Database.HasDatabase()) return;

		var db = Database.Get();

		if (db.cake.id != -1)
		{
			cake.gameObject.SetActive(true);
			return;
		}
	}

	private void Start()
	{
		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	public void OnSelect(int index)
	{
		var isNewDay = PlayerPrefs.GetInt("lastDay") != DateTime.Now.Day;
		// scrollView.gameObject.SetActive(isNewDay);
		if (!Database.HasDatabase()) return;

		var db = Database.Get();

		if (db.cake.id != -1)
		{
			if (PlayerPrefs.GetInt("lastDay") == DateTime.Now.Day)
				return;
		
			cake.AddToppingId(index);
			PlayerPrefs.SetInt("lastDay", DateTime.Now.Day);
		}
		
	}
}