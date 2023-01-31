using UnityEngine;

public class ItemRender : MonoBehaviour
{
    [SerializeField, ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    public void Init(int itemCode)
    {
        var itemDetail = InventoryManager.Instance.GetItemDetail(itemCode);
        if (itemDetail.itemType == ItemType.reapable_scenery)
        {
            this.gameObject.AddComponent<NudgeItem>();
        }

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = itemDetail.itemSprite;
        spriteRenderer.transform.localScale = Vector3.one;
        var xOffset = spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit;
        var yOffset = spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit;
        spriteRenderer.transform.localPosition = new Vector3(xOffset, yOffset, 0);

        this.ItemCode = itemCode;
    }
}
