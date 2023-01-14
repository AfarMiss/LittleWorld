using LittleWorld.Graphics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private GameObject sliderPrefab;

    private Dictionary<UIType, List<BaseUI>> uiDic;
    protected GameObject UICanvas { get; private set; }

    private bool isShowingPanel;
    /// <summary>
    /// 正在显示panel，不响应游戏中的事件。
    /// </summary>
    public bool IsShowingPanel
    {
        get
        {
            return isShowingPanel;
        }
        private set
        {
            isShowingPanel = value;
        }
    }

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

        UIManager.Instance.Show<MainInfoPanel>(UIType.PANEL, UIPath.Main_UI_Panel);
        UIManager.Instance.Show<ProgressPanel>(UIType.PANEL, UIPath.Panel_ProgressPanel);
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
                item.gameObject.SetActive(true);

                item.OnEnter();
                SetManagerProperty(uiType);
                return item as T;
            }
        }

        GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(path), parent.transform);

        var curUI = uiObject.GetComponent<BaseUI>();
        uiObject.name = curUI.uiName;
        uiDic[uiType].Add(curUI);

        curUI.OnEnter();
        SetManagerProperty(uiType);
        return curUI as T;
    }

    private void SetManagerProperty(UIType uiType)
    {
        switch (uiType)
        {
            case UIType.CANVAS:
                break;
            case UIType.PANEL:
                var showingPanelCount = 0;
                foreach (var item in uiDic[uiType])
                {
                    if (item.isShowing)
                    {
                        showingPanelCount++;
                    }
                }
                IsShowingPanel = showingPanelCount > 0;
                break;
            case UIType.DIALOG:
                break;
            case UIType.TIP:
                break;
            case UIType.SCENE_CHANGE:
                break;
            default:
                break;
        }
    }

    public void Hide<T>(UIType uiType, bool destroyIt = false) where T : BaseUI
    {
        for (int i = 0; i < uiDic[uiType].Count; i++)
        {
            BaseUI item = uiDic[uiType][i];
            if (item.GetType() == typeof(T))
            {
                item.OnExit();
                if (destroyIt)
                {
                    uiDic[uiType].Remove(item);
                    Destroy(item.gameObject);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
                SetManagerProperty(uiType);
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

    private void OnGUI()
    {
        if (InputController.Instance.SelectedObjects == null) return;
        foreach (var item in InputController.Instance.SelectedObjects)
        {
            GraphicsUtiliy.DrawSelectedIcon(item.GridPos.ToWorldVector2(), 1, 1);
        }
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
