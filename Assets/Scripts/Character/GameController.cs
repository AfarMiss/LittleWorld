using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private List<RTSUnit> selectedUnits;
    private List<RTSUnit> allRtsUnits;

    [SerializeField] private GameObject InteractionMenu;
    [SerializeField] private RectTransform selectedArea;

    private Rect realSelection;


    private void Awake()
    {
        RectTransform rectObject = null;

        rectObject = Instantiate(selectedArea);
        rectObject.name = rectObject.name.Substring(0, rectObject.name.LastIndexOf("(Clone)"));
        selectedArea = rectObject.GetComponent<RectTransform>();

        rectObject.transform.SetParent(GameObject.Find("Canvas").transform);
        rectObject.gameObject.SetActive(false);

        realSelection = new Rect();
    }

    private void Start()
    {
        selectedUnits = new List<RTSUnit>();
        allRtsUnits = new List<RTSUnit>();


        InputManager.Instance.myController.GlobalInput.LeftClick.started += (callbackContext) =>
        {
            startPosition = InputUtils.GetMousePosition();
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        };

        InputManager.Instance.myController.GlobalInput.LeftClick.canceled += (callbackContext) =>
        {
            CleanInteraction();

            endPosition = InputUtils.GetMousePosition();
            selectedArea.gameObject.SetActive(false);

            Prepare();

            FindBoundOverlap();

            Debug.Log("Click.canceled -------");
            allRtsUnits.Clear();
        };

        InputManager.Instance.myController.GlobalInput.DoubleClick.performed += (callbackContext) =>
        {
            CleanInteraction();

            Debug.Log("DoubleClick.performed -------");
            if (selectedUnits != null && selectedUnits.Count > 0)
            {
                Prepare();
                Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
                FindRectOverlap(screenRect);
            }
        };

        InputManager.Instance.myController.GlobalInput.RightClick.performed += (callbackContext) =>
        {
            CleanInteraction();

            var ray = Camera.main.ScreenPointToRay(InputUtils.GetMousePosition());
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
                var options= rayHits[0].collider.GetComponent<IOption>();
                options.OnInteraction();
            }


        };

        InputManager.Instance.myController.GlobalInput.CameraControl.performed += callbackContext =>
        {
            var camMove = callbackContext.ReadValue<Vector2>();
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(camMove);
        };

        InputManager.Instance.myController.GlobalInput.CameraControl.canceled += callbackContext =>
        {
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.Move(Vector2.zero);
        };
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

        if (!InputManager.Instance.myController.GlobalInput.Additional.IsPressed())
        {
            selectedUnits.Clear();
            //all units clear
            foreach (var item in allRtsUnits)
            {
                item.isSelected = false;
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
        if (InputManager.Instance.myController.GlobalInput.LeftClick.IsPressed())
        {
            //更新选择区域
            endPosition = InputUtils.GetMousePosition();
            var lowerLeft = new Vector2(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y));
            var upperRight = new Vector2(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y));
            selectedArea.position = lowerLeft;
            selectedArea.sizeDelta = upperRight - lowerLeft;

            realSelection.position = lowerLeft;
            realSelection.size = selectedArea.sizeDelta;
        }
    }
}
