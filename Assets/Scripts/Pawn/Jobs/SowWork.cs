using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class SowWork : Work
    {
        private int curCutAmount = 0;
        private int curSowAmount = 0;
        MapGridDetails[] gridsPos;


        protected BehaviourTree CreateWorkSequence(int seedCode, MapGridDetails[] gridsPos, Humanbeing humanbeing)
        {
            tree = new BehaviourTree();
            tree.SetVariable("seedCode", seedCode);
            AI.Sequence sowSequence = new AI.Sequence("Sow Sequence");
            //cut
            ConditionLoop cutArea = new ConditionLoop("cut Area", HasCutAllExceptSeedCode);
            Leaf calculateNextCut = new Leaf("Calculate Next Cut", CalculateNextCut);
            DynamicWalk walkLeaf = new DynamicWalk("Go To Cut", humanbeing, Node.GoToLoc, GetCutPos);
            DynamicLongWorkLeaf cutLeaf = new DynamicLongWorkLeaf("Do Cut", humanbeing, DoCut, GetCutPos);
            cutArea.AddChild(calculateNextCut);
            cutArea.AddChild(walkLeaf);
            cutArea.AddChild(cutLeaf);
            sowSequence.AddChild(cutArea);
            //dig
            //sow
            ConditionLoop sowArea = new ConditionLoop("sowArea", HasSowAll);
            Leaf calculateNextSow = new Leaf("Calculate Next Sow", CalculateNextSow);
            DynamicWalk walkSowLeaf = new DynamicWalk("Go To Sow", humanbeing, Node.GoToLoc, GetSowPos);
            DynamicLongWorkLeaf sowLeaf = new DynamicLongWorkLeaf("Do Sow", humanbeing, DoSow, GetSowPos);
            sowArea.AddChild(calculateNextSow);
            sowArea.AddChild(walkSowLeaf);
            sowArea.AddChild(sowLeaf);
            sowSequence.AddChild(sowArea);

            tree.AddChild(sowSequence);

            this.gridsPos = gridsPos;
            tree.PrintTree();

            return tree;
        }

        private Node.Status DoSow(Vector2Int destination, Humanbeing human)
        {
            //TODO:这里有问题，在完善种植系统的最后一部分时，应该通过XML读取各种Plant格子的种植工作量，这里先暂时使用统一的工作量代替。
            var totalAmount = Plant.sowWorkAmount;
            float sliderValue = 0;
            if (totalAmount != 0)
            {
                sliderValue = curSowAmount / (float)totalAmount;
            }
            if (curSowAmount < totalAmount)
            {
                EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(sliderValue, human, destination));
                curSowAmount += human.GetWorkSpeed(WorkTypeEnum.sow);
                return Node.Status.RUNNING;
            }
            else
            {
                EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(sliderValue, human, destination));
                curSowAmount = 0;
                var plant = new Plant("小麦", 10001, 100, destination);
                SceneItemsManager.Instance.RenderItem(plant);
                return Node.Status.SUCCESS;
            }

        }

        private Node.Status CalculateNextSow()
        {
            int seedCode = (int)tree.GetVariable("seedCode");
            var result = gridsPos.ToList().Find(x => x.PlantCode != seedCode);
            if (result != null)
            {
                tree.SetVariable("SowPoint", result);
                return Node.Status.SUCCESS;
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private bool HasSowAll()
        {
            int seedCode = (int)tree.GetVariable("seedCode");
            var result = gridsPos.ToList().Find(x => x.PlantCode != seedCode);
            return result == null;
        }

        private Vector2Int GetSowPos()
        {
            return ((MapGridDetails)tree.GetVariable("SowPoint")).pos;
        }

        public Node.Status DoCut(Vector2Int destination, Humanbeing human)
        {
            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.FAILURE;
            }
            var curPlant = objects.ToList().Find(x => x is Plant);
            if (curPlant != null)
            {
                var totalAmount = (curPlant as Plant).cutWorkAmount;
                float sliderValue = 0;
                if (totalAmount != 0)
                {
                    sliderValue = curCutAmount / (float)totalAmount;
                }
                if (curCutAmount < totalAmount)
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(sliderValue, human, destination));
                    curCutAmount += human.GetWorkSpeed(WorkTypeEnum.cut);
                    return Node.Status.RUNNING;
                }
                else
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(sliderValue, human, destination));
                    curCutAmount = 0;
                    (curPlant as WorldObject).Destroy();
                    return Node.Status.SUCCESS;
                }
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private Vector2Int GetCutPos()
        {
            return (Vector2Int)tree.GetVariable("CutPoint");
        }

        private Node.Status CalculateNextCut()
        {
            var pos = searchTargetPos(gridsPos);
            if (pos != null)
            {
                tree.SetVariable("CutPoint", pos);
                return Node.Status.SUCCESS;
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private bool HasCutAllExceptSeedCode()
        {
            int seedCode = (int)tree.GetVariable("seedCode");
            var result = gridsPos.ToList().Find(x => x.HasPlant && x.PlantCode != seedCode);
            return result == null;
        }

        private Vector2Int searchTargetPos(MapGridDetails[] gridsPos)
        {
            return gridsPos.ToList().Find(x => x.HasPlant).pos;
        }

        public SowWork(int seedCode, List<MapGridDetails> gridsPos, Humanbeing humanbeing)
        {
            CreateWorkSequence(seedCode, gridsPos.ToArray(), humanbeing);
        }
    }
}
