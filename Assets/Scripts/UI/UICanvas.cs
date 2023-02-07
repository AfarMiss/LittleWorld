using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoSingleton<UICanvas>
{
    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public Vector2 Size => rectTransform.rect.size;
}
