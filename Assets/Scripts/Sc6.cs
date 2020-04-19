using System;
using Doozy.Engine.UI;
using FancyScrollView.Example02;
using UnityEngine;
using UnityEngine.Events;

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

			db.toppingHistory[DateTime.Now.Month - 1].days[DateTime.Now.Day - 1] = index + 1;
			Database.Set(db);
			
			cake.AddToppingId(index);
			PlayerPrefs.SetInt("lastDay", DateTime.Now.Day);
			PlayerPrefs.Save();
		}
	}

	public UnityEvent onAddMood;
	public void AddMood()
	{
		var db = Database.Get();
		if (!db.toppingHistory[DateTime.Now.Month - 1].hp[DateTime.Now.Day - 1].Equals("") || db.cake.id == -1)
		{
			return;
		}
		
		onAddMood.Invoke();
	}
}