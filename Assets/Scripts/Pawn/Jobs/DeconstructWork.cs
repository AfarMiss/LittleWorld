using AI;
using LittleWorld.Item;
using LittleWorld.Message;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class DeconstructWork : WorkBT
    {
        public BehaviourTree CreateWorkSequence()
        {
            Humanbeing humanbeing = tree.GetVariable("Humanbeing") as Humanbeing;
            Building building = tree.GetVariable("Building") as Building;
            //carry

            MoveLeaf moveLeaf = new MoveLeaf("Go To Building", building.GridPos, humanbeing);
            DynamicLongJobLeaf harvestLeaf = new DynamicLongJobLeaf("Do Deconstruct", humanbeing, Deconstruct, GetBuildingPos);

            tree.AddChild(moveLeaf);
            tree.AddChild(harvestLeaf);
            return tree;
        }

        private Vector2Int GetBuildingPos()
        {
            var building = tree.GetVariable("Building");
            return (building as WorldObject).GridPos;

        }

        private Node.Status Deconstruct(Vector2Int destination, Humanbeing human)
        {
            var building = tree.GetVariable("Building") as Building;
            var curBuildingAmount = 0;

            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.Failure;
            }

            var totalAmount = (building as Building).buildingInfo.deconstructWorkAmount;
            float sliderValue = 0;
            if (totalAmount != 0)
            {
                sliderValue = curBuildingAmount / (float)totalAmount;
            }
            if (curBuildingAmount < totalAmount)
            {
                EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(this, sliderValue, human, destination));
                curBuildingAmount += human.GetWorkSpeed(WorkTypeEnum.deconstruct);
                return Node.Status.Running;
            }
            else
            {
                EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(this, sliderValue, human, destination));
                curBuildingAmount = 0;
                var cost = (building as Building).buildingInfo.BuildingCost;

                //拆除产出，大概是要通过反射去做了
                foreach (var item in cost)
                {
                    //new WorldObject(item, building.GridPos, building.mapBelongTo);
                }

                (building as WorldObject).Destroy();
                return Node.Status.Success;
            }
        }


        public DeconstructWork(Building building, Humanbeing humanbeing)
        {
            tree.SetVariable("Humanbeing", humanbeing);
            tree.SetVariable("Building", building);
            CreateWorkSequence();
        }
    }
}
