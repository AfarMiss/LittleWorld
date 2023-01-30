using LittleWorld;
using LittleWorld.Item;
using LittleWorld.Message;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourTreeUtility
{
    public class CutLeaf : Node
    {
        public Vector2Int destination;
        public Humanbeing human;
        public bool surround = true;
        public delegate Node.Status Tick(Vector2Int destination, Humanbeing human);
        public Tick ProcessMethod;

        public CutLeaf(Vector2Int destination, Humanbeing human)
        {
            this.destination = destination;
            this.human = human;
            this.ProcessMethod = Cut;
        }

        public Node.Status Cut(Vector2Int destination, Humanbeing human)
        {
            int curCutAmount = 0;
            float sliderValue = 0;
            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.FAILURE;
            }
            var curPlant = objects.ToList().Find(x => x is Plant);
            if (curPlant != null)
            {
                var totalAmount = (curPlant as Plant).cutWorkAmount;
                if (curCutAmount < totalAmount)
                {
                    curCutAmount += human.GetWorkSpeed(WorkTypeEnum.cut);
                    sliderValue = curCutAmount / (float)totalAmount;
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(sliderValue, human));
                    return Node.Status.RUNNING;
                }
                else
                {
                    return Node.Status.SUCCESS;
                }
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

    }
}
