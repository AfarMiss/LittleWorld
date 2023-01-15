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
    public Image highLight;

    [SerializeField]
    private BaseInventory parentBar = null;
    [SerializeField]
    private GameObject itemPrefab = null;
    [SerializeField]
    private int itemSlotNumber;
    [SerializeField]
    private GameObject inventoryTextBoxPrefab = null;
    [SerializeField]
    private bool isSelected;

    public bool IsSelected { get => isSelected; set => isSelected = value; }

    private void Awake()
    {
        IsSelected = false;
        parentCanvas = GetComponentInParent<Canvas>();
    }

    private void OnEnable()
    {
        EventCenter.Instance?.Register(EventEnum.DROP_SELECTED_ITEM.ToString(), OnDropSelectedItem);
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(EventEnum.DROP_SELECTED_ITEM.ToString(), OnDropSelectedItem);
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
        Destroy(draggedItem);
    }

    private void OnSceneLoaded()
    {
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }

    public void BindData(InventoryItem inventoryItem, int slotIndex, int hightLightIndex)
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
        if (hightLightIndex == -1 || hightLightIndex != slotIndex)
        {
            highLight.color = new Color(1, 1, 1, 0);
        }
        else
        {
            highLight.color = new Color(1, 1, 1, 1);
        }
        Debug.Log($"hightLightIndex:{hightLightIndex},slotIndex:{slotIndex}");
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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            SetSelected();
            //FarmGameController.Instance.DisablePlayerInput();
            draggedItem = Instantiate(parentBar.inventoryBarDraggedItem, parentBar.transform);

            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
            draggedItemImage.sprite = image.sprite;

            EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), slotIndex);
        }
    }

    private void SetSelected()
    {
        SelectItem();
        IsSelected = true;
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

            //两个slot间交换
            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {
                DestroyInventoryTextBox();
                InventoryManager.Instance.SwapItem(InventoryLocation.player, itemSlotNumber, eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>().itemSlotNumber);
            }
            else
            {
                //这一部分交给FarmGameConroller.OnClickLeft，后期可以将丢弃键绑到键盘键[Q键之类的]，跟教程期间就先做此改动

                //if (itemDetails.canBeDropped)
                //{
                //    DropSelectedItemAtMousePosition();
                //}
            }

            FarmGameController.Instance.EnablePlayerInput();
        }
    }

    private void DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null)
        {
            if (GridCursor.Instance.CursorPositionIsValid)
            {
                Vector3 worldPosition = UniBase.InputUtils.GetMousePositionToWorldWithSpecificZ(-mainCamera.transform.position.z);
                GameObject itemGameObject = Instantiate(itemPrefab, new Vector3(worldPosition.x, worldPosition.y - FarmSetting.gridCellSize * 0.5f, worldPosition.z), Quaternion.identity, parentItem);
                ItemRender item = itemGameObject.GetComponent<ItemRender>();
                item.ItemCode = itemDetails.itemCode;

                InventoryManager.Instance.RemoveItem(InventoryLocation.player, item);
            }
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
            CheckSelected();
        }
    }

    private void CheckSelected()
    {
        if (IsSelected)
        {
            ClearSelected();
        }
        else
        {
            SelectItem();
        }
        IsSelected = !IsSelected;
    }

    private void SelectItem()
    {
        this.parentBar.ClearPlayerSelected();
        EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), slotIndex);
        Debug.Log($"SelectItem:{slotIndex}");
    }

    private void ClearSelected()
    {
        EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), -1);
        Debug.Log($"SelectItem:-1");
    }

    private void OnDropSelectedItem()
    {
        if (IsSelected)
        {
            DropSelectedItemAtMousePosition();
        }
    }
}
