using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        public Queue<HumanAction> actionQueue;
        public Coroutine curPickCoroutine;
        public int curInteractionItemID;
        private void Start()
        {
            ItemName = "人类";

            actionQueue = new Queue<HumanAction>();
            curInteractionItemID = -1;
        }
        public void Pick(Brush brush)
        {
            var navi = GetComponent<PathNavigationOnly>();
            navi.AddMovePositionAndMove(brush.transform.position, () =>
            {
                curPickCoroutine = StartCoroutine(PickCoroutine(brush));
            });
            actionQueue.Enqueue(new HumanAction()
            {
                actionEnum = ActionEnum.PICK,
                OperationItemID = brush.GetInstanceID()
            });
            curInteractionItemID = brush.GetInstanceID();
        }

        private IEnumerator PickCoroutine(Brush fruit)
        {
            EventCenter.Instance.Trigger(EventEnum.PICK_FRUIT.ToString(), new PickFruitMessage()
            {
                fruitID = fruit.GetInstanceID(),
                totalPickTime = fruit.pickTime,
                fruitType = fruit.fruitItemCode,
                fruitCount = fruit.fruitCount,
                pickFruitPos = fruit.transform.position,
            });
            yield return new WaitForSeconds(fruit.pickTime);

            var curAction = actionQueue.Dequeue();
            curPickCoroutine = null;
            curInteractionItemID = -1;
            var harvestCount = fruit.fruitCount;
            for (int i = 0; i < harvestCount; i++)
            {
                SceneItemsManager.Instance.InstantiateSingleSceneItem(fruit.fruitItemCode,
                    transform.position + (Vector3)Random.insideUnitCircle);
            }
        }

        public void CancelAllActivity()
        {
            if (curInteractionItemID != -1)
            {
                CancelPick(curInteractionItemID);
            }
        }

        public void CancelPick(int pickID)
        {
            EventCenter.Instance.Trigger(EventEnum.UNPICK_FRUIT.ToString(), new UnpickFruitMessage()
            {
                fruitID = pickID,
            });
            StopCoroutine(curPickCoroutine);
        }
    }
}