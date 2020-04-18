using System;
using System.Collections;
using System.Collections.Generic;
using FancyScrollView.Example02;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Items
{
	public ItemData[] items;
}

public class Sc8 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private GameObject content = default;
	public ItemData[] items;

	[SerializeField] private ScrollView scrollView2 = default;
	public Items[] items2;

	public Image face;
	public Sprite[] statusFace;
	public TextMeshProUGUI statusText;

	public TextMeshProUGUI text;

	public GameObject dialog;
	public Sprite[] messages;
	public Image message;

	public Image picked;

	private int i = -1;
	private int j = -1;
	private int resultIndex = 0;

	private void Start()
	{
		scrollView.UpdateData(items);
		scrollView.SelectCell(0);
	}

	public void OnSelect(int index)
	{
		scrollView.gameObject.SetActive(false);

		scrollView2.gameObject.SetActive(true);
		scrollView2.UpdateData(items2[index].items);
		i = index;
		scrollView2.SelectCell(0);
		scrollView2.OnSelectionChanged(OnSelection);
	}

	private void OnSelection(int index)
	{
		j = index;
		picked.overrideSprite = items2[i].items[j].sprite;
	}

	public void OnValueChanged(float Single)
	{
		face.overrideSprite = statusFace[(int) (Single / 4)];
		statusText.text = $"{Single - 5} HP";
		resultIndex = (int) Single;
	}

	public void Note()
	{
		if (i == -1)
			return;

		var db = Database.Get();
		db.toppingHistory[DateTime.Now.Month - 1].pictureId[DateTime.Now.Day - 1] = j;
		db.toppingHistory[DateTime.Now.Month - 1].pictureGroup[DateTime.Now.Day - 1] = i;
		db.toppingHistory[DateTime.Now.Month - 1].decs[DateTime.Now.Day - 1] = text.text;
		db.toppingHistory[DateTime.Now.Month - 1].hp[DateTime.Now.Day - 1] = statusText.text;
		Database.Set(db);
		
		dialog.SetActive(true);
		message.overrideSprite = messages[resultIndex];

		PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + (resultIndex - 5));
		PlayerPrefs.Save();
	}
}