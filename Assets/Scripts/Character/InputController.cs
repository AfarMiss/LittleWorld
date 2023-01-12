using LittleWorld;
using LittleWorld.Window;
using LittleWorldObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.InputSystem.InputAction;

public class InputController : MonoSingleton<InputController>
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private List<RTSUnit> selectedUnits;
    private List<RTSUnit> allRtsUnits;
    private RectTransform selectedArea;
    private bool isInit = false;

    public bool hasOperation = false;

    [SerializeField] private RectTransform selectedAreaPrefab;

    private Rect realSelection;
    public Vector2 mousePosition { get; private set; }

    public void Init()
    {
        RectTransform rectObject = Instantiate(selectedAreaPrefab);
        rectObject.name = rectObject.name.Substring(0, rectObject.name.LastIndexOf("(Clone)"));
        rectObject.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
        rectObject.gameObject.SetActive(false);

        selectedArea = rectObject.GetComponent<RectTransform>();
        realSelection = new Rect();

        isInit = true;
    }

    private void Start()
    {
        selectedUnits = new List<RTSUnit>();
        allRtsUnits = new List<RTSUnit>();
    }

    public void OnClickDouble(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Debug.Log("双击.performed -------");
            if (selectedUnits != null && selectedUnits.Count > 0)
            {
                TryClearSelectedUnits();
                Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
                FindRectOverlap(screenRect);
            }
        }
    }

    public void OnClickRight(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            CleanInteraction();

            var ray = Camera.main.ScreenPointToRay(mousePosition);
            var rayHits = Physics2D.RaycastAll(ray.origin, ray.direction);

            if (rayHits == null || rayHits.Length == 0)
            {
                if (selectedUnits == null || selectedUnits.Count == 0) return;
                var bound = selectedUnits[0].GetComponent<BoxCollider2D>().bounds;
                var offset = (bound.max - bound.min).y + 0.8f;
                var destinations = InputUtils.GetLinearDestinations(InputUtils.GetMousePositionToWorldWithSpecificZ(selectedUnits[0].transform.position.z), selectedUnits.Count, offset);
                for (int i = 0; i < selectedUnits.Count; i++)
                {
                    var human = SceneItemsManager.Instance.GetWorldObjectById(selectedUnits[0].instanceID);
                    AddMoveWork(human);
                }
            }
            else
            {
                //对单人进行操作
                if (selectedUnits.Count == 1)
                {
                    var human = SceneItemsManager.Instance.GetWorldObjectById(selectedUnits[0].instanceID);
                    FloatOption[] opts = FloatMenuMaker.MakeFloatMenuAt(human as Humanbeing, mousePosition);
                    if (opts.Length == 0)
                    {
                        AddMoveWork(human);
                    }
                }
            }
        }
    }

    private void AddMoveWork(WorldObject human)
    {
        var controller = selectedUnits.Find
            (x => x.GetComponent<PathNavigationOnly>().humanID == human.instanceID);
        var curPos = InputUtils.GetMouseWorldPosition();
        controller.GetComponent<PathNavigationOnly>().AddMovePositionAndMove(curPos, null);
        (human as Humanbeing).AddWork(WorkTypeEnum.gotoLoc, curPos.ToVector3Int());
    }

    private void SelectToMove(RTSUnit item)
    {

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
            //if (UIManager.Instance.IsShowingPanel) return;
            var camMove = callbackContext.ReadValue<Vector2>();
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(camMove);
        }
        else if (callbackContext.canceled)
        {
            //if (UIManager.Instance.IsShowingPanel) return;
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(Vector2.zero);
        }

    }

    public void OnESC()
    {
        allRtsUnits.Clear();
    }

    public void OnClickLeft(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            //if (UIManager.Instance.IsShowingPanel) return;
            startPosition = mousePosition;
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        }
        else if (callbackContext.canceled)
        {
            endPosition = mousePosition;
            selectedArea.gameObject.SetActive(false);

            TryClearSelectedUnits();

            FindBoundOverlap();

            Debug.Log("Click.canceled -------");
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
        var allRtsUnitsObjects = GameObject.FindObjectsOfType<RTSUnit>();
        foreach (var item in allRtsUnitsObjects)
        {
            allRtsUnits.Add(item.GetComponent<RTSUnit>());
        }
        if (!(InputManager.Instance.myController.actions["附加操作"].IsPressed()
            || GameObject.FindObjectsOfType<InteractionOption>().Length != 0))
        {
            ClearSelectedUnits();
        }
    }

    private void ClearSelectedUnits()
    {
        selectedUnits.Clear();

        foreach (var unit in allRtsUnits)
        {
            unit.isSelected = false;
        }

    }

    private void FindBoundOverlap()
    {
        foreach (var item in allRtsUnits)
        {
            if (item.TryGetComponent<RTSUnit>(out var comp))
            {
                var rtsCollider = item.GetComponent<Collider2D>();
                if (realSelection.OverlapBound(rtsCollider.bounds))
                {
                    if (selectedUnits.Contains(comp))
                    {
                        item.isSelected = false;
                        selectedUnits.Remove(comp);
                    }
                    else
                    {
                        item.isSelected = true;
                        selectedUnits.Add(comp);
                    }
                }
            }
        }

        //展示信息
        if (selectedUnits.Count == 1)
        {
            var worldObject = WorldUtility.GetWorldObjectsInRect(realSelection);
            {
                if (worldObject != null && worldObject.Length > 0)
                {
                    worldObject[0].ShowBriefInfo();
                }
                else
                {
                    UIManager.Instance.Hide<BriefInfoPanel>(UIType.PANEL);
                }
            }
        }
    }

    private void FindRectOverlap(Rect other)
    {
        foreach (var item in allRtsUnits)
        {
            if (item.TryGetComponent<RTSUnit>(out var comp))
            {
                var rtsCollider = item.GetComponent<Collider2D>();
                if (other.OverlapBound(rtsCollider.bounds))
                {
                    if (selectedUnits.Contains(comp))
                    {
                        item.isSelected = false;
                        selectedUnits.Remove(comp);
                    }
                    else
                    {
                        item.isSelected = true;
                        selectedUnits.Add(comp);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (!isInit) return;
        mousePosition = InputUtils.GetMousePosition();

        if (InputManager.Instance.myController.actions["左击"].IsPressed())
        {
            Debug.Log($"更新选择区域");
            //更新选择区域
            endPosition = mousePosition;
            var lowerLeft = new Vector2(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y));
            var upperRight = new Vector2(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y));
            selectedArea.position = lowerLeft;
            selectedArea.sizeDelta = upperRight - lowerLeft;

            realSelection.position = lowerLeft;
            realSelection.size = selectedArea.sizeDelta;
        }
    }
}
