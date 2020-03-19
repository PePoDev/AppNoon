/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollView.Example02
{
	public class Sc6Cell : FancyCell<ItemData, Context>
	{
		[SerializeField] private Animator animator = default;
		[SerializeField] private Image image = default;
		[SerializeField] private Button button = default;

		private static class AnimatorHash
		{
			public static readonly int Scroll = Animator.StringToHash("scroll");
		}

		public override void Initialize()
		{
			button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
		}

		public override void UpdateContent(ItemData itemData)
		{
			image.overrideSprite = itemData.sprite;
			var selected = Context.SelectedIndex == Index;
			
			button.onClick.AddListener(() => FindObjectOfType<Sc6Scroller>().OnSelect(Index));
		}

		public override void UpdatePosition(float position)
		{
			currentPosition = position;

			if (animator.isActiveAndEnabled)
			{
				animator.Play(AnimatorHash.Scroll, -1, position);
			}
			
			animator.speed = 0;
		}

		private float currentPosition = 0;

		private void OnEnable() => UpdatePosition(currentPosition);
	}
}