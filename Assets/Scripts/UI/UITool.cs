using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UITool
{
    private static GameObject FIndChildGameObject(this GameObject panel, string name)
    {
        Transform[] trans = panel.GetComponentsInChildren<Transform>();
        foreach (var item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.LogWarning($"{panel.name}�Ҳ�����Ϊ{name}���Ӷ���");
        return null;
    }

    public static T GetOrAddCompnentInChildren<T>(this GameObject panel, string name) where T : Component
    {
        GameObject child = FIndChildGameObject(panel, name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.GetComponent<T>();

            return child.GetComponent<T>();
        }
        Debug.LogError($"{panel.name}�Ҳ�����Ϊ{name}�������");
        return null;
    }
}
