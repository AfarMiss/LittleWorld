using AI;
using LittleWorld.Extension;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class HarvestWork : Work
    {
        private int curHarvestAmount = 0;
        MapGridDetails[] gridsPos;


        protected BehaviourTree CreateWorkSequence(int plantCode, MapGridDetails[] gridsPos, Humanbeing humanbeing)
        {
            tree.SetVariable("plantCode", plantCode);
            AI.Sequence sowSequence = new AI.Sequence("Sow Sequence");
            //harvest
            LoopUnitlConditionSuccess harvestArea = new LoopUnitlConditionSuccess("Harvest Area", HarvestedAll);
            Leaf calculateNextHarvest = new Leaf("Calculate Next Harvest", CalculateNextHarvest);
            DynamicWalk walkLeaf = new DynamicWalk("Go To Harvest", humanbeing, Node.GoToLoc, GetHarvestPos);
            DynamicLongJobLeaf harvestLeaf = new DynamicLongJobLeaf("Do Harvest", humanbeing, DoHarvest, GetHarvestPos);
            harvestArea.AddChild(calculateNextHarvest);
            harvestArea.AddChild(walkLeaf);
            harvestArea.AddChild(harvestLeaf);
            sowSequence.AddChild(harvestArea);

            tree.AddChild(sowSequence);

            this.gridsPos = gridsPos;
            tree.PrintTree();

            return tree;
        }

        public Node.Status DoHarvest(Vector2Int destination, Humanbeing human)
        {
            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.FAILURE;
            }
            var curPlant = objects.ToList().Find(x => x is Plant);
            if (curPlant != null)
            {
                var totalAmount = (curPlant as Plant).PlantInfo.cutWorkAmount;
                float sliderValue = 0;
                if (totalAmount != 0)
                {
                    sliderValue = curHarvestAmount / (float)totalAmount;
                }
                if (curHarvestAmount < totalAmount)
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curHarvestAmount += human.GetWorkSpeed(WorkTypeEnum.harvest);
                    return Node.Status.RUNNING;
                }
                else
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curHarvestAmount = 0;
                    for (int i = 0; i < (curPlant as Plant).PlantYieldCount; i++)
                    {
                        new Food((curPlant as Plant).FruitCode, (curPlant as Plant).GridPos);
                    }
                    (curPlant as WorldObject).Destroy();
                    return Node.Status.SUCCESS;
                }
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private Vector2Int GetHarvestPos()
        {
            return (Vector2Int)tree.GetVariable("HarvestPoint");
        }

        private Node.Status CalculateNextHarvest()
        {
            var pos = searchTargetPos(gridsPos);
            if (pos != null)
            {
                tree.SetVariable("HarvestPoint", pos);
                return Node.Status.SUCCESS;
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private bool HarvestedAll()
        {
            int plantCode = (int)tree.GetVariable("plantCode");
            var result = gridsPos.ToList().Find(x => x.HasPlant && x.PlantCode == plantCode && x.Plant.IsRipe);
            return result == null;
        }

        private Vector2Int searchTargetPos(MapGridDetails[] gridsPos)
        {
            return gridsPos.ToList().Find(x => x.HasPlant && x.Plant.IsRipe).pos;
        }

        public HarvestWork(int plantCode, List<MapGridDetails> gridsPos, Humanbeing humanbeing)
        {
            CreateWorkSequence(plantCode, gridsPos.ToArray(), humanbeing);
        }
    }
}
