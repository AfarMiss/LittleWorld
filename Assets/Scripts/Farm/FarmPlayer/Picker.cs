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
            InventoryManager.Instance.AddItem(InventoryLocation.player, item, item.gameObject);
        }
    }
}
