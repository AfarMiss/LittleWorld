using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryTextBox : MonoBehaviour
{
    [SerializeField] private Text textTop1 = null;
    [SerializeField] private Text textTop2 = null;
    [SerializeField] private Text textTop3 = null;
    [SerializeField] private Text textBotttom1 = null;
    [SerializeField] private Text textBotttom2 = null;
    [SerializeField] private Text textBotttom3 = null;

    public void SetTextboxText(string textTop1, string textTop2, string textTop3, string textBottom1, string textBottom2, string textBottom3)
    {
        this.textTop1.text = textTop1;
        this.textTop2.text = textTop2;
        this.textTop3.text = textTop3;
        this.textBotttom1.text = textBottom1;
        this.textBotttom2.text = textBottom2;
        this.textBotttom3.text = textBottom3;
    }
}
