using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropInstantiator : MonoBehaviour
{
    private Grid grid;
    [SerializeField]
    private int daySinceDug = -1;
    [SerializeField]
    private int daySinceWatered = -1;
    [SerializeField, ItemCodeDescription]
    private int seedItemCode = 0;
    [SerializeField]
    private int growthDays = 0;

    private void OnEnable()
    {
        //EventCenter.Instance.Register(EventEnum.INSTANTIATE_CROP_PREFAB.ToString(), InstantiateCropPrefabs, this);
    }

    private void InstantiateCropPrefabs()
    {
        grid = GameObject.FindObjectOfType<Grid>();

        Vector3Int cropGridPosition = grid.WorldToCell(transform.position);

        SetCropGridProperties(cropGridPosition);

        Destroy(gameObject);
    }

    private void SetCropGridProperties(Vector3Int cropGridPosition)
    {
        if (seedItemCode > 0)
        {
            GridPropertyDetails gridPropertyDetails;

            gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cropGridPosition.x, cropGridPosition.y);

            if (gridPropertyDetails == null)
            {
                gridPropertyDetails = new GridPropertyDetails();
            }

            gridPropertyDetails.daysSinceDug = daySinceDug;
            gridPropertyDetails.daysSinceWatered = daySinceWatered;
            gridPropertyDetails.seedItemCode = seedItemCode;
            gridPropertyDetails.growthDays = growthDays;

            GridPropertiesManager.Instance.SetGridPropertyDetails(cropGridPosition.x, cropGridPosition.y, gridPropertyDetails);
        }
    }

    private void OnDisable()
    {
        EventCenter.Instance.Unregister(EventEnum.INSTANTIATE_CROP_PREFAB.ToString(), InstantiateCropPrefabs);
    }
}
