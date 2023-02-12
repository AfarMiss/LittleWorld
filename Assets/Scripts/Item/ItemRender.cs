using LittleWorld.Extension;
using LittleWorld.Item;
using UnityEngine;

public class ItemRender : MonoBehaviour
{
    [SerializeField, ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    public void Render<T>(T worldObject) where T : WorldObject
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.enabled = !worldObject.isCarried;
        if (worldObject.isCarried) { return; }
        //this.gameObject.AddComponent<NudgeItem>();
        spriteRenderer.sprite = worldObject.GetSprite();
        Set(worldObject);

        this.ItemCode = worldObject.itemCode;
    }

    private void Set(WorldObject wo)
    {
        spriteRenderer.transform.localScale = Vector3.one;
        spriteRenderer.transform.localPosition = new Vector3(
            spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit,
            spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit,
            0);
        if (!(wo is Animal))
        {
            this.transform.position = wo.GridPos.To3();
        }
    }
}
