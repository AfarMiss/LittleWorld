using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LittleWorld.UI
{
    public class UIInventoryBar : BaseInventory
    {
        protected override void BindDataWith(List<InventoryItem> itemsList, int hightLightIndex)
        {
            base.BindDataWith(itemsList, hightLightIndex);
            for (int i = 0; i < uIInventorySlots.Length; i++)
            {
                if (i < itemsList.Count)
                {
                    uIInventorySlots[i].BindData(itemsList[i], i, hightLightIndex);
                }
                else
                {
                    uIInventorySlots[i].BindData(new InventoryItem(-1, -1), i, hightLightIndex);
                }
            }
        }

        private void FixedUpdate()
        {
            CheckUIPos();
        }

        protected override void CheckUIPos()
        {
            //if (FarmPlayer.Instance != null)
            //{
            //    var playerViewPortPos = Camera.main.WorldToViewportPoint(FarmPlayer.Instance.transform.position);
            //    if (playerViewPortPos.y > 0.3f && !isInBottom)
            //    {
            //        rectTransform.pivot = new Vector2(0.5f, 0f);
            //        rectTransform.anchorMin = new Vector2(0.5f, 0f);
            //        rectTransform.anchorMax = new Vector2(0.5f, 0f);
            //        rectTransform.anchoredPosition = new Vector2(0f, 2.5f);

            //        isInBottom = true;
            //    }
            //    if (playerViewPortPos.y <= 0.3f && isInBottom)
            //    {
            //        rectTransform.pivot = new Vector2(0.5f, 1f);
            //        rectTransform.anchorMin = new Vector2(0.5f, 1f);
            //        rectTransform.anchorMax = new Vector2(0.5f, 1f);
            //        rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

            //        isInBottom = false;
            //    }
            //}
        }
    }

}
