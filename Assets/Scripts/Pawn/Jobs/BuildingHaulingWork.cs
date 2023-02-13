using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
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
            DynamicWalk walkLeaf = new DynamicWalk("Go To Object", humanbeing, Node.GoToLoc, GetRawMaterialPos);
            DynamicLongWorkLeaf carry = new DynamicLongWorkLeaf("Carry", humanbeing, DoHaul, GetRawMaterialPos);
            WalkLeaf moveToStorageSection = new WalkLeaf("Go To Storage Section", building.GridPos, humanbeing);
            DynamicLongWorkLeaf dropDown = new DynamicLongWorkLeaf("Drop Down", humanbeing, DoDropDown, GetBuildingPos);
            carrySequence.AddChild(walkLeaf);
            carrySequence.AddChild(carry);
            carrySequence.AddChild(moveToStorageSection);
            carrySequence.AddChild(dropDown);
            tree.AddChild(carrySequence);
        }

        private Node.Status DoDropDown(Vector2Int destination, Humanbeing human)
        {
            human.Dropdown(tree.GetVariable("WorldObjects") as WorldObject[], destination);
            return Node.Status.SUCCESS;

        }

        private Vector2Int GetBuildingPos()
        {
            var targetSection = Current.CurMap.sectionDic.Values.ToList().Find(x => x is StorageMapSection);
            var targetGrid = targetSection.grids.Find(x => !x.isFull);
            if (targetGrid != null)
            {
                return targetGrid.pos;
            }
            else
            {
                return VectorExtension.undefinedV2Int;
            }
        }

        private Node.Status DoHaul(Vector2Int destination, Humanbeing human)
        {
            human.Carry(tree.GetVariable("WorldObjects") as WorldObject[], destination);
            return Node.Status.SUCCESS;
        }

        private Vector2Int GetRawMaterialPos()
        {
            var currentCost = GetCurrentBuildingCost();
            if (currentCost != null)
            {
                return SceneObjectManager.Instance.SearchForObject(currentCost.materialCode);
            }
            return VectorExtension.undefinedV2Int;
        }

        private BuildingCost GetCurrentBuildingCost()
        {
            var building = tree.GetVariable("Building");
            var currentRawMaterial = (building as Building).GetRawMaterialNeedYet();
            if (currentRawMaterial.Count > 0)
            {
                var curBuildingCost = new BuildingCost(
                    currentRawMaterial.ElementAt(0).Key,
                    currentRawMaterial.ElementAt(0).Value);
                tree.SetVariable("curBuildingCost", curBuildingCost);
                return curBuildingCost;
            }
            return null;
        }


        public BuildingHaulingWork(Humanbeing humanbeing, Building building)
        {
            tree = new BehaviourTree();
            tree.SetVariable("Humanbeing", humanbeing);
            tree.SetVariable("Building", building);
            CreateWorkSequence();
        }
    }
}
