using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionOption : MonoBehaviour, IPointerClickHandler
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
        this.btn.onClick.AddListener(OnClickOption);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
        InputController.Instance.CleanInteraction();
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
