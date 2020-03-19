using FancyScrollView.Example02;
using UnityEngine;
using UnityEngine.UI;

public class Sc6Scroller : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;

	public ItemData[] items;

	private void Start()
	{
		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	public void OnSelect(int index)
	{
		Debug.Log(index);
	}
}