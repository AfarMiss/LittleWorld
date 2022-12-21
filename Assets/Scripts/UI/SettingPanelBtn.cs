using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelBtn : MonoBehaviour
{
    [SerializeField] private GameObject activeNode;
    [SerializeField] private GameObject inactiveNode;
    [SerializeField] private Button pageBtn;
    [SerializeField] private GameObject page;

    public Button PageBtn => pageBtn;

    public void SwitchToActive()
    {
        activeNode.SetActive(true);
        inactiveNode.SetActive(true);
        page.SetActive(true);
    }

    public void SwitchToInactive()
    {
        activeNode.SetActive(false);
        inactiveNode.SetActive(true);
        page.SetActive(false);
    }
}
