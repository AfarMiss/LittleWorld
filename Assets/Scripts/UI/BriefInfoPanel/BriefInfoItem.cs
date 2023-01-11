using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefInfoItem : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text content;

    public void bindData(string title, string content)
    {
        this.title.text = title;
        this.content.text = content;
    }
}
