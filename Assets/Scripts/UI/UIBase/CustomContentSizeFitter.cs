using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class CustomContentSizeFitter : ContentSizeFitter
    {
        public Action OnRectChange = null;
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            OnRectChange?.Invoke();
        }
    }
}
