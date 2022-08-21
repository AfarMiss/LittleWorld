using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool 
{
    GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }

    public T GetOrAddCompnent<T> () where T : Component
    {
        if (activePanel.GetComponent<T>() == null)
            activePanel.AddComponent<T>();

        return activePanel.GetComponent<T>();
    }

    public GameObject FIndChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();
        foreach (var item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.LogWarning($"{activePanel.name}找不到名为{name}的子对象");
        return null;
    }

    public T GetOrAddCompnentInChildren<T>(string name) where T : Component
    {
        GameObject child = FIndChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.GetComponent<T>();

            return child.GetComponent<T>();
        }
        Debug.LogError($"{activePanel.name}找不到名为{name}的子组件");
        return null;
    }
}
