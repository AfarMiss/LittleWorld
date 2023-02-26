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
            WalkLeaf walkLeaf = new WalkLeaf("Go To hunt target", GetHuntPoint(), hunter);
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
            return Vector2.Distance(hunter.GridPos, target.GridPos) <= hunter.gearTracer.curWeapon.WeaponInfo.range;
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
