using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionOption : MonoBehaviour
{
    [SerializeField] private TMP_Text content;
    public void BindData(string content)
    {
        this.content.text = content;
    }
}
