using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class HaulingWork : Work
    {
        public void CreateWorkSequence()
        {
            Sequence carrySequence = new Sequence("Sow Sequence");
            Humanbeing humanbeing = tree.GetVariable("Humanbeing") as Humanbeing;
            //carry
            CheckLeaf checkLeaf = new CheckLeaf("check whether has storage zone", CheckStorage, null, OnCheckStorageFail);
            DynamicWalk walkLeaf = new DynamicWalk("Go To Object", humanbeing, Node.GoToLoc, GetOjectPos);
            DynamicLongWorkLeaf carry = new DynamicLongWorkLeaf("Carry", humanbeing, DoHaul, GetOjectPos);
            DynamicWalk moveToStorageSection = new DynamicWalk("Go To Storage Section", humanbeing, Node.GoToLoc, GetStoragePos);
            DynamicLongWorkLeaf dropDown = new DynamicLongWorkLeaf("Drop Down", humanbeing, DoDropDown, GetStoragePos);
            carrySequence.AddChild(checkLeaf);
            carrySequence.AddChild(walkLeaf);
            carrySequence.AddChild(carry);
            carrySequence.AddChild(moveToStorageSection);
            carrySequence.AddChild(dropDown);
            tree.AddChild(carrySequence);
        }

        private void OnCheckStorageFail()
        {
            Debug.LogWarning("不存在符合条件的存储区");
        }

        private bool CheckStorage()
        {
            var targetSection = Current.CurMap.sectionDic.Values.ToList().Find(x => x is StorageMapSection);
            return targetSection != null;
        }

        private Node.Status DoDropDown(Vector2Int destination, Humanbeing human)
        {
            human.Dropdown(tree.GetVariable("WorldObjects") as WorldObject[], destination);
            return Node.Status.SUCCESS;

        }

        private Vector2Int GetStoragePos()
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

        private Vector2Int GetOjectPos()
        {
            var targets = tree.GetVariable("WorldObjects") as WorldObject[];
            return targets[0].GridPos;
        }

        public HaulingWork(WorldObject[] wo, Humanbeing humanbeing)
        {
            tree = new BehaviourTree();
            tree.SetVariable("WorldObjects", wo);
            tree.SetVariable("Humanbeing", humanbeing);
            CreateWorkSequence();
        }
    }
}
