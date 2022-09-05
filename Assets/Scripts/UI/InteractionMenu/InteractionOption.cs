using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionOption : MonoBehaviour
{
    [SerializeField] private TMP_Text content;
    [SerializeField] private Image bg;
    public Color focus;
    public Color unfocus;
    private Action OnClickOption;
    public void BindData(string content,Action OnClickOption)
    {
        this.content.text = content;
        this.name = content;
        this.OnClickOption = OnClickOption;
    }

    public void SetFocus(bool isFocus)
    {
        bg.color = isFocus ? focus : unfocus;
    }

    public void OnClick()
    {
        OnClickOption?.Invoke();
    }
}
