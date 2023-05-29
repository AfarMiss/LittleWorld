using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class GearTracer
    {
        public Weapon curWeapon;
        public IEnumerable<WorldObject> worldObjects;
        public Animal Humanbeing;

        public void AddEquip(Weapon weapon)
        {
            curWeapon = weapon;
            weapon.OnEquip(Humanbeing);
            //更新显示
            this.EventTrigger(EventName.UPDATE_WEAPON, weapon);
        }

        internal void Attack(WorldObject animal)
        {
            curWeapon.Attack(animal);
        }

        public void CancelAttack()
        {
            curWeapon.CancelAttack();
        }

        public GearTracer(Animal humanbeing)
        {
            this.Humanbeing = humanbeing;
        }
    }
}
