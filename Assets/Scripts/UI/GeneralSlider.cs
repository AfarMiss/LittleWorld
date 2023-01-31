using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.UI;

public class GeneralSlider : MonoBehaviour
{
    public int uniqueID;
    public Vector3 sliderFollowPos;
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

    private void Update()
    {
        transform.position = InputUtils.GetScreenPosition(sliderFollowPos);
    }
}
