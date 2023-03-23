using LittleWorld.Graphics;
using LittleWorld.Item;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LittleWorld.UI
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField]
        private GameObject sliderPrefab;

        private Dictionary<UIType, List<BaseUI>> uiDic;

        private bool needDrawPlantZoom = false;

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

        public RectTransform SelectionArea => GameObject.FindGameObjectWithTag("SelectionArea")?.GetComponent<RectTransform>();

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
            var go = GameObject.FindGameObjectWithTag("UICanvas");
            if (go != null)
            {
                UICanvas = go;
            }
            else
            {
                UICanvas = GameObject.Instantiate(Resources.Load<GameObject>(UIPath.UICanvas));
            }
            UICanvas.transform.SetParent(null);
            SelectionArea.GetComponent<Image>().enabled = false;
            DontDestroyOnLoad(UICanvas);
        }

        public T ShowPanel<T>(string path = null) where T : BaseUI, new()
        {
            string realPath = path != null ? path : $"Prefabs/UI/Panel/{typeof(T).Name}";
            return Show<T>(UIType.PANEL, realPath);
        }

        public void HideAllInfoPanel()
        {
            UIManager.Instance.Hide<BriefInfoPanel>(UIType.PANEL);
            UIManager.Instance.Hide<BriefInfoAnimalPanel>(UIType.PANEL);

        }

        public T Show<T>(UIType uiType, string path) where T : BaseUI, new()
        {
            GameObject parent = GameObject.FindGameObjectWithTag("UICanvas");
            if (!parent)
            {
                Debug.LogError("Canvas is null!");
                return null;
            }
            foreach (var item in uiDic[uiType])
            {
                if (item.Path == path)
                {
                    item.gameObject.SetActive(true);
                    item.transform.SetAsLastSibling();

                    item.OnEnter();
                    SetManagerProperty(uiType);
                    return item as T;
                }
            }

            GameObject uiObject = GameObject.Instantiate(Resources.Load<GameObject>(path), parent.transform);

            var curUI = uiObject.GetComponent<BaseUI>();
            uiObject.name = curUI.UiName;
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
                        if (item.IsShowing)
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

        public void Hide(Type type, UIType uiType, bool destroyIt = false)
        {
            this.GetType().GetMethod("Hide").MakeGenericMethod(type).Invoke(this, new object[]
            {
            uiType,
            destroyIt,
            });
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

        public void HideAll(UIType uiType, bool destroyIt = false)
        {
            foreach (BaseUI item in uiDic[uiType])
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
            }
        }


        public void HideAll(bool destroyIt = false)
        {
            foreach (var item in uiDic)
            {
                HideAll(item.Key);
            }
        }

        public void Switch<T>(UIType uiType, string path) where T : BaseUI, new()
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
                if (item.Path == path)
                {
                    return item.IsShowing;
                }
            }
            return false;
        }

        public void ShowFloatOptions(List<FloatOption> options, RectTransformAnchor anchor = RectTransformAnchor.TOP_LEFT)
        {
            //clearOthers
            var others = GameObject.FindObjectsOfType<InteractionMenu>();
            foreach (var item in others)
            {
                Destroy(item.gameObject);
            }

            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionMenu/InteractionMenu"));
            go.name = go.name.Substring(0, go.name.LastIndexOf("(Clone)"));
            var menu = go.GetComponent<InteractionMenu>();
            go.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);

            RectTransform rectTransform = go.GetComponent<RectTransform>();

            menu.BindData(options);

            go.GetComponent<CustomContentSizeFitter>().OnRectChange += () =>
            {
                var rectReferencePos = Current.MousePos;
                switch (anchor)
                {
                    case RectTransformAnchor.TOP_LEFT:
                        break;
                    case RectTransformAnchor.BOTTOM_LEFT:
                        rectReferencePos += new Vector2(0, rectTransform.GetComponent<RectTransform>().sizeDelta.y);
                        break;
                    default:
                        break;
                }
                go.transform.position = rectReferencePos;
            };
        }

        private void OnGUI()
        {
            //因为目前底层使用了 UnityEngine.Graphics.DrawTexture
            //所以需要限制在接收到这个事件时触发。
            //否则目前可能会产生多重绘制,具体原因尚不清楚。
            //https://docs.unity3d.com/ScriptReference/Graphics.DrawTexture.html
            if (Event.current.type.Equals(EventType.Repaint))
            {
                #region 绘制选择单位
                if (InputController.Instance.SelectedObjects != null)
                {
                    foreach (var item in InputController.Instance.SelectedObjects)
                    {
                        GraphicsUtiliy.DrawSelectedIcon(item.RenderPos.To2(), 1, 1);
                    }
                }
                #endregion

                #region 绘制路径终点
                foreach (var animal in SceneObjectManager.Instance.FindObjectsOfType<Animal>())
                {
                    if (!animal.PathTracer.atDestination && animal.PathTracer.lastStampFrameCount > 0 && Time.frameCount - animal.PathTracer.lastStampFrameCount <= 50 && animal.PathTracer.PathIsShow)
                    {
                        GraphicsUtiliy.DrawDestinationIcon(animal.PathTracer.curDestination.Value, 1, 1);
                    }
                }
                #endregion

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

    public enum RectTransformAnchor
    {
        TOP_LEFT,
        BOTTOM_LEFT,
    }

}

