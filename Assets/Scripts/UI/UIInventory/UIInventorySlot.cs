using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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
    private Canvas parentCanvas;
    private int slotIndex;

    [SerializeField]
    private UIInventoryBar parentBar = null;
    [SerializeField]
    private GameObject itemPrefab = null;
    [SerializeField]
    private int itemSlotNumber;
    [SerializeField]
    private GameObject inventoryTextBoxPrefab = null;
    private bool isSelected;

    private void Awake()
    {
        isSelected = false;
        parentCanvas = GetComponentInParent<Canvas>();
    }

    public void BindData(InventoryItem inventoryItem, int slotIndex)
    {
        var itemDetail = InventoryManager.Instance.GetItemDetail(inventoryItem.itemCode);
        if (itemDetail != null)
        {
            this.image.sprite = itemDetail.itemSprite;
            this.quantity = inventoryItem.itemQuantity;
            this.itemDetails = itemDetail;
            this.quantityText.text = inventoryItem.itemQuantity.ToString();
        }
        else
        {
            BindBlank();
        }
        this.slotIndex = slotIndex;
    }

    private void BindBlank()
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

            draggedItem = Instantiate(parentBar.inventoryBarDraggedItem, parentBar.transform);

            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
            draggedItemImage.sprite = image.sprite;
        }
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.transform.position = UniBase.InputUtils.GetMousePosition();
            Debug.Log($"draggedItem.transform.position :{draggedItem.transform.position}");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            Destroy(draggedItem);

            //����slot�佻��
            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {
                DestroyInventoryTextBox();
                InventoryManager.Instance.SwapItem(InventoryLocation.player, itemSlotNumber, eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>().itemSlotNumber);
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

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInventoryTextBox();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (quantity != 0)
        {
            parentBar.inventoryTextBoxGameobject = Instantiate(inventoryTextBoxPrefab, transform.position, Quaternion.identity);
            parentBar.inventoryTextBoxGameobject.transform.SetParent(parentCanvas.transform, false);

            UIInventoryTextBox inventoryTextBox = parentBar.inventoryTextBoxGameobject.GetComponent<UIInventoryTextBox>();

            string itemTypeDescription = InventoryManager.Instance.GetItemTypeDescription(itemDetails.itemType);

            inventoryTextBox.SetTextboxText(itemDetails.itemDescription, itemTypeDescription, "", itemDetails.itemLongDescription, "", "");

            if (parentBar.IsInBottom)
            {
                parentBar.inventoryTextBoxGameobject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
                parentBar.inventoryTextBoxGameobject.transform.position = new Vector3(transform.position.x, transform.position.y + 50f, transform.position.z);
            }
            else
            {
                parentBar.inventoryTextBoxGameobject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
                parentBar.inventoryTextBoxGameobject.transform.position = new Vector3(transform.position.x, transform.position.y - 50f, transform.position.z);
            }
        }
    }

    public void DestroyInventoryTextBox()
    {
        if (parentBar.inventoryTextBoxGameobject != null)
        {
            Destroy(parentBar.inventoryTextBoxGameobject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isSelected)
            {
                ClearSelected();
            }
            else
            {
                SelectItem();
            }
        }
    }

    private void SelectItem()
    {
        EventCenter.Instance.Trigger(nameof(EventEnum.UPDATE_BAR_SELECTED), slotIndex);
    }

    private void ClearSelected()
    {
        EventCenter.Instance.Trigger(nameof(EventEnum.CLEAR_BAR_SELECTED));
    }
}
