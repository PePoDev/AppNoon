using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example02;

public class Sc5 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private GameObject content = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;
	[SerializeField] private Button selectButton = default;

	public ItemData[] items;

	private int m_index = 0;

	private void OnEnable()
	{
		var isNewMonth = PlayerPrefs.GetInt("lastMonth", 0) != DateTime.Now.Month;
		// cake.gameObject.SetActive(!isNewMonth);
		// scrollView.gameObject.SetActive(isNewMonth);

		// content.SetActive(isNewMonth);
		selectButton.interactable = isNewMonth;
		// prevCellButton.interactable = isNewMonth;
		// nextCellButton.interactable = isNewMonth;
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

		if (PlayerPrefs.GetInt("lastMonth", 0) != DateTime.Now.Month)
		{
			selectButton.interactable = items[m_index].usable;
		}
	}

	// ReSharper disable once MemberCanBePrivate.Global
	public void SelectCake()
	{
		var db = Database.Get();

		db.cake.id = m_index;

		Database.Set(db);
		PlayerPrefs.SetInt("lastMonth", DateTime.Now.Month);
		PlayerPrefs.Save();
	}
}