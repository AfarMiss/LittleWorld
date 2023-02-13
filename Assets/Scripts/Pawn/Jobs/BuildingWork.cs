using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
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
            Sequence HaulRawMaterialSequence = new Sequence("HaulRawMaterialSequence Sequence");
            //HaulRawMaterialSequence

            //Building
            DynamicWalk walkLeaf = new DynamicWalk("Go To Building", humanbeing, Node.GoToLoc, GetMiningPos);
            DynamicLongWorkLeaf MiningLeaf = new DynamicLongWorkLeaf("Do Building", humanbeing, DoMining, GetMiningPos);
            BuildingSequence.AddChild(walkLeaf);
            BuildingSequence.AddChild(MiningLeaf);

            tree.AddChild(BuildingSequence);
            return tree;
        }

        public Node.Status DoMining(Vector2Int destination, Humanbeing human)
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
