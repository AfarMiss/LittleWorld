using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnit : MonoBehaviour
{
    public GameObject outline;
    public bool isSelected = false;

    private void Awake()
    {
        outline.SetActive(false);
    }

    public void OnSelected()
    {
        outline.SetActive(true);
    }

    public void OnUnselected()
    {
        outline.SetActive(false);
    }
}
