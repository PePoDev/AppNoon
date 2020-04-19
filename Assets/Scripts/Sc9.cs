using System;
using System.Collections;
using System.Collections.Generic;
using FancyScrollView.Example02;
using UnityEngine;
using UnityEngine.UI;

public class Sc9 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private GameObject content = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;

	public ItemData[] items;

	public Cake[] cakes;

	private int m_index = 0;

	private void OnEnable()
	{
		int i = -1;
		foreach (var cake in cakes)
		{
			i++;

			if (PlayerPrefs.GetInt("lastMonth", DateTime.Now.Month) == i + 1)
			{
				cake.gameObject.SetActive(true);
				continue;
			}

			cake.LoadMonth(i);
		}
	}

	private void Start()
	{
		prevCellButton.onClick.AddListener(scrollView.SelectPrevCell);
		nextCellButton.onClick.AddListener(scrollView.SelectNextCell);
		scrollView.OnSelectionChanged(OnSelectionChanged);

		var db = Database.Get();

		var temp = new int[6];
		for (int i = 0; i < 12; i++)
		{
			for (int j = 0; j < 31; j++)
			{
				if (db.toppingHistory[i].days[j] == 0) continue;
				temp[db.toppingHistory[i].days[j] - 1]++;
			}
		}

		for (int i = 0; i < 6; i++)
		{
			items[i].value = temp[i];
		}

		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	private void OnSelectionChanged(int index)
	{
		m_index = index;
	}
}