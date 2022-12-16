using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CropDetails
{
    [ItemCodeDescription]
    public int seedItemCode;
    public int[] growthDays;
    public GameObject[] growthPrefab;
    public Sprite[] growthSprite;
    public int[] seasons;
    public Sprite harvestedSprite;

    [ItemCodeDescription]
    public int harvestedTransformItemCode;
    public bool hideCropBeforeHarvestedAnimation;
    public bool disableCropCollidersBeforeHarvestedAnimation;

    public bool isHarvestedAnimation;
    public bool isHarvestActionEffect = false;
    public bool spawnCropProducedAtPlayerPosition;
    public HarvestActionEffect harvestActionEffect;

    [ItemCodeDescription]
    public int[] harvestToolItemCode;
    public int[] requiredHarvestActions;

    public List<HarvestItem> harvestItems;

    public int daysToRegrow;

    public int totalGrowthDays
    {
        get
        {
            var result = 0;
            foreach (var item in growthDays)
            {
                result += item;
            }
            return result;
        }
    }

    public bool CanUseToolToHarvestCrop(int toolItemCode)
    {
        return RequiredHarvestActionsForTool(toolItemCode) != -1;
    }

    public int RequiredHarvestActionsForTool(int toolItemCode)
    {
        for (int i = 0; i < harvestToolItemCode.Length; i++)
        {
            if (harvestToolItemCode[i] == toolItemCode)
            {
                return requiredHarvestActions[i];
            }
        }
        return -1;
    }
}
