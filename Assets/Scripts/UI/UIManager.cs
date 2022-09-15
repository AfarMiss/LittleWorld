using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<UIType, List<BaseUI>> uiDic;
    protected GameObject UICanvas { get; private set; }

    private bool isShowingPanel;
    /// <summary>
    /// ������ʾpanel������Ӧ��Ϸ�е��¼���
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
            SwitchMapState();
        }
    }

    private void SwitchMapState()
    {
        if (!InputManager.Instance) return;
    }

    public UIManager()
    {
        uiDic = new Dictionary<UIType, List<BaseUI>>();

        uiDic.Add(UIType.CANVAS, new List<BaseUI>());
        uiDic.Add(UIType.PANEL, new List<BaseUI>());
        uiDic.Add(UIType.DIALOG, new List<BaseUI>());
        uiDic.Add(UIType.TIP, new List<BaseUI>());
        uiDic.Add(UIType.SCENE_CHANGE, new List<BaseUI>());

        SwitchMapState();
    }

    protected override void Awake()
    {
        base.Awake();
        //��ʼ������
        UICanvas = GameObject.Instantiate(Resources.Load<GameObject>(UIPath.UICanvas));
        UICanvas.transform.SetParent(null);
        DontDestroyOnLoad(UICanvas);

        if (GameController.Instance) GameController.Instance.Init();
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
}

public enum UIType
{
    //����
    CANVAS,
    //��壬һ�����ֻ�������һ��
    PANEL,
    //�Ի���������ֶ��
    DIALOG,
    //��ʾ����ʾ�ڶԻ������Ͻ�
    TIP,
    //ת����壬��ʾ����ǰ��
    SCENE_CHANGE,
}
