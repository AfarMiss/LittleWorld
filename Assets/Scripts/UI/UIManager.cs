using System.Collections.Generic;
using UnityEngine;

public class UIManager:MonoSingleton<UIManager>
{
    private Dictionary<UIType, List<BaseUI>> uiDic;
    protected GameObject Canvas { get; private set; }

    public UIManager()
    {
        uiDic = new Dictionary<UIType, List<BaseUI>>();

        uiDic.Add(UIType.PANEL, new List<BaseUI>());
        uiDic.Add(UIType.DIALOG, new List<BaseUI>());
        uiDic.Add(UIType.TIP, new List<BaseUI>());
        uiDic.Add(UIType.SCENE_CHANGE, new List<BaseUI>());

        Canvas = GameObject.Instantiate(Resources.Load<GameObject>(UIPath.Canvas), transform);
    }

    public T Show<T>(UIType uiType, string path)where T:BaseUI
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("Canvas is null!");
            return null;
        }
        foreach (var item in uiDic[uiType])
        {
            if( item.path == path)
            {
                return item as T;
            }
        }

        GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(path), parent.transform);
        var curUI = uiObject.GetComponent<BaseUI>();
        uiObject.name = curUI.uiName;
        uiDic[uiType].Add(curUI);
        return curUI as T;
    }

    public void Hide<T>(UIType uiType)
    {
        for (int i = 0; i < uiDic[uiType].Count; i++)
        {
            BaseUI item = uiDic[uiType][i];
            if (item.GetType() == typeof(T))
            {
                uiDic[uiType].Remove(item);
                item.OnExit();
                Destroy(item.gameObject);
                return;
            }
        }
    }
}

public enum UIType
{
    //��壬һ�����ֻ�������һ��
    PANEL,
    //�Ի���������ֶ��
    DIALOG,
    //��ʾ����ʾ�ڶԻ������Ͻ�
    TIP,
    //ת����壬��ʾ����ǰ��
    SCENE_CHANGE,
}
