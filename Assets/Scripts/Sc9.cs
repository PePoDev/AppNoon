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

			if (PlayerPrefs.GetInt("lastMonth", 0) == i + 1)
			{
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

		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	private void OnSelectionChanged(int index)
	{
		m_index = index;
	}
}