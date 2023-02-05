using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.UI
{
    public class UIUtility
    {
        public bool JudgeUiInScreen(RectTransform rect, ref Vector3 targetPos)
        {
            return false;
            //bool isInView = false;
            //float moveDistance = 0;
            //Vector3 screenPos = rect.transform.position;
            //float leftX = screenPos.x - rect.sizeDelta.x / 2;
            //float rightX = screenPos.x + rect.sizeDelta.x / 2;
            //if (leftX >= 0 && rightX <= Screen.width)
            //{
            //    isInView = true;
            //}
            //else
            //{
            //    if (leftX < 0)//需要右移进入屏幕范围
            //    {
            //        moveDistance = -leftX;
            //    }
            //    if (rightX > Screen.width)//需要左移进入屏幕范围
            //    {
            //        moveDistance = Screen.width - rightX;
            //    }
            //    targetPos = 需要显示的物体世界坐标 + new Vector3(moveDistance, 0, 0);
            //}
            //return isInView;
        }
    }
}
