using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

namespace LittleWorld.Jobs
{
    public class CarryWork : Work
    {
        public void CreateWorkSequence()
        {
            Sequence carrySequence = new Sequence("Sow Sequence");
            Humanbeing humanbeing = tree.GetVariable("Humanbeing") as Humanbeing;
            //carry
            DynamicWalk walkLeaf = new DynamicWalk("Go To Object", humanbeing, Node.GoToLoc, GetOjectPos);
            DynamicLongWorkLeaf carry = new DynamicLongWorkLeaf("Carry", humanbeing, DoCarry, GetOjectPos2);
            DynamicWalk moveToStorageSection = new DynamicWalk("Go To Storage Section", humanbeing, Node.GoToLoc, GetStoragePos);
            DynamicLongWorkLeaf dropDown = new DynamicLongWorkLeaf("Drop Down", humanbeing, DoDropDown, GetStoragePos);
            carrySequence.AddChild(walkLeaf);
            carrySequence.AddChild(carry);
            carrySequence.AddChild(moveToStorageSection);
            carrySequence.AddChild(dropDown);
            tree.AddChild(carrySequence);
        }

        private Node.Status DoDropDown(Vector2Int destination, Humanbeing human)
        {
            human.Dropdown(tree.GetVariable("WorldObject") as WorldObject);
            return Node.Status.SUCCESS;

        }

        private Vector2Int GetStoragePos()
        {
            foreach (var item in Current.CurMap.sectionDic)
            {
                if (item.Value is StorageMapSection)
                {
                    return item.Value.grids[0].pos;
                }
            }
            return default;
        }

        private Node.Status DoCarry(Vector2Int destination, Humanbeing human)
        {
            human.Carry(tree.GetVariable("WorldObject") as WorldObject);
            return Node.Status.SUCCESS;
        }

        private Vector2Int GetOjectPos()
        {
            return (tree.GetVariable("WorldObject") as WorldObject).GridPos;
        }

        private Vector2Int GetOjectPos2()
        {
            return (tree.GetVariable("WorldObject") as WorldObject).GridPos;
        }

        public CarryWork(WorldObject wo, Humanbeing humanbeing)
        {
            tree = new BehaviourTree();
            tree.SetVariable("WorldObject", wo);
            tree.SetVariable("Humanbeing", humanbeing);
            CreateWorkSequence();
        }
    }
}
