using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example02;

public class Sc5 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;

	public ItemData[] items;
	public Button select;

	private void Start()
	{
		prevCellButton.onClick.AddListener(scrollView.SelectPrevCell);
		nextCellButton.onClick.AddListener(scrollView.SelectNextCell);
		scrollView.OnSelectionChanged(OnSelectionChanged);

		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	private int m_index = 0;
	private void OnSelectionChanged(int index)
	{
		m_index = index;
		select.interactable = items[m_index].usable;
	}

	public void SelectCake()
	{
		Singleton.selectedCake = m_index;
	}
}