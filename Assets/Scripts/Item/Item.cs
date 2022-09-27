using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField,ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (ItemCode != 0)
        {
            Init(ItemCode);    
        }
    }

    public void Init(int itemCode)
    {
        var itemDetail = InventoryManager.Instance.GetItemDetail(itemCode);
        if (itemDetail.itemType == ItemType.reapable_scenery)
        {
            this.gameObject.AddComponent<NudgeItem>();
        }
        
    }
}
