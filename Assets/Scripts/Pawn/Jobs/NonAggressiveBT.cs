using LittleWorld.Item;
using LittleWorld;
using LittleWorld.Jobs;
using UnityEngine;
using static AI.MoveLeaf;
using static LittleWorld.Item.Bullet;

namespace AI
{
    public class NonAggressiveBT : WorkBT
    {
        public Vector2Int curWanderPos;
        private Vector2Int? damageSource;
        public Animal animal;
        public bool isHurt = false;
        private void CreateWorkSequence()
        {
            //wander
            Sequence wanderSequence = new Sequence("wander Sequence");
            for (int i = 0; i < 5; i++)
            {
                var randomPoint = (Random.insideUnitCircle * 5).ToCell();
                curWanderPos += randomPoint;
                curWanderPos.x = Mathf.Clamp(curWanderPos.x, 0, Current.CurMap.MapSize.x);
                curWanderPos.y = Mathf.Clamp(curWanderPos.y, 0, Current.CurMap.MapSize.y);
                if (Current.CurMap.GetGrid(curWanderPos).isLand)
                {
                    MoveLeaf walkLeaf = new MoveLeaf("Go To Object", curWanderPos, animal, MoveType.wander);
                    wanderSequence.AddChild(walkLeaf);
                }
                if (Random.Range(0, 1f) < 0.5f)
                {
                    wanderSequence.AddChild(new ThinkLeaf(animal));
                }
            }
            //flee
            Sequence fleeSequence = new Sequence("flee Sequence");
            CheckLeaf beHurt = new CheckLeaf("be hurt?", BeHurt);
            FleeLeaf fleeLeaf = new FleeLeaf(animal, damageSource.Value);
            fleeSequence.AddChild(beHurt);
            fleeSequence.AddChild(fleeLeaf);

            Selector actionSelector = new Selector();
            actionSelector.AddChild(fleeSequence);
            actionSelector.AddChild(wanderSequence);
            tree.AddChild(actionSelector);
        }

        private bool BeHurt()
        {
            if (isHurt)
            {
                isHurt = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public NonAggressiveBT(Animal animal)
        {
            this.curWanderPos = animal.GridPos;
            this.animal = animal;
            CreateWorkSequence();
            EventCenter.Instance.Register<DamageInfo>(EventName.LIVING_BE_HURT, OnBeHurt);
        }

        private void OnBeHurt(DamageInfo arg0)
        {
            if (arg0.animal == animal)
            {
                damageSource = arg0.humanbeing.GridPos;
                isHurt = true;
            }
        }
    }
}
