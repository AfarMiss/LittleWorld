using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class BuildingHaulingWork : Work
    {
        public void CreateWorkSequence()
        {
            Sequence carrySequence = new Sequence("Sow Sequence");
            Humanbeing humanbeing = tree.GetVariable("Humanbeing") as Humanbeing;
            Building building = tree.GetVariable("Building") as Building;
            //carry
            ConditionLoop checkAllRawMaterialContained = new ConditionLoop("Check All RawMaterial Contained", CheckAllRawMaterialContained);

            DynamicWalk walkLeaf = new DynamicWalk("Go To Object", humanbeing, Node.GoToLoc, GetRawMaterialPos);
            DynamicLongWorkLeaf carry = new DynamicLongWorkLeaf("Carry", humanbeing, DoHaul, GetRawMaterialPos);
            WalkLeaf moveToStorageSection = new WalkLeaf("Go To Storage Section", building.GridPos, humanbeing);
            DynamicLongWorkLeaf dropDown = new DynamicLongWorkLeaf("Drop Down", humanbeing, DoDropDown, GetBuildingPos);

            checkAllRawMaterialContained.AddChild(walkLeaf);
            checkAllRawMaterialContained.AddChild(carry);
            checkAllRawMaterialContained.AddChild(moveToStorageSection);
            checkAllRawMaterialContained.AddChild(dropDown);

            tree.AddChild(checkAllRawMaterialContained);
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
            return Node.Status.SUCCESS;

        }

        private Vector2Int GetBuildingPos()
        {
            var building = tree.GetVariable("Building");
            return (building as WorldObject).GridPos;

        }

        private Node.Status DoHaul(Vector2Int destination, Humanbeing human)
        {
            var buildingCost = tree.GetVariable("curBuildingCost") as BuildingCost;
            var worldObjects = human.Carry(buildingCost.materialCode, buildingCost.materialAmount, destination);
            tree.SetVariable("worldObjects", worldObjects);
            return Node.Status.SUCCESS;
        }

        private Vector2Int GetRawMaterialPos()
        {
            var currentCost = GetCurrentBuildingCost();
            if (currentCost != null)
            {
                return SceneObjectManager.Instance.SearchForRawMaterials(currentCost.materialCode);
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


        public BuildingHaulingWork(Building building, Humanbeing humanbeing)
        {
            tree = new BehaviourTree();
            tree.SetVariable("Humanbeing", humanbeing);
            tree.SetVariable("Building", building);
            CreateWorkSequence();
        }
    }
}
