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
        var xOffset = spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit;
        var yOffset = spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit;
        spriteRenderer.transform.localPosition = new Vector3(xOffset, yOffset, 0);
        if (!(wo is Animal))
        {
            this.transform.position = wo.GridPos.To3();
        }
    }

    private void OnDestroy()
    {
        Debug.Log("???");
    }
}
