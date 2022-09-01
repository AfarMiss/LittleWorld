using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnit : MonoBehaviour
{
    public GameObject outline;
    private bool _isSelected = false;
    public bool isSelected
    {
        set
        {
            _isSelected = value;
            if (_isSelected)
            {
                OnSelected();
            }
            else
            {
                OnUnselected();
            }
        }
        get
        {
            return _isSelected;
        }
    }

    private void Awake()
    {
        outline.SetActive(false);
    }

    private void OnSelected()
    {
        outline.SetActive(true);
    }

    private void OnUnselected()
    {
        outline.SetActive(false);
    }
}
