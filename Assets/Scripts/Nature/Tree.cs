using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class Tree : MonoBehaviour,IOption
{
    public void OnInteraction()
    {
        var go = Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionMenu/InteractionMenu"));
        go.name = go.name.Substring(0, go.name.LastIndexOf("(Clone)"));
        var menu = go.GetComponent<InteractionMenu>();
        go.transform.SetParent(GameObject.Find("Canvas").transform);
        go.transform.position = InputUtils.GetMousePosition();

        var contentList = new List<string>();
        contentList.Add("¿³Ê÷");
        contentList.Add("ÕªÈ¡¹ûÊµ");

        menu.BindData(contentList);
    }
}
