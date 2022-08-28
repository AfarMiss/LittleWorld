using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private List<RTSUnit> rtsUnits;
    private List<RTSUnit> allRtsUnits;

    public Transform selectedArea;

    private void Awake()
    {
        selectedArea.gameObject.SetActive(false);
    }

    private void Start()
    {
        rtsUnits = new List<RTSUnit>();
        allRtsUnits = new List<RTSUnit>();


        InputManager.Instance.myController.GlobalInput.Click.started += (callbackContext) =>
        {
            startPosition = UniBase.Utils.GetMouseWorldPosition();
            selectedArea.gameObject.SetActive(true);
            Debug.Log("Click.started -------");
        };

        InputManager.Instance.myController.GlobalInput.Click.canceled += (callbackContext) =>
        {
            endPosition = UniBase.Utils.GetMouseWorldPosition();
            selectedArea.gameObject.SetActive(false);
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPosition);
            Debug.Log($"collider2DArray.Length:{collider2DArray.Length}");
            Debug.Log("Click.canceled -------");
            rtsUnits.Clear();
            var allRtsUnitsObjects = GameObject.FindObjectsOfType<RTSUnit>();
            foreach (var item in allRtsUnitsObjects)
            {
                allRtsUnits.Add(item.GetComponent<RTSUnit>());
            }
            foreach (var item in allRtsUnits)
            {
                item.OnUnselected();
            }

            foreach (var item in collider2DArray)
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
        endPosition = UniBase.Utils.GetMouseWorldPosition();
        var lowerLeft = new Vector2(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y));
        var upperRight = new Vector2(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y));
        selectedArea.position = lowerLeft;
        selectedArea.localScale = upperRight - lowerLeft;
    }
}
