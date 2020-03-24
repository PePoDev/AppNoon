using System;
using FancyScrollView.Example02;
using UnityEngine;

public class Sc6 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;

	public Cake cake;
	
	public ItemData[] items;

	private void OnEnable()
	{
		var isNewDay = PlayerPrefs.GetInt("lastDay") != DateTime.Now.Day;
		scrollView.gameObject.SetActive(isNewDay);
	}

	private void Start()
	{
		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	public void OnSelect(int index)
	{
		cake.AddToppingId(index);
		PlayerPrefs.SetInt("lastDay", DateTime.Now.Day);
	}
}