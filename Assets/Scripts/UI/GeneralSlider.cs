using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralSlider : MonoBehaviour
{
    public float progress
    {
        get
        {
            return GetComponent<Slider>().value;
        }
        set
        {
            GetComponent<Slider>().value = value;
        }
    }
}
