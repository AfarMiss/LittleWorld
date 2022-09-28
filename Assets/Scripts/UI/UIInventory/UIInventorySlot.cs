using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField]
    private Text quantityText;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite blank;
    private int quantity;
    private ItemDetails itemDetails;

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
}
