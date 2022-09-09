using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionOption : MonoBehaviour
{
    [SerializeField] private Text content;
    [SerializeField] private Image bg;
    public Color focus;
    public Color unfocus;
    private Action OnClickOption;
    public void BindData(optionStruct option)
    {
        this.content.text = option.content;
        this.name = option.content;
        this.OnClickOption = option.OnClickOption;
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

public struct optionStruct
{
    public string content;
    public Action OnClickOption;
}
