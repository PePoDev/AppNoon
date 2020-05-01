using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using FancyScrollView.Example02;
using TMPro;
using UnityEngine.Events;

public class Sc4 : MonoBehaviour
{
	[SerializeField] private ScrollView scrollView = default;
	[SerializeField] private GameObject content = default;
	[SerializeField] private Button prevCellButton = default;
	[SerializeField] private Button nextCellButton = default;

	public ItemData[] items;

	public TMP_InputField username;
	public TMP_InputField email;
	public TMP_InputField password;

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

	public UnityEvent OnReis;

	public void Regis()
	{
		var db = Database.Get();
		db.user.pictureId = m_index;
		db.user.username = username.text;
		db.user.email = email.text;
		db.user.password = password.text;

		if (password.text.Length != 4)
		{
			return;
		}

		Database.Set(db);
		OnReis.Invoke();
	}
}