﻿using LittleWorld.Item;
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
        public Humanbeing Humanbeing;

        public void AddEquip(Weapon weapon)
        {
            curWeapon = weapon;
            weapon.OnEquip(Humanbeing);
            //更新显示
            EventCenter.Instance.Trigger(EventName.UPDATE_WEAPON, weapon);
        }

        internal void TryFireAt(Animal animal)
        {
            curWeapon.Attack(animal);
        }

        public GearTracer(Humanbeing humanbeing)
        {
            this.Humanbeing = humanbeing;
        }
    }
}
