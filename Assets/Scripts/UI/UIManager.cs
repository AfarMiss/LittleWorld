using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<UIType, List<BaseUI>> uiDic;
    protected GameObject UICanvas { get; private set; }

    public bool UIIsShowing=> EventSystem.current.IsPointerOverGameObject();

    public UIManager()
    {
        uiDic = new Dictionary<UIType, List<BaseUI>>();

        uiDic.Add(UIType.CANVAS, new List<BaseUI>());
        uiDic.Add(UIType.PANEL, new List<BaseUI>());
        uiDic.Add(UIType.DIALOG, new List<BaseUI>());
        uiDic.Add(UIType.TIP, new List<BaseUI>());
        uiDic.Add(UIType.SCENE_CHANGE, new List<BaseUI>());
    }

    protected override void Awake()
    {
        base.Awake();
        //初始化画布
        UICanvas = GameObject.Instantiate(Resources.Load<GameObject>(UIPath.UICanvas));
        UICanvas.transform.SetParent(null);
        DontDestroyOnLoad(UICanvas);
    }

    public T Show<T>(UIType uiType, string path) where T : BaseUI
    {
        GameObject parent = GameObject.FindGameObjectWithTag("UICanvas");
        if (!parent)
        {
            Debug.LogError("Canvas is null!");
            return null;
        }
        foreach (var item in uiDic[uiType])
        {
            if (item.path == path)
            {
                item.OnEnter();
                return item as T;
            }
        }

        GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(path), parent.transform);
        var curUI = uiObject.GetComponent<BaseUI>();
        uiObject.name = curUI.uiName;
        uiDic[uiType].Add(curUI);
        curUI.OnEnter();
        return curUI as T;
    }

    public void Hide<T>(UIType uiType) where T : BaseUI
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

    public void Switch<T>(UIType uiType, string path) where T : BaseUI
    {
        if (FindPanelIsShowing<T>(uiType, path))
        {
            Hide<T>(uiType);
        }
        else
        {
            Show<T>(uiType, path);
        }
    }

    private bool FindPanelIsShowing<T>(UIType uiType, string path) where T : BaseUI
    {
        foreach (var item in uiDic[uiType])
        {
            if (item.path == path)
            {
                return item.isShowing;
            }
        }
        return false;
    }
}

public enum UIType
{
    //画布
    CANVAS,
    //面板，一种面板只允许出现一个
    PANEL,
    //对话框，允许出现多个
    DIALOG,
    //提示框，显示在对话框左上角
    TIP,
    //转场面板，显示在最前方
    SCENE_CHANGE,
}
