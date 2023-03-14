using LittleWorld.Item;
using LittleWorld.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AI
{
    internal class EquipWork : WorkBT
    {
        public Weapon weapon;
        public Humanbeing human;
        public EquipWork(Weapon weapon, Humanbeing human)
        {
            this.weapon = weapon;
            this.human = human;
            CreateWorkSequence();
        }

        private void CreateWorkSequence()
        {
            Sequence carrySequence = new Sequence("equip Sequence");
            //carry
            MoveLeaf walkLeaf = new MoveLeaf("Go To Object", weapon.GridPos, human);
            DynamicLongJobLeaf equip = new DynamicLongJobLeaf("Equip", human, DoEquip, GetWeaponPos);
            carrySequence.AddChild(walkLeaf);
            carrySequence.AddChild(equip);
            tree.AddChild(carrySequence);
        }

        private Node.Status DoEquip(Vector2Int destination, Humanbeing human)
        {
            human.AddEquip(weapon, destination);
            return Node.Status.Success;
        }

        private Vector2Int GetWeaponPos()
        {
            return weapon.GridPos;
        }
    }
}
