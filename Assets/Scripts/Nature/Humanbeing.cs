using LittleWorldObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        public void Pick(Brush brush)
        {
            var navi = GetComponent<PathNavigationOnly>();
            navi.AddMovePositionAndMove(brush.transform.position, () =>
            {
                PickCoroutine(brush.transform.position);
            });
        }

        public void PickCoroutine(Vector3 fruitPos)
        {
            EventCenter.Instance.Trigger(EventEnum.PICK_FRUIT.ToString(), new PickFruitMessage()
            {
                totalPickTime = 5,
                fruitType = 2,
                fruitCount = 3,
                pickFruitPos = fruitPos,
            }); ;
        }
    }
}