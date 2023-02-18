using AI;
using LittleWorld.Item;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class WanderWork : Work
    {
        public Vector2Int curWanderPos;
        public Animal humanbeing;
        private void CreateWorkSequence()
        {
            Sequence wanderSequence = new Sequence("wander Sequence");
            for (int i = 0; i < 5; i++)
            {
                var randomPoint = (Random.insideUnitCircle * 5).ToCell();
                curWanderPos += randomPoint;
                curWanderPos.x = Mathf.Clamp(curWanderPos.x, 0, Current.CurMap.MapSize.x);
                curWanderPos.y = Mathf.Clamp(curWanderPos.y, 0, Current.CurMap.MapSize.y);
                if (Current.CurMap.GetGrid(curWanderPos).isLand)
                {
                    WalkLeaf walkLeaf = new WalkLeaf("Go To Object", curWanderPos, humanbeing);
                    wanderSequence.AddChild(walkLeaf);
                }
            }
            tree.AddChild(wanderSequence);
        }

        public WanderWork(Animal animal)
        {
            this.curWanderPos = animal.GridPos;
            this.humanbeing = animal;
            CreateWorkSequence();
        }
    }
}
