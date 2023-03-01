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
    public class ShootWork : Work
    {
        public Humanbeing hunter;
        public Animal target;

        public void CreateWorkSequence()
        {
            Sequence wanderSequence = new Sequence("hunter Sequence");
            CheckLeaf checkLeaf = new CheckLeaf("Check target is Alive", CheckTargetIsAlive);
            MoveLeaf walkLeaf = new MoveLeaf("Go To hunt target", GetHuntPoint(), hunter);
            CheckLeaf checkCanHuntLeaf = new CheckLeaf("Check whether can hunt", CheckWhetherCanHunt);
            DynamicLongJobLeaf shoot = new DynamicLongJobLeaf("shoot", hunter, Fire, GetHuntPoint);

            wanderSequence.AddChild(checkLeaf);
            wanderSequence.AddChild(walkLeaf);
            wanderSequence.AddChild(checkCanHuntLeaf);
            wanderSequence.AddChild(shoot);
            tree.AddChild(wanderSequence);
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

        public ShootWork(Humanbeing hunter, Animal target)
        {
            this.hunter = hunter;
            this.target = target;
            CreateWorkSequence();
        }
    }

}
