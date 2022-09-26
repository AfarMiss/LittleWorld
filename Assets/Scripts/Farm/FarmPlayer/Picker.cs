using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ɼ�������Ķ���
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
