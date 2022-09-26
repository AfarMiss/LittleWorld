using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可捡起物体的对象
/// </summary>
public class Picker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if (item != null)
        {
            var itemDetail = InventoryManager.Instance.GetItemDetail(item.ItemCode);
            Debug.Log(itemDetail.itemDescription);
        }
    }
}
