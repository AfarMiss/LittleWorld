using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class CutSingleWork : Work
    {
        private int curCutAmount = 0;

        protected BehaviourTree CreateWorkSequence(Plant plant, Humanbeing humanbeing)
        {
            tree.SetVariable("plant", plant);
            Sequence cutSequence = new Sequence("Sow Sequence");
            //cut
            DynamicWalk walkLeaf = new DynamicWalk("Go To Cut", humanbeing, Node.GoToLoc, GetCutPos);
            DynamicLongJobLeaf cutLeaf = new DynamicLongJobLeaf("Do Cut", humanbeing, DoCut, GetCutPos);
            cutSequence.AddChild(walkLeaf);
            cutSequence.AddChild(cutLeaf);

            tree.AddChild(cutSequence);
            return tree;
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
                var totalAmount = (curPlant as Plant).PlantInfo.cutWorkAmount;
                float sliderValue = 0;
                if (totalAmount != 0)
                {
                    sliderValue = curCutAmount / (float)totalAmount;
                }
                if (curCutAmount < totalAmount)
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curCutAmount += human.GetWorkSpeed(WorkTypeEnum.cut);
                    return Node.Status.RUNNING;
                }
                else
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curCutAmount = 0;
                    //产出
                    if ((curPlant as Plant).IsRipe)
                    {
                        for (int i = 0; i < (curPlant as Plant).PlantYieldCount; i++)
                        {
                            new RawFood((curPlant as Plant).FruitCode, (curPlant as Plant).GridPos);
                        }
                    }

                    for (int i = 0; i < (curPlant as Plant).WoodCount; i++)
                    {
                        new Thing(ObjectCode.wood.GetHashCode(), (curPlant as Plant).GridPos);
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

        private Vector2Int GetCutPos()
        {
            Plant plant = tree.GetVariable("plant") as Plant;
            return plant.GridPos;
        }

        public CutSingleWork(Plant plant, Humanbeing humanbeing)
        {
            CreateWorkSequence(plant, humanbeing);
        }
    }
}
