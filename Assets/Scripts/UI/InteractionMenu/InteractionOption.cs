using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionOption : MonoBehaviour
{
    [SerializeField] private Text content;
    [SerializeField] private Image bg;
    [SerializeField] private Button btn;
    public Color focus;
    public Color unfocus;
    private UnityAction OnClickOption;
    public void BindData(FloatOption option)
    {
        this.content.text = option.content;
        this.name = option.content;
        this.OnClickOption = option.OnClickOption;
        this.btn.onClick.AddListener(() =>
        {
            OnClickOption?.Invoke();
            InputController.Instance.CleanInteraction();
        });
    }

    public void SetFocus(bool isFocus)
    {
        bg.color = isFocus ? focus : unfocus;
    }
}

public class FloatOption
{
    public string content;
    public UnityAction OnClickOption;

    public FloatOption(string content, UnityAction onClickOption)
    {
        this.content = content;
        OnClickOption = onClickOption;
    }
}
