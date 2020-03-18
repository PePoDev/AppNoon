/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace FancyScrollView.Example02
{
	public class Example02 : MonoBehaviour
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

		private void OnSelectionChanged(int index)
		{
			if (items[index].usable == false)
			{
				select.interactable = false;
			}
		}
	}
}