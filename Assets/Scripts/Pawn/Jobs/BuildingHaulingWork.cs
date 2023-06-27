using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class BuildingHaulingWork : WorkBT, IToil
    {
        public bool isDone => throw new NotImplementedException();

        public string toilName => throw new NotImplementedException();

        public bool canStart => throw new NotImplementedException();

        public BehaviourTree CreateWorkSequence()
        {
            Humanbeing humanbeing = tree.GetVariable("Humanbeing") as Humanbeing;
            Building building = tree.GetVariable("Building") as Building;
            //carry
            LoopUnitlConditionSuccess checkAllRawMaterialContained = new LoopUnitlConditionSuccess("Check All RawMaterial Contained", CheckAllRawMaterialContained);

            DynamicWalk walkLeaf = new DynamicWalk("Go To Object", humanbeing, Node.GoToLoc, GetRawMaterialPos);
            DynamicLongJobLeaf carry = new DynamicLongJobLeaf("Carry", humanbeing, DoHaul, GetRawMaterialPos);
            MoveLeaf moveToStorageSection = new MoveLeaf("Go To Storage Section", building.GridPos, humanbeing);
            DynamicLongJobLeaf dropDown = new DynamicLongJobLeaf("Drop Down", humanbeing, DoDropDown, GetBuildingPos);

            checkAllRawMaterialContained.AddChild(walkLeaf);
            checkAllRawMaterialContained.AddChild(carry);
            checkAllRawMaterialContained.AddChild(moveToStorageSection);
            checkAllRawMaterialContained.AddChild(dropDown);

            tree.AddChild(checkAllRawMaterialContained);
            return tree;
        }

        private bool CheckAllRawMaterialContained()
        {
            Building building = tree.GetVariable("Building") as Building;
            return building.GetRawMaterialNeedYet().Count <= 0;
        }

        private Node.Status DoDropDown(Vector2Int destination, Humanbeing human)
        {
            Building building = tree.GetVariable("Building") as Building;
            building.AddBuildingRawMaterials(tree.GetVariable("worldObjects") as WorldObject[]);
            return Node.Status.Success;

        }

        private Vector2Int GetBuildingPos()
        {
            var building = tree.GetVariable("Building");
            return (building as WorldObject).GridPos;

        }

        private Node.Status DoHaul(Vector2Int destination, Humanbeing human)
        {
            var buildingCost = tree.GetVariable("curBuildingCost") as BuildingCost;
            //var worldObjects = human.Carry(buildingCost.materialCode, buildingCost.materialAmount, destination);
            //tree.SetVariable("worldObjects", worldObjects);
            return Node.Status.Success;
        }

        private Vector2Int GetRawMaterialPos()
        {
            var currentCost = GetCurrentBuildingCost();
            if (currentCost != null)
            {
                //return SceneObjectManager.Instance.SearchForRawMaterials(currentCost.materialCode);
            }
            return VectorExtension.undefinedV2Int;
        }

        private BuildingCost GetCurrentBuildingCost()
        {
            var building = tree.GetVariable("Building");
            var currentRawMaterial = (building as Building).GetRawMaterialNeedYet();
            if (currentRawMaterial.Count > 0)
            {
                BuildingCost curBuildingCost = new BuildingCost(
                    currentRawMaterial.ElementAt(0).Key,
                    currentRawMaterial.ElementAt(0).Value);
                tree.SetVariable("curBuildingCost", curBuildingCost);
                return curBuildingCost;
            }
            return null;
        }

        public void ToilTick()
        {
            throw new NotImplementedException();
        }

        public void ToilStart()
        {
            throw new NotImplementedException();
        }

        public void ToilCancel()
        {
            throw new NotImplementedException();
        }

        public void ToilOnDone()
        {
            throw new NotImplementedException();
        }

        public BuildingHaulingWork(Building building, Humanbeing humanbeing)
        {
            tree.SetVariable("Humanbeing", humanbeing);
            tree.SetVariable("Building", building);
            CreateWorkSequence();
        }
    }
}
