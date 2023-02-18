using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class MiningSingleWork : Work
    {
        private int curMiningAmount = 0;

        protected BehaviourTree CreateWorkSequence(Ore Ore, Humanbeing humanbeing)
        {
            tree.SetVariable("Ore", Ore);
            Sequence MiningSequence = new Sequence("Sow Sequence");
            //Mining
            DynamicWalk walkLeaf = new DynamicWalk("Go To Mining", humanbeing, Node.GoToLoc, GetMiningPos);
            DynamicLongJobLeaf MiningLeaf = new DynamicLongJobLeaf("Do Mining", humanbeing, DoMining, GetMiningPos);
            MiningSequence.AddChild(walkLeaf);
            MiningSequence.AddChild(MiningLeaf);

            tree.AddChild(MiningSequence);
            return tree;
        }

        public Node.Status DoMining(Vector2Int destination, Humanbeing human)
        {
            var objects = WorldUtility.GetWorldObjectsAt(destination);
            if (objects == null)
            {
                return Node.Status.FAILURE;
            }
            var curOre = objects.ToList().Find(x => x is Ore);
            if (curOre != null)
            {
                var totalAmount = (curOre as Ore).OreInfo.MiningWorkAmount;
                float sliderValue = 0;
                if (totalAmount != 0)
                {
                    sliderValue = curMiningAmount / (float)totalAmount;
                }
                if (curMiningAmount < totalAmount)
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curMiningAmount += human.GetWorkSpeed(WorkTypeEnum.mining);
                    return Node.Status.RUNNING;
                }
                else
                {
                    EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), new WorkMessage(this, sliderValue, human, destination));
                    curMiningAmount = 0;

                    for (int i = 0; i < (curOre as Ore).ProductionAmount; i++)
                    {
                        new Thing((curOre as Ore).ProductionCode, (curOre as Ore).GridPos);
                    }
                    (curOre as WorldObject).Destroy();

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
            Ore Ore = tree.GetVariable("Ore") as Ore;
            return Ore.GridPos;
        }

        public MiningSingleWork(Ore Ore, Humanbeing humanbeing)
        {
            CreateWorkSequence(Ore, humanbeing);
        }
    }
}
