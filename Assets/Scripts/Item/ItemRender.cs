using DG.Tweening;
using LittleWorld;
using LittleWorld.Extension;
using LittleWorld.Item;
using System;
using System.Collections;
using UnityEngine;

public class ItemRender : MonoBehaviour, IRenderer
{
    [SerializeField, ItemCodeDescription]
    private int itemCode;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weapon;
    private SpriteRenderer hualThing;
    private WorldObject worldObject;
    private float lastHit = -1;

    private Vector3 initEulerAngle;

    public void Init(WorldObject wo)
    {
        this.worldObject = wo;
        if (wo is Animal animal)
        {
            animal.OnBeHurt += OnBeHurt;
        }
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
        if (weapon != null)
        {
            initEulerAngle = weapon.transform.eulerAngles;
        }
    }

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    public void OnBeHurt()
    {
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor(Color.white, 0.5f);
        //StartCoroutine(LogColor());
    }

    private IEnumerator LogColor()
    {
        Debug.Log($"{worldObject.ItemName}_{worldObject.instanceID} spriteRenderer.color before hurt:{spriteRenderer.color}");
        yield return new WaitForSeconds(0.5f);
        Debug.Log($"{worldObject.ItemName}_{worldObject.instanceID} spriteRenderer.color after hurt:{spriteRenderer.color}");
    }

    public void OnRender()
    {
        if (spriteRenderer == null) return;
        spriteRenderer.enabled = !worldObject.isCarried;
        if (worldObject.isCarried || worldObject.inBuildingConstruction) { return; }
        //this.gameObject.AddComponent<NudgeItem>();
        spriteRenderer.sprite = worldObject.GetSprite();
        OnUpdate(worldObject);

        this.ItemCode = worldObject.itemCode;

    }

    public void OnDisRender()
    {
        if (worldObject != null && worldObject is Animal animal)
        {
            animal.OnBeHurt -= OnBeHurt;
        }
    }

    public void OnDie()
    {
        this.spriteRenderer.transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
    }

    private void SetPropertyOnce()
    {

    }

    private void OnUpdate(WorldObject wo)
    {
        spriteRenderer.transform.localScale = Vector3.one;
        //spriteRenderer.transform.localPosition = new Vector3(
        //    spriteRenderer.sprite.pivot.x / spriteRenderer.sprite.pixelsPerUnit,
        //    spriteRenderer.sprite.pivot.y / spriteRenderer.sprite.pixelsPerUnit,
        //    0);
        if (wo is Animal animal)
        {
            //渲染组件和物体实际位置偏差为vector2.one/2
            spriteRenderer.transform.localPosition = new Vector3(0.5f, 0.5f, 0);
            weapon.enabled = false;
            spriteRenderer.sprite = animal.GetFaceSprite();
            spriteRenderer.flipX = animal.FaceTo == Face.Left;
            if (wo is Humanbeing human)
            {
                weapon.enabled = human.gearTracer.curWeapon != null;
                if (human.gearTracer.curWeapon != null)
                {
                    weapon.sprite = human.gearTracer.curWeapon.GetSprite();
                    weapon.transform.eulerAngles = animal.FaceTo == Face.Left ? initEulerAngle + 180f * Vector3.up : initEulerAngle;
                }
                weapon.sortingOrder = animal.FaceTo == Face.Up ? -1 : 2;
            }
        }
        else
        {
            spriteRenderer.transform.localPosition = Vector3.zero;
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

            switch (curBuilding.buildingInfo.layer)
            {
                case 0:
                    spriteRenderer.sortingOrder = 0;
                    break;
                case 1:
                    spriteRenderer.sortingOrder = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
