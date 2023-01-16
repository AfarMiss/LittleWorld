using LittleWorld;
using LittleWorld.Window;
using LittleWorld.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.Rendering.Universal;
using static UnityEditor.Progress;
using static UnityEngine.InputSystem.InputAction;

public class InputController : MonoSingleton<InputController>
{
    private Vector3 onClickLeftStartPosition;
    private Vector3 onClickLeftEndPosition;

    [SerializeField]
    private RectTransform selectedAreaPrefab;

    public List<WorldObject> SelectedObjects => selectedObjects;
    private List<WorldObject> selectedObjects;
    public bool AdditionalAction => additionalAction;
    public Rect ScreenSelectionArea => realSelection;
    /// <summary>
    /// 是否为附加模式
    /// </summary>
    private bool additionalAction;

    private RectTransform selectedArea;
    private CameraController CamController => Camera.main.GetComponent<CameraController>();

    private Rect realSelection;

    private bool isInit = false;
    private bool cameraDraging = false;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void Init()
    {
        selectedObjects = new List<WorldObject>();
        RectTransform rectObject = Instantiate(selectedAreaPrefab);
        rectObject.name = rectObject.name.Substring(0, rectObject.name.LastIndexOf("(Clone)"));
        rectObject.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
        rectObject.gameObject.SetActive(false);

        selectedArea = rectObject.GetComponent<RectTransform>();
        realSelection = new Rect();

        isInit = true;
        additionalAction = false;
        cameraDraging = false;
    }

    public void OnClickDouble(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (selectedObjects != null && selectedObjects.Count > 0)
            {
                TryClearSelectedUnits();
            }
        }
    }

    /// <summary>
    /// 放大/缩小区域
    /// </summary>
    /// <param name="callbackContext"></param>
    public void OnMouseScroll(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            var scrollValue = callbackContext.ReadValue<Vector2>();
            Debug.Log(callbackContext.ReadValue<Vector2>());
            if (scrollValue.y > 0)
            {
                FindObjectOfType<PixelPerfectCamera>().assetsPPU++;
            }
            else if (scrollValue.y < 0)
            {
                FindObjectOfType<PixelPerfectCamera>().assetsPPU--;
            }
            //FindObjectOfType<PixelPerfectCamera>().assetsPPU--;
        }
    }


    public void OnClickRight(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CleanInteraction();

            //根据框选状态确定执行操作
            if (selectedObjects.NoSelected() || selectedObjects.NonHumanSelected()
                || selectedObjects.MultiTypeSelected())
            {
                return;
            }
            //根据选中单位的信息做出对应操作
            if (selectedObjects.MultiPawnSelected())
            {
                //对多人进行操作
                for (int i = 0; i < selectedObjects.Count; i++)
                {
                    var curPos = InputUtils.GetMouseWorldPosition();
                    var human = SceneItemsManager.Instance.GetWorldObjectById(selectedObjects[0].instanceID);
                    AddMoveWork(human, curPos);
                }
            }

            if (selectedObjects.SinglePawnSelected())
            {
                //对单人进行操作
                var human = SceneItemsManager.Instance.GetWorldObjectById(selectedObjects[0].instanceID);
                FloatOption[] opts = FloatMenuMaker.MakeFloatMenuAt(human as Humanbeing, Current.MousePos);
                if (opts.Length == 0)
                {
                    var curPos = InputUtils.GetMouseWorldPosition();
                    AddMoveWork(human, curPos);
                }
            }
        }
    }

    private void AddMoveWork(WorldObject human, Vector3 targetPos)
    {
        (human as Humanbeing).AddWork(WorkTypeEnum.gotoLoc, targetPos.ToCell());
    }

    public void OnClickSetting(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            UIManager.Instance.Switch<PausePanel>(UIType.PANEL, UIPath.Panel_PausePanel);
        }
    }

    public void OnCameraControl(CallbackContext callbackContext)
    {

        if (callbackContext.performed)
        {
            var camMove = callbackContext.ReadValue<Vector2>();
            CamController.Move(camMove);
        }
        else if (callbackContext.canceled)
        {
            CamController.Move(Vector2.zero);
        }
    }

    public void OnClickCameraDrag(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            cameraDraging = true;
        }
        else if (callbackContext.canceled)
        {
            cameraDraging = false;
        }
    }

    public void OnMouseCameraControl(CallbackContext callbackContext)
    {
        if (!cameraDraging)
        {
            return;
        }
        if (callbackContext.performed)
        {
            CamController.MoveDelta(-callbackContext.ReadValue<Vector2>());
        }
    }

    public void OnClickLeft(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            onClickLeftStartPosition = Current.MousePos;
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        }
        else if (callbackContext.canceled)
        {
            onClickLeftEndPosition = Current.MousePos;
            selectedArea.gameObject.SetActive(false);

            var floatMenu = FindObjectOfType<InteractionMenu>();
            //点击点不包含交互菜单则重新选择框选单位
            if (floatMenu == null || !(floatMenu.transform as RectTransform).RectangleContainsScreenPoint(Current.MousePos))
            {
                CleanInteraction();
                TryClearSelectedUnits();
                selectedObjects = SelectWorldObjects(SelectType.REGION_TOP);
            }

            Debug.Log("Click.canceled -------");
        }
    }

    public void OnClickShift(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            additionalAction = true;
        }
        else if (callbackContext.canceled)
        {
            additionalAction = false;
        }
    }


    public void CleanInteraction()
    {
        var interactions = GameObject.FindObjectsOfType<InteractionMenu>();
        foreach (var item in interactions)
        {
            Destroy(item.gameObject);
        }
        UIManager.Instance.ReactMenu = false;
    }

    private void TryClearSelectedUnits()
    {
        if (!additionalAction || GameObject.FindObjectsOfType<InteractionOption>().Length != 0)
        {
            ClearSelectedUnits();
        }
    }

    private void ClearSelectedUnits()
    {
        selectedObjects?.Clear();
    }

    private List<WorldObject> SelectWorldObjects(SelectType selectType)
    {
        var worldObjectArray = WorldUtility.GetWorldObjectsInRect(realSelection);
        if (worldObjectArray == null)
        {
            return null;
        }
        var worldObject = worldObjectArray.ToList().GetSelected(selectType);

        if (worldObject == null || worldObject.Count == 0)
        {
            UIManager.Instance.Hide<BriefInfoPanel>(UIType.PANEL);
            return null;
        }
        if (worldObject.Count == 1)
        {
            worldObject[0].ShowBriefInfo();
        }
        if (worldObject.Count > 1)
        {
            WorldObject.ShowMultiInfo(worldObject.Count);
        }
        return worldObject.ToList();
    }

    private void Update()
    {
        if (!isInit) return;

        if (InputManager.Instance.myController.actions["左击"].IsPressed())
        {
            UpdateSelectArea();
        }
    }

    private void UpdateSelectArea()
    {
        onClickLeftEndPosition = Current.MousePos;
        var lowerLeft = new Vector2(Mathf.Min(onClickLeftStartPosition.x, onClickLeftEndPosition.x), Mathf.Min(onClickLeftStartPosition.y, onClickLeftEndPosition.y));
        var upperRight = new Vector2(Mathf.Max(onClickLeftStartPosition.x, onClickLeftEndPosition.x), Mathf.Max(onClickLeftStartPosition.y, onClickLeftEndPosition.y));
        selectedArea.position = lowerLeft;
        selectedArea.sizeDelta = upperRight - lowerLeft;

        realSelection.position = lowerLeft;
        realSelection.size = selectedArea.sizeDelta;
    }
}
