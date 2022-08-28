using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{
    private Vector3 startPosition;
    private List<RTSUnit> rtsUnits;
    private List<RTSUnit> allRtsUnits;
    private void Start()
    {
        rtsUnits = new List<RTSUnit>();
        allRtsUnits = new List<RTSUnit>();

        InputManager.Instance.myController.GlobalInput.Click.started += (callbackContext) =>
        {
            startPosition = UniBase.Utils.GetMouseWorldPosition();
            Debug.Log("Click.started -------");
        };
        InputManager.Instance.myController.GlobalInput.Click.canceled += (callbackContext) =>
        {

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UniBase.Utils.GetMouseWorldPosition());
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
                if(item. TryGetComponent<RTSUnit>(out var comp))
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
}
