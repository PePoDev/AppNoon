using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example02;
using UnityEditor.VersionControl;

public class Sc4 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private GameObject content = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;

	public ItemData[] items;

	private int m_index = 0;

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