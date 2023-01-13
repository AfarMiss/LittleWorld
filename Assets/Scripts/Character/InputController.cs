using LittleWorld;
using LittleWorld.Window;
using LittleWorldObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Analytics;
using static UnityEditor.Progress;
using static UnityEngine.InputSystem.InputAction;

public class InputController : MonoSingleton<InputController>
{
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField]
    private RectTransform selectedAreaPrefab;

    private List<WorldObject> SelectedObjects => WorldUtility.GetWorldObjectsInRect(realSelection).ToList();
    public bool AdditionalAction => additionalAction;
    public Rect ScreenSelectionArea => realSelection;
    /// <summary>
    /// 是否为附加模式
    /// </summary>
    private bool additionalAction;

    private RectTransform selectedArea;

    private Rect realSelection;

    private bool isInit = false;

    public bool MultiPawnSelected =>
             SelectedObjects != null
        && SelectedObjects.Count > 1
        && SelectedObjects.Find(x => x as Humanbeing == null) == null;
    public bool SinglePawnSelected =>
            SelectedObjects.Count == 1
    && SelectedObjects.Find(x => x as Humanbeing == null) == null;
    public bool NoSelected => SelectedObjects.Count == 0;
    private bool NonHumanSelected =>
        SelectedObjects.Count == 0
        || SelectedObjects.Find(x => x as Humanbeing == null) != null;
    private bool MultiTypeSelected
    {
        get
        {
            if (SelectedObjects == null || SelectedObjects.Count == 0)
            {
                return false;
            }

            var typeHashSet = new HashSet<Type>();
            foreach (var item in SelectedObjects)
            {
                if (typeHashSet.Contains(item.GetType()))
                {
                    continue;
                }
                else
                {
                    if (typeHashSet.Count == 0)
                    {
                        typeHashSet.Add(item.GetType());
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return typeHashSet.Count > 1;
        }
    }


    public void Init()
    {
        RectTransform rectObject = Instantiate(selectedAreaPrefab);
        rectObject.name = rectObject.name.Substring(0, rectObject.name.LastIndexOf("(Clone)"));
        rectObject.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
        rectObject.gameObject.SetActive(false);

        selectedArea = rectObject.GetComponent<RectTransform>();
        realSelection = new Rect();

        isInit = true;
        additionalAction = false;
    }

    public void OnClickDouble(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (SelectedObjects != null && SelectedObjects.Count > 0)
            {
                TryClearSelectedUnits();
            }
        }
    }

    public void OnClickRight(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CleanInteraction();

            //根据框选状态确定执行操作
            if (NoSelected || NonHumanSelected || MultiTypeSelected)
            {
                return;
            }
            //根据选中单位的信息做出对应操作
            if (MultiPawnSelected)
            {
                //对多人进行操作
                for (int i = 0; i < SelectedObjects.Count; i++)
                {
                    var curPos = InputUtils.GetMouseWorldPosition();
                    var human = SceneItemsManager.Instance.GetWorldObjectById(SelectedObjects[0].instanceID);
                    AddMoveWork(human, curPos);
                }
            }

            if (SinglePawnSelected)
            {
                //对单人进行操作
                if (SelectedObjects.Count == 1)
                {
                    var human = SceneItemsManager.Instance.GetWorldObjectById(SelectedObjects[0].instanceID);
                    FloatOption[] opts = FloatMenuMaker.MakeFloatMenuAt(human as Humanbeing, Current.MousePos);
                    if (opts.Length == 0)
                    {
                        var curPos = InputUtils.GetMouseWorldPosition();
                        AddMoveWork(human, curPos);
                    }
                }
            }
        }
    }

    private void AddMoveWork(WorldObject human, Vector3 targetPos)
    {
        (human as Humanbeing).AddWork(WorkTypeEnum.gotoLoc, targetPos.ToVector3Int());
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
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(camMove);
        }
        else if (callbackContext.canceled)
        {
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(Vector2.zero);
        }

    }

    public void OnClickLeft(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            startPosition = Current.MousePos;
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        }
        else if (callbackContext.canceled)
        {
            endPosition = Current.MousePos;
            selectedArea.gameObject.SetActive(false);

            TryClearSelectedUnits();

            SelectWorldObjects();

            Debug.Log("Click.canceled -------");
        }
    }

    private void OnClickShift(CallbackContext callbackContext)
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
        SelectedObjects.Clear();
    }

    private void SelectWorldObjects()
    {
        //展示信息
        var worldObject = WorldUtility.GetWorldObjectsInRect(realSelection);
        {
            if (worldObject == null || worldObject.Length == 0)
            {
                UIManager.Instance.Hide<BriefInfoPanel>(UIType.PANEL);
            }
            if (worldObject.Length == 1)
            {
                worldObject[0].ShowBriefInfo();
            }
            if (worldObject.Length > 1)
            {
                WorldObject.ShowMultiInfo(worldObject.Length);
            }
        }
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
        endPosition = Current.MousePos;
        var lowerLeft = new Vector2(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y));
        var upperRight = new Vector2(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y));
        selectedArea.position = lowerLeft;
        selectedArea.sizeDelta = upperRight - lowerLeft;

        realSelection.position = lowerLeft;
        realSelection.size = selectedArea.sizeDelta;
    }
}
