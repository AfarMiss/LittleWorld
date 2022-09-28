using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private UIInventorySlot[] uIInventorySlots;

    private Camera mainCamera;
    private bool isInBottom = true;

    private void OnEnable()
    {
        EventHandler.PickUpEvent += OnPickUp;
    }

    private void OnDisable()
    {
        EventHandler.PickUpEvent -= OnPickUp;
    }

    private void OnPickUp(Item obj)
    {
        BindData(InventoryManager.Instance.InventoryDictionary[(int)InventoryLocation.player]);
    }

    private void BindData(List<InventoryItem> itemsList)
    {
        for (int i = 0; i < uIInventorySlots.Length; i++)
        {
            if (i < itemsList.Count)
            {
                uIInventorySlots[i].BindData(itemsList[i]);
            }
            else
            {
                uIInventorySlots[i].BindBlank();
            }
        }
    }

    private void FixedUpdate()
    {
        CheckUIPos();
    }

    private void CheckUIPos()
    {
        if (FarmPlayer.Instance != null)
        {
            var playerViewPortPos = Camera.main.WorldToViewportPoint(FarmPlayer.Instance.transform.position);
            if (playerViewPortPos.y > 0.3f && !isInBottom)
            {
                rectTransform.pivot = new Vector2(0.5f, 0f);
                rectTransform.anchorMin = new Vector2(0.5f, 0f);
                rectTransform.anchorMax = new Vector2(0.5f, 0f);
                rectTransform.anchoredPosition = new Vector2(0f, 2.5f);

                isInBottom = true;
            }
            if (playerViewPortPos.y <= 0.3f && isInBottom)
            {
                rectTransform.pivot = new Vector2(0.5f, 1f);
                rectTransform.anchorMin = new Vector2(0.5f, 1f);
                rectTransform.anchorMax = new Vector2(0.5f, 1f);
                rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

                isInBottom = false;
            }
        }
    }
}
