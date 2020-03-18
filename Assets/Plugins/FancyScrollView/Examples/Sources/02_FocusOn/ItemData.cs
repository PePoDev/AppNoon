/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FancyScrollView.Example02
{
	[Serializable]
    public class ItemData
    {
        [FormerlySerializedAs("Sprite")] public Sprite sprite;
        public bool usable;
    }
}
