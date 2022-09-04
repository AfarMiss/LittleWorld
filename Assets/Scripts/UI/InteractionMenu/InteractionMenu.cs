using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionPrefab;
    public void BindData(List<string> options)
    {
        foreach (var optionContent in options)
        {
            var optionObject= Instantiate(optionPrefab, this.transform);
            var option = optionObject.GetComponent<InteractionOption>();
            option.BindData(optionContent);
        }
    }
}
