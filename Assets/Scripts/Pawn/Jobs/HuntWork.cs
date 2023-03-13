using AI;
using LittleWorld.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class HuntWork : WorkBT
    {
        public Humanbeing hunter;
        public Animal target;

        public void CreateWorkSequence()
        {
            LoopUnitlConditionSuccess huntLoop = new LoopUnitlConditionSuccess("Hunt Loop", HuntLoop);

            Sequence singleHuntSequence = new Sequence("hunter Sequence");
            CheckLeaf checkLeaf = new CheckLeaf("Check target is Alive", CheckTargetIsAlive);

            LoopUntilSuccess moveLoop = new LoopUntilSuccess("Move Loop");
            MoveUntilSuccessLeaf walkLeaf = new MoveUntilSuccessLeaf("Go To hunt target", hunter, GetHuntPoint);
            moveLoop.AddChild(walkLeaf);

            CheckLeaf checkCanHuntLeaf = new CheckLeaf("Check whether can hunt", CheckWhetherCanHunt);
            DynamicLongJobLeaf shoot = new DynamicLongJobLeaf("shoot", hunter, Fire, GetHuntPoint);

            singleHuntSequence.AddChild(checkLeaf);
            singleHuntSequence.AddChild(moveLoop);
            singleHuntSequence.AddChild(checkCanHuntLeaf);
            singleHuntSequence.AddChild(shoot);

            huntLoop.AddChild(singleHuntSequence);

            tree.AddChild(huntLoop);
        }

        private bool MoveLoop()
        {
            throw new NotImplementedException();
        }

        private bool HuntLoop()
        {
            return target.IsDead;
        }

        private bool CheckWhetherCanHunt()
        {
            var canHunt = Vector2.Distance(hunter.GridPos, target.GridPos) <= hunter.gearTracer.curWeapon.WeaponInfo.range;
            if (canHunt)
            {
                Debug.LogWarning("可以狩猎!");
            }
            else
            {
                Debug.LogWarning("不可以狩猎!超出射程");
            }
            return canHunt;
        }

        private Node.Status Fire(Vector2Int destination, Humanbeing human)
        {
            human.FireAt(target);
            return Node.Status.SUCCESS;
        }

        private Vector2Int GetHuntPoint()
        {
            return (UnityEngine.Random.insideUnitCircle * hunter.gearTracer.curWeapon.WeaponInfo.range).ToCell() + target.GridPos;
        }

        private bool CheckTargetIsAlive()
        {
            return !target.IsDead;
        }

        public HuntWork(Humanbeing hunter, Animal target)
        {
            this.hunter = hunter;
            this.target = target;
            CreateWorkSequence();
        }

        public override void OnAbort()
        {
            base.OnAbort();
            this.hunter.StopFire();
        }
    }

}
