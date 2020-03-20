using System;
using FancyScrollView.Example02;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Sc6 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;

	public Image cake;
	
	public ItemData[] items;

	private void OnEnable()
	{
	}

	private void Start()
	{
		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	public void OnSelect(int index)
	{
		Debug.Log($"Select topping id: {index}");
	}
}