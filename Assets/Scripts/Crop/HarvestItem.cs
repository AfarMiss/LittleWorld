using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HarvestItem
{
    [ItemCodeDescription]
    public int harvestItemCode;
    public int minQuantity;
    public int maxQuantity;
}
