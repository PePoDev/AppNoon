using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example02;
using UnityEditor.VersionControl;

public class Sc5 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;

	public ItemData[] items;
	public Button select;

	public Image cake;

	private int m_index = 0;

	private void OnEnable()
	{
		var isNewMonth = PlayerPrefs.GetInt("lastMonth") != DateTime.Now.Month;
		cake.gameObject.SetActive(!isNewMonth);
		scrollView.gameObject.SetActive(isNewMonth);
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
		select.interactable = items[m_index].usable;
	}

	// ReSharper disable once MemberCanBePrivate.Global
	public void SelectCake()
	{
		PlayerPrefs.SetInt("mainCake", m_index);
		PlayerPrefs.SetInt("lastMonth", DateTime.Now.Month);
	}
}