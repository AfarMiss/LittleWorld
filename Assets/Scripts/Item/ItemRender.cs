using LittleWorld.Extension;
using LittleWorld.Item;
using UnityEngine;

public class ItemRender : MonoBehaviour
{
    [SerializeField, ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weapon;
    private SpriteRenderer hualThing;

    private void Start()
    {
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var item in spriteRenderers)
        {
            switch (item.tag)
            {
                case "avatar":
                    spriteRenderer = item;
                    break;
                case "haulThing":
                    hualThing = item;
                    break;
                case "playerWeapon":
                    weapon = item;
                    break;
                default:
                    break;
            }
        }
    }

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    public void Render<T>(T worldObject) where T : WorldObject
    {
        if (spriteRenderer == null) return;
        spriteRenderer.enabled = !worldObject.isCarried;
        if (worldObject.isCarried || worldObject.inBuildingConstruction) { return; }
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
        if (wo is Animal animal)
        {
            spriteRenderer.sprite = animal.GetFaceSprite();
            spriteRenderer.flipX = animal.faceTo == Face.Left;
            if (wo is Humanbeing human && human.gearTracer.curWeapon != null)
            {
                weapon.sprite = human.gearTracer.curWeapon.GetSprite();
            }
        }
        else
        {
            this.transform.position = wo.GridPos.To3();
        }
        if (wo is Building curBuilding)
        {
            switch (curBuilding.buildingStatus)
            {
                case BuildingStatus.Done:
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                    break;
                case BuildingStatus.BluePrint:
                    spriteRenderer.color = new Color(1, 1, 1, 0.3f);
                    break;
                default:
                    break;
            }
        }
    }
}
