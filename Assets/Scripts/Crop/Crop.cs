using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [HideInInspector]
    public Vector2Int cropGridPosition;

    public Animator cropAnimator;
    public SpriteRenderer harvestAnimationSpriteRender;

    public void Harvest(Vector3Int playerDir)
    {
        StartCoroutine(HarvestInterval(playerDir));
    }

    private IEnumerator HarvestInterval(Vector3Int playerDir)
    {
        GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cropGridPosition.x, cropGridPosition.y);
        var cropDetail = GridPropertiesManager.Instance.GetCropDetails(gridPropertyDetails);
        SceneItemsManager.Instance.InstantiateSingleSceneItem(cropDetail.GetProducedItemCode(), Director.Instance.MainPlayer.GetPlayrCentrePosition());

        //动画机相关
        harvestAnimationSpriteRender.sprite = cropDetail.harvestedSprite;
        if (playerDir == Vector3Int.right || playerDir == Vector3Int.up)
        {
            cropAnimator.SetBool("harvestleft", true);
        }
        else
        {
            cropAnimator.SetBool("harvestright", true);
        }

        while (cropAnimator != null && !cropAnimator.GetCurrentAnimatorStateInfo(0).IsName("Harvested"))
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
