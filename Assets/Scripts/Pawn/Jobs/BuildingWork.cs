using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class BuildingWork : Work
    {
        private int curBuildingAmount = 0;

        protected BehaviourTree CreateWorkSequence(Building building, Humanbeing humanbeing)
        {
            tree.SetVariable("Building", building);
            Sequence BuildingSequence = new Sequence("Building Sequence");
            //HaulRawMaterialSequence

            //Building
            CheckLeaf canBuilding = new CheckLeaf("CanBuilding?", CheckCanBuild,
            () => { Debug.Log($"开始建造{building.ItemName}"); },
            () => { Debug.LogWarning($"资源不足，无法建造{building.ItemName}"); });
            DynamicWalk walkLeaf = new DynamicWalk("Go To Building", humanbeing, Node.GoToLoc, GetMiningPos);
            DynamicLongJobLeaf MiningLeaf = new DynamicLongJobLeaf("Do Building", humanbeing, Building, GetMiningPos);
            BuildingSequence.AddChild(canBuilding);
            BuildingSequence.AddChild(walkLeaf);
            BuildingSequence.AddChild(MiningLeaf);

            tree.AddChild(BuildingSequence);
            return tree;
        }

        private bool CheckCanBuild()
        {
            var building = tree.GetVariable("Building");
            return (building as Building).canStartBuild;
        }

        public Node.Status Building(Vector2Int destination, Humanbeing human)
        {
            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.FAILURE;
            }
            var curBuilding = objects.ToList().Find(x => x is Building);
            if (curBuilding != null)
            {
                var totalAmount = (curBuilding as Building).buildingInfo.buildingWorkAmount;
                float sliderValue = 0;
                if (totalAmount != 0)
                {
                    sliderValue = curBuildingAmount / (float)totalAmount;
                }
                if (curBuildingAmount < totalAmount)
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curBuildingAmount += human.GetWorkSpeed(WorkTypeEnum.mining);
                    return Node.Status.RUNNING;
                }
                else
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curBuildingAmount = 0;
                    (curBuilding as Building).Finish();
                    return Node.Status.SUCCESS;
                }
            }
            else
            {
                return Node.Status.FAILURE;
            }
        }

        private Vector2Int GetMiningPos()
        {
            Building Building = tree.GetVariable("Building") as Building;
            return Building.GridPos;
        }

        public BuildingWork(Building building, Humanbeing humanbeing)
        {
            CreateWorkSequence(building, humanbeing);
        }
    }
}
