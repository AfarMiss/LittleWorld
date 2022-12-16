﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    private int currentHarvestAction = 0;
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

        currentHarvestAction++;

        if (currentHarvestAction >= cropDetail.requiredHarvestActions[0])
        {

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
                        Director.Instance.MainPlayer.GetPlayrCentrePosition() + (Vector3)Random.insideUnitCircle);
                }
            }
            Destroy(gameObject);

            //数据设置
            gridPropertyDetails.daysSinceLastHarvest = -1;
            gridPropertyDetails.growthDays = -1;
            gridPropertyDetails.seedItemCode = -1;
            GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);
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
        }

    }
}
