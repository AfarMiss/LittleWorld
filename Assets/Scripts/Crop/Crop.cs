using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    private int currentHarvestAction = 0;

    [Tooltip("This should be populated from child transform gameobject showing harvest effect spawn point")]
    [SerializeField] private Transform harvestActionEffectTransform = null;

    [HideInInspector]
    public Vector2Int cropGridPosition;

    public Animator cropAnimator;
    public SpriteRenderer harvestAnimationSpriteRender;

    public void TryHarvest(Vector3Int playerDir, GridPropertyDetails gridPropertyDetails)
    {
        StartCoroutine(HarvestInterval(playerDir, gridPropertyDetails));
    }

    private IEnumerator HarvestInterval(Vector3Int playerDir, GridPropertyDetails gridPropertyDetails)
    {
        var cropDetail = GridPropertiesManager.Instance.GetCropDetails(gridPropertyDetails);

        currentHarvestAction++;

        if (currentHarvestAction >= cropDetail.requiredHarvestActions[0])
        {
            //动画机相关
            if (harvestAnimationSpriteRender != null)
            {
                if (cropDetail.isHarvestedAnimation)
                {
                    harvestAnimationSpriteRender.enabled = true;
                    harvestAnimationSpriteRender.sprite = cropDetail.harvestedSprite;
                }
                else
                {
                    harvestAnimationSpriteRender.enabled = false;
                }
            }


            if (playerDir == Vector3Int.right || playerDir == Vector3Int.up)
            {
                cropAnimator.SetBool("harvestright", true);
            }
            else
            {
                cropAnimator.SetBool("harvestleft", true);
            }

            while (cropAnimator != null && !cropAnimator.GetCurrentAnimatorStateInfo(0).IsName("Harvested"))
            {
                yield return null;
            }

            foreach (var item in cropDetail.harvestItems)
            {
                var harvestCount = Random.Range(item.minQuantity, item.maxQuantity);
                for (int i = 0; i < harvestCount; i++)
                {
                    SceneItemsManager.Instance.InstantiateSingleSceneItem(item.harvestItemCode,
                        transform.position + (Vector3)Random.insideUnitCircle);
                }
            }
            Destroy(gameObject);

            //数据设置
            if (cropDetail.afterHarvestSeedItemCode > -1)
            {
                gridPropertyDetails.daysSinceLastHarvest = 0;
                gridPropertyDetails.growthDays = 0;
                gridPropertyDetails.seedItemCode = cropDetail.afterHarvestSeedItemCode;
            }
            else
            {
                gridPropertyDetails.daysSinceLastHarvest = -1;
                gridPropertyDetails.growthDays = -1;
                gridPropertyDetails.seedItemCode = -1;
            }


            GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);
            EventCenter.Instance?.Trigger<GridPropertyDetails>(EventEnum.GRID_MODIFY.ToString(), gridPropertyDetails);
        }
        else
        {
            if (playerDir == Vector3Int.right || playerDir == Vector3Int.up)
            {
                cropAnimator.SetBool("usetoolright", true);
            }
            else
            {
                cropAnimator.SetBool("usetoolleft", true);
            }

            if (cropDetail.isHarvestActionEffect)
            {
                EventCenter.Instance.Trigger(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), harvestActionEffectTransform.position, cropDetail.harvestActionEffect);
            }
        }

    }
}
