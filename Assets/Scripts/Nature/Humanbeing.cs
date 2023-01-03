using LittleWorldObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        public void Pick(Brush brush)
        {
            var navi = GetComponent<PathNavigationOnly>();
            navi.AddMovePositionAndMove(brush.transform.position, () =>
            {
                StartCoroutine(PickCoroutine(brush));
            });
        }

        public IEnumerator PickCoroutine(Brush fruit)
        {
            EventCenter.Instance.Trigger(EventEnum.PICK_FRUIT.ToString(), new PickFruitMessage()
            {
                totalPickTime = fruit.pickTime,
                fruitType = fruit.fruitItemCode,
                fruitCount = fruit.fruitCount,
                pickFruitPos = fruit.transform.position,
            });
            yield return new WaitForSeconds(3);

            var harvestCount = fruit.fruitCount;
            for (int i = 0; i < harvestCount; i++)
            {
                SceneItemsManager.Instance.InstantiateSingleSceneItem(fruit.fruitItemCode,
                    transform.position + (Vector3)Random.insideUnitCircle);
            }
        }
    }
}