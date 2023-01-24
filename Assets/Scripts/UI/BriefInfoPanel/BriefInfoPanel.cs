using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefInfoPanel : BaseUI
{
    public override string Path => UIPath.Panel_BriefInfoPanel;
    [SerializeField] private GameObject briefItemObject;
    [SerializeField] private Text InfoTitle;
    [SerializeField] private Transform briefItemParent;

    private List<BriefInfoItem> briefInfoItems;
    public void BindBriefInfo(string infoTitle, List<BriefInfo> briefItems)
    {
        if (briefInfoItems == null)
        {
            briefInfoItems = new List<BriefInfoItem>();
        }
        if (briefInfoItems.Count != 0)
        {
            foreach (var item in briefInfoItems)
            {
                Destroy(item.gameObject);
            }
            briefInfoItems.Clear();
        }
        this.InfoTitle.text = infoTitle;
        if (briefItems == null)
        {
            return;
        }
        //这里如果briefItems==null会报空
        foreach (var item in briefItems)
        {
            var briefItem = Instantiate(briefItemObject, briefItemParent);
            briefInfoItems.Add(briefItem.GetComponent<BriefInfoItem>());
            briefItem.GetComponent<BriefInfoItem>().bindData(item.title, item.content);
        }
    }
}
