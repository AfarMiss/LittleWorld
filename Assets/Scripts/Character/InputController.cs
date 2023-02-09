using LittleWorld;
using LittleWorld.UI;
using LittleWorld.Item;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using static UnityEngine.InputSystem.InputAction;
using LittleWorld.MapUtility;
using LittleWorld.Graphics;
using UnityEngine.UI;
using System;

public class InputController : MonoSingleton<InputController>
{
    public delegate void OnPlantZoneChanged(MapGridDetails[] details);
    private Vector3 onClickLeftStartPosition;
    private Vector3 onClickLeftEndPosition;
    private OnPlantZoneChanged onPlantZoneChanged;
    private bool needRespondToUI;
    private GameObject ghostBuilding;
    [SerializeField]
    private GameObject pfGhostBuilding;
    Camera mainCamera;
    public int CurSelectedBuildingCode;


    public void AddEventOnZoomChanged(OnPlantZoneChanged onChanged)
    {
        this.onPlantZoneChanged += onChanged;
    }

    private Vector3 onClickLeftStartPositionWorldPosition;
    private Vector3 onClickLeftEndPositionWorldPosition;

    [SerializeField]
    private RectTransform selectedAreaPrefab;

    public List<WorldObject> SelectedObjects => selectedObjects;
    private List<WorldObject> selectedObjects;
    public bool AdditionalAction => additionalAction;
    public Rect ScreenSelectionArea => screenRealSelection;
    /// <summary>
    /// 是否为附加模式
    /// </summary>
    private bool additionalAction;
    //Current.CurMap.ExpandZone(gridIndexs, section);
    public MouseState MouseState
    {
        set
        {
            mouseState = value;
        }
        get
        {
            return mouseState;
        }
    }
    private MouseState mouseState = MouseState.Normal;

    private RectTransform selectedArea => UIManager.Instance.SelectionArea;
    private CameraController CamController => mainCamera.GetComponent<CameraController>();

    private Rect screenRealSelection;

    private bool isInit = false;
    private bool cameraDraging = false;

    Rect WorldRect => InputUtils.GetWorldRect(onClickLeftStartPositionWorldPosition, onClickLeftEndPositionWorldPosition);


    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    public void Init()
    {
        selectedObjects = new List<WorldObject>();
        screenRealSelection = new Rect();

        isInit = true;
        additionalAction = false;
        cameraDraging = false;
        ghostBuilding = Instantiate(pfGhostBuilding, null);
        ghostBuilding.GetComponent<GhostRender>().DisableRender();

        mainCamera = Camera.main;
    }

    public void OnClickDouble(CallbackContext callbackContext)
    {
        //if (callbackContext.performed)
        //{
        //    if (selectedObjects != null && selectedObjects.Count > 0)
        //    {
        //        TryClearSelectedUnits();
        //    }
        //}
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
            //Debug.Log(callbackContext.ReadValue<Vector2>());
            if (scrollValue.y > 0)
            {
                FindObjectOfType<PixelPerfectCamera>().assetsPPU++;
            }
            else if (scrollValue.y < 0)
            {
                FindObjectOfType<PixelPerfectCamera>().assetsPPU--;
            }
        }
    }


    public void OnClickRight(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            SetMouseStateToDefault();
            CleanInteraction();

            //根据框选状态确定执行操作
            if (selectedObjects.NoSelected() || selectedObjects.NonHumanSelected()
                || selectedObjects.MultiTypeSelected())
            {
                return;
            }
            var curPos = InputUtils.GetMouseWorldPosition().ClampInMap(MapManager.Instance.curDisplayMap);
            //根据选中单位的信息做出对应操作
            if (selectedObjects.MultiPawnSelected())
            {
                //对多人进行操作
                for (int i = 0; i < selectedObjects.Count; i++)
                {
                    var human = SceneObjectManager.Instance.GetWorldObjectById(selectedObjects[0].instanceID);
                    AddMoveWork(human, curPos);
                }
            }

            if (selectedObjects.SinglePawnSelected())
            {
                //对单人进行操作
                var human = SceneObjectManager.Instance.GetWorldObjectById(selectedObjects[0].instanceID);
                FloatOption[] opts = FloatMenuMaker.MakeFloatMenuAt(human as Humanbeing, Current.MousePos);
                if (opts.Length == 0)
                {
                    AddMoveWork(human, curPos);
                }
            }
        }
        if (callbackContext.canceled)
        {
            ghostBuilding.GetComponent<GhostRender>().DisableRender();
        }
    }

    private void SetMouseStateToDefault()
    {
        Debug.Log("RemoveZoneState");
        this.MouseState = MouseState.Normal;
    }

    private void AddMoveWork(WorldObject human, Vector3 targetPos)
    {
        (human as Humanbeing).AddMoveWork(targetPos.ToCell());
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
        OnPlayingGameProgress(callbackContext);
    }

    private void OnPlayingGameProgress(CallbackContext callbackContext)
    {
        if (Root.Instance.GameState != GameState.PLAYING)
        {
            return;
        }
        //先响应UI，再响应游戏场景
        if (needRespondToUI && MouseState != MouseState.Normal)
        {
            return;
        }

        if (callbackContext.started)
        {
            onClickLeftStartPosition = Current.MousePos;
            onClickLeftStartPositionWorldPosition = mainCamera.ScreenToWorldPoint(onClickLeftStartPosition);
            Debug.Log("Click.started -------");
        }
        else if (callbackContext.canceled)
        {
            onClickLeftEndPosition = Current.MousePos;
            onClickLeftEndPositionWorldPosition = mainCamera.ScreenToWorldPoint(onClickLeftEndPosition);
            Debug.Log("Click.canceled -------");
        }

        var grids = GetWorldGrids(MapManager.Instance.ColonyMap,
      InputUtils.GetWorldRect(onClickLeftStartPositionWorldPosition, onClickLeftEndPositionWorldPosition));
        switch (mouseState)
        {
            case MouseState.Normal:
                Select(callbackContext);
                break;
            case MouseState.AddSection:
                AddSection(callbackContext, SectionType.PLANT);
                break;
            case MouseState.ShrinkStorageZone:
            case MouseState.ShrinkZone:
                ShrinkZone(callbackContext, grids);
                break;
            case MouseState.ExpandZone:
            case MouseState.ExpandStorageZone:
                ExpandZone(callbackContext, grids);
                break;
            case MouseState.AddStorageSection:
                AddSection(callbackContext, SectionType.STORE);
                break;

            case MouseState.BuildingGhost:
                AddBuilding(callbackContext);
                break;
            default:
                break;
        }
    }

    private void ExpandZone(CallbackContext callbackContext, MapGridDetails[] grids)
    {
        if (callbackContext.canceled)
        {
            Current.CurMap.ExpandZone(grids);
        }
    }

    private void ShrinkZone(CallbackContext callbackContext, MapGridDetails[] grids)
    {
        if (callbackContext.canceled)
        {
            Current.CurMap.ShrinkZone(grids);
        }
    }

    private void Select(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            selectedArea.GetComponent<Image>().enabled = true;
        }
        else if (callbackContext.canceled)
        {
            selectedArea.GetComponent<Image>().enabled = false;

            var floatMenu = FindObjectOfType<InteractionMenu>();
            //点击点不包含交互菜单则重新选择框选单位
            if (floatMenu == null || !(floatMenu.transform as RectTransform).RectangleContainsScreenPoint(Current.MousePos))
            {
                CleanInteraction();
                Reselect();
            }

            Debug.Log("Click.canceled -------");
        }
    }

    private void Reselect()
    {
        if (needRespondToUI) { return; }
        TryClearSelectedUnits();
        selectedObjects = SelectWorldObjects(SelectType.REGION_TOP);
        if (selectedObjects == null)
        {
            SelectSectionObjects();
        }
    }

    private void AddSection(CallbackContext callbackContext, SectionType type)
    {
        if (callbackContext.canceled)
        {
            var grids = GetWorldGrids(MapManager.Instance.ColonyMap,
                InputUtils.GetWorldRect(onClickLeftStartPositionWorldPosition, onClickLeftEndPositionWorldPosition));
            Current.CurMap.AddSection(grids, type);
        }
    }

    private void AddBuilding(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            EnableRenderGhostBuilding();
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

    public MapSection SelectSectionObjects()
    {
        var section = WorldUtility.GetSectionsInRect(WorldRect);
        Current.CurMap.ChangeCurrentSection(section);
        if (section != null)
        {
            WorldObject.ShowInfo(section);
        }
        return section;

    }

    private List<WorldObject> SelectWorldObjects(SelectType selectType)
    {
        var worldObjectArray = WorldUtility.GetWorldObjectsInRect(WorldRect);
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
        WorldObject.ShowInfo(worldObject.ToArray());
        return worldObject.ToList();
    }

    private void Update()
    {
        if (!isInit) return;
        needRespondToUI =
            //IsPointerOverGameObject在非update方法中调用会警告
            UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        if (InputManager.Instance.myController.actions["左击"].IsPressed())
        {
            UpdateSelectArea();
        }
        OnFloat();
    }

    private void OnFloat()
    {
        switch (mouseState)
        {
            case MouseState.Normal:
            case MouseState.ExpandZone:
            case MouseState.ShrinkZone:
            case MouseState.AddSection:
            case MouseState.DeleteSection:
            case MouseState.ExpandStorageZone:
            case MouseState.ShrinkStorageZone:
            case MouseState.AddStorageSection:
            case MouseState.DeleteStorageSection:
                break;
            case MouseState.BuildingGhost:
                UpdateGhostPos(mainCamera.ScreenToWorldPoint(Current.MousePos));
                break;
            default:
                break;
        }
    }

    private void UpdateSelectArea()
    {
        onClickLeftEndPosition = Current.MousePos;
        onClickLeftEndPositionWorldPosition = mainCamera.ScreenToWorldPoint(onClickLeftEndPosition);
        //Debug.Log("Mouse Pos:" + Current.MousePos);
        Debug.Log("mouseState:" + mouseState.ToString());
        var lowerLeft = new Vector2(Mathf.Min(onClickLeftStartPosition.x, onClickLeftEndPosition.x), Mathf.Min(onClickLeftStartPosition.y, onClickLeftEndPosition.y));
        var upperRight = new Vector2(Mathf.Max(onClickLeftStartPosition.x, onClickLeftEndPosition.x), Mathf.Max(onClickLeftStartPosition.y, onClickLeftEndPosition.y));

        screenRealSelection.position = lowerLeft;
        screenRealSelection.size = upperRight - lowerLeft;

        switch (mouseState)
        {
            case MouseState.Normal:
                RenderSelectionArea(lowerLeft, upperRight);
                break;
            case MouseState.ExpandZone:
            case MouseState.ShrinkZone:
            case MouseState.AddSection:
            case MouseState.DeleteSection:
            case MouseState.ExpandStorageZone:
            case MouseState.ShrinkStorageZone:
            case MouseState.AddStorageSection:
            case MouseState.DeleteStorageSection:
                RenderPlantManager();
                break;
            case MouseState.BuildingGhost:
                break;
            default:
                break;
        }
    }

    public void EnableRenderGhostBuilding()
    {
        GhostRender itemRender = ghostBuilding.GetComponent<GhostRender>();
        itemRender.EnableRender();
    }

    public void DisableRenderGhostBuilding()
    {
        GhostRender itemRender = ghostBuilding.GetComponent<GhostRender>();
        itemRender.DisableRender();
    }

    public void UpdateGhostBuilding(int buildingCode)
    {
        GhostRender itemRender = ghostBuilding.GetComponent<GhostRender>();
        itemRender.UpdateRender(ObjectConfig.GetBuildingSprite(buildingCode));
    }

    private void UpdateGhostPos(Vector3 pos)
    {
        var gridCell = pos.ToCellCenter();
        ghostBuilding.transform.position = new Vector3(gridCell.x, gridCell.y, 0);
    }

    private void RenderPlantManager()
    {
        if (MapManager.Instance.ColonyMap != null)
        {
            var grids = GetWorldGrids(MapManager.Instance.ColonyMap,
                InputUtils.GetWorldRect(onClickLeftStartPositionWorldPosition, onClickLeftEndPositionWorldPosition));
            foreach (var item in grids)
            {
                GraphicsUtiliy.DrawSelectedPlantZoom(item.pos.To3(), MaterialDatabase.Instance.selectMaterial, 2, "GameDisplay");
            }
        }
    }

    private void RenderSelectionArea(Vector2 lowerLeft, Vector2 upperRight)
    {
        selectedArea.position = lowerLeft;
        var originalVec2 = (upperRight - lowerLeft);
        var uiCanvas = GameObject.FindObjectOfType<UICanvas>();
        var sX = originalVec2.x / Screen.width * uiCanvas.Size.x;
        var sY = originalVec2.y / Screen.height * uiCanvas.Size.y;
        selectedArea.sizeDelta = new Vector2(sX, sY);
        //Debug.Log($"Screen Info:{Screen.width},{Screen.height}");
    }

    public MapGridDetails[] GetWorldGrids(Map map, Rect worldRect)
    {
        List<MapGridDetails> grids = new List<MapGridDetails>();
        foreach (var item in map.mapGrids)
        {
            if (item.gridRect.Overlaps(worldRect))
            {
                grids.Add(item);
            }
        }
        return grids.ToArray();
    }
}
