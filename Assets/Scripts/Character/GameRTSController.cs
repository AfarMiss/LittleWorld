using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private List<RTSUnit> rtsUnits;
    private List<RTSUnit> allRtsUnits;

    public RectTransform selectedArea;

    private void Awake()
    {
        var sa = Resources.Load<GameObject>("Prefabs/UI/SelectionArea2");
        var saObject = Instantiate(sa);
        saObject.name = saObject.name.Substring(0, saObject.name.LastIndexOf("(Clone)"));

        selectedArea = saObject.GetComponent<RectTransform>();
        selectedArea.transform.SetParent(GameObject.Find("Canvas").transform);
        selectedArea.gameObject.SetActive(false);
    }

    private void Start()
    {
        rtsUnits = new List<RTSUnit>();
        allRtsUnits = new List<RTSUnit>();


        InputManager.Instance.myController.GlobalInput.Click.started += (callbackContext) =>
        {
            startPosition = UniBase.Utils.GetMousePosition();
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        };

        InputManager.Instance.myController.GlobalInput.Click.canceled += (callbackContext) =>
        {
            endPosition = UniBase.Utils.GetMousePosition();
            selectedArea.gameObject.SetActive(false);
            //all units
            var allRtsUnitsObjects = GameObject.FindObjectsOfType<RTSUnit>();
            foreach (var item in allRtsUnitsObjects)
            {
                allRtsUnits.Add(item.GetComponent<RTSUnit>());
            }
            foreach (var item in allRtsUnits)
            {
                item.OnUnselected();
            }
            Debug.Log("Click.canceled -------");
            rtsUnits.Clear();


            foreach (var item in allRtsUnits)
            {
                if (item.TryGetComponent<RTSUnit>(out var comp))
                {
                    rtsUnits.Add(comp);
                }
            }

            foreach (var item in rtsUnits)
            {
                item.OnSelected();
            }
        };
    }

    private void Update()
    {
        if (InputManager.Instance.myController.GlobalInput.Click.IsPressed())
        {
            endPosition = UniBase.Utils.GetMousePosition();
            var lowerLeft = new Vector2(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y));
            var upperRight = new Vector2(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y));
            selectedArea.position = lowerLeft;
            selectedArea.sizeDelta = upperRight - lowerLeft;
            
        }
    }

    private void DrawRect()
    {

    }
}
