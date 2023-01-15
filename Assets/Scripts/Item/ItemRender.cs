﻿using UnityEngine;

public class ItemRender : MonoBehaviour
{
    [SerializeField, ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Init(ItemCode);
        Debug.Log("itemcode:" + ItemCode);
    }

    public void Init(int itemCode)
    {
        var itemDetail = InventoryManager.Instance.GetItemDetail(itemCode);
        if (itemDetail.itemType == ItemType.reapable_scenery)
        {
            this.gameObject.AddComponent<NudgeItem>();
        }

        spriteRenderer.sprite = itemDetail.itemSprite;
        spriteRenderer.transform.localPosition = new Vector3(spriteRenderer.size.x / 2, spriteRenderer.size.y / 2, 0);

        this.ItemCode = itemCode;
    }
}
