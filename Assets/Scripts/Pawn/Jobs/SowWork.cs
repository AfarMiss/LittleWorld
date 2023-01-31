using BehaviourTreeUtility;
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
        MapGridDetails[] gridsPos;
        protected void CreateWorkSequence(MapGridDetails[] gridsPos, Humanbeing humanbeing)
        {
            tree = new BehaviourTree();
            //cut
            CutAreaLoop cutArea = new CutAreaLoop(gridsPos, humanbeing, HasCutAll);
            Leaf calculateNextCut = new Leaf("Calculate Next Cut", CalculateNextCut);
            DynamicWalk walkLeaf = new DynamicWalk("Go To Cut", humanbeing, Node.GoToLoc, GetCutPos);
            DynamicLongWorkLeaf cutLeaf = new DynamicLongWorkLeaf("Do Cut", humanbeing, DoCut, GetCutPos);
            cutArea.AddChild(calculateNextCut);
            cutArea.AddChild(walkLeaf);
            cutArea.AddChild(cutLeaf);
            tree.AddChild(cutArea);
            //dig
            //sow

            this.gridsPos = gridsPos;
            tree.PrintTree();
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

        private bool HasCutAll()
        {
            var result = gridsPos.ToList().Find(x => x.HasPlant);
            return result == null;
        }

        private Vector2Int searchTargetPos(MapGridDetails[] gridsPos)
        {
            return gridsPos.ToList().Find(x => x.HasPlant).pos;
        }

        public SowWork(List<MapGridDetails> gridsPos, Humanbeing humanbeing)
        {
            CreateWorkSequence(gridsPos.ToArray(), humanbeing);
        }
    }
}
