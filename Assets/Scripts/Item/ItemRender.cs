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
        //this.gameObject.AddComponent<NudgeItem>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = worldObject.GetSprite();
        DefaultSet();

        if (worldObject is Humanbeing human && human.CurrentTake != null)
        {
            Transform itemTransform = SceneObjectManager.Instance.WorldItemsRenderer[human.CurrentTake].transform;
            itemTransform.SetParent(transform);
            itemTransform.localPosition = Vector3.zero;
            itemTransform.localScale = Vector3.one;
        }

        this.ItemCode = worldObject.itemCode;
    }

    private void DefaultSet()
    {
        spriteRenderer.transform.localScale = Vector3.one;
        var xOffset = spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit;
        var yOffset = spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit;
        spriteRenderer.transform.localPosition = new Vector3(xOffset, yOffset, 0);
    }
}
