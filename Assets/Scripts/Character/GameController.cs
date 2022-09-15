using System.Collections.Generic;
using UniBase;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GameController : MonoSingleton<GameController>
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private List<RTSUnit> selectedUnits;
    private List<RTSUnit> allRtsUnits;
    private RectTransform selectedArea;
    private bool isInit = false;

    [SerializeField] private GameObject InteractionMenu;
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

    public void OnClickDoublePerformed()
    {
        if (UIManager.Instance.IsShowingPanel) return;
        CleanInteraction();

        Debug.Log("双击.performed -------");
        if (selectedUnits != null && selectedUnits.Count > 0)
        {
            Prepare();
            Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
            FindRectOverlap(screenRect);
        }
    }

    public void OnClickRightPerformed()
    {
        if (UIManager.Instance.IsShowingPanel) return;
        CleanInteraction();

        var ray = Camera.main.ScreenPointToRay(mousePosition);
        var rayHits = Physics.RaycastAll(ray.origin, ray.direction);

        if (rayHits == null || rayHits.Length == 0)
        {
            if (selectedUnits == null || selectedUnits.Count == 0) return;
            var bound = selectedUnits[0].GetComponent<BoxCollider2D>().bounds;
            var offset = (bound.max - bound.min).y + 0.8f;
            var destinations = InputUtils.GetLinearDestinations(InputUtils.GetMousePositionWithSpecificZ(selectedUnits[0].transform.position.z), selectedUnits.Count, offset);
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                RTSUnit item = selectedUnits[i];
                var controller = item.GetComponent<PlayerMoveController>();
                controller.Move(destinations[i]);
            }
        }
        else
        {
            var options = rayHits[0].collider.GetComponent<IOption>();
            options.OnInteraction();
        }
    }

    public void OnClickSetting(CallbackContext context)
    {
        if (context.performed)
            UIManager.Instance.Switch<SettingPanel>(UIType.PANEL, UIPath.Panel_SettingPanel);
    }

    public void OnCameraControl(CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (UIManager.Instance.IsShowingPanel) return;
            var camMove = callbackContext.ReadValue<Vector2>();
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(camMove);
        }
        else if (callbackContext.canceled)
        {
            if (UIManager.Instance.IsShowingPanel) return;
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(Vector2.zero);
        }

    }

    public void OnLeft(CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            if (UIManager.Instance.IsShowingPanel) return;
            startPosition = mousePosition;
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        }
        else if (callbackContext.canceled)
        {
            if (UIManager.Instance.IsShowingPanel) return;
            CleanInteraction();

            endPosition = mousePosition;
            selectedArea.gameObject.SetActive(false);

            Prepare();

            FindBoundOverlap();

            Debug.Log("Click.canceled -------");
            allRtsUnits.Clear();
        }
    }

    private void CleanInteraction()
    {
        var interactions = GameObject.FindObjectsOfType<InteractionMenu>();
        foreach (var item in interactions)
        {
            Destroy(item.gameObject);
        }
    }

    private void Prepare()
    {
        var allRtsUnitsObjects = GameObject.FindObjectsOfType<RTSUnit>();
        foreach (var item in allRtsUnitsObjects)
        {
            allRtsUnits.Add(item.GetComponent<RTSUnit>());
        }
        if (InputManager.Instance.myController.actions["附加操作"].IsPressed())
        {
            Debug.Log("附加操作正在被按下！");
            selectedUnits.Clear();
            //all units clear
            foreach (var unit in allRtsUnits)
            {
                unit.isSelected = false;
            }
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
        if (UIManager.Instance.IsShowingPanel || !isInit) return;
        mousePosition = InputUtils.GetMousePosition();
#if UNITY_EDITOR
        Debug.Log($"InputManager.Instance.myController.actions[左击].IsPressed():{InputManager.Instance.myController.actions["左击"].IsPressed()}");
#endif
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
