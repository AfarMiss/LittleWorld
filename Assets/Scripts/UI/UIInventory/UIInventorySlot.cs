using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Text quantityText;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite blank;
    private int quantity;
    private ItemDetails itemDetails;

    private Camera mainCamera;
    private Transform parentItem;
    private GameObject draggedItem;

    [SerializeField]
    private UIInventoryBar inventoryBar = null;
    [SerializeField]
    private GameObject itemPrefab = null;

    public void BindData(InventoryItem inventoryItem)
    {
        var itemDetail = InventoryManager.Instance.GetItemDetail(inventoryItem.itemCode);
        this.image.sprite = itemDetail.itemSprite;
        this.quantity = inventoryItem.itemQuantity;
        this.itemDetails = itemDetail;
        this.quantityText.text = inventoryItem.itemQuantity.ToString();
    }

    public void BindBlank()
    {
        this.image.sprite = blank;
        this.quantity = 0;
        this.itemDetails = null;
        this.quantityText.text = "";
    }

    private void Start()
    {
        mainCamera = Camera.main;
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            //FarmGameController.Instance.DisablePlayerInput();

            draggedItem = Instantiate(inventoryBar.inventoryBarDraggedItem, inventoryBar.transform);

            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
            draggedItemImage.sprite = image.sprite;
        }
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.transform.position = UniBase.InputUtils.GetMousePosition();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            Destroy(draggedItem);

            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {

            }
            else
            {
                if (itemDetails.canBeDropped)
                {
                    DropSelectedItemAtMousePosition();
                }
            }

            FarmGameController.Instance.EnablePlayerInput();
        }
    }

    private void DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null)
        {
            Vector3 worldPosition = UniBase.InputUtils.GetMousePositionToWorldWithSpecificZ(-mainCamera.transform.position.z);

            GameObject itemGameObject = Instantiate(itemPrefab, worldPosition, Quaternion.identity, parentItem);
            Item item = itemGameObject.GetComponent<Item>();
            item.ItemCode = itemDetails.itemCode;

            InventoryManager.Instance.RemoveItem(InventoryLocation.player, item);
        }
    }
}
