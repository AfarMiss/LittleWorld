using LittleWorld.Item;
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
        }

        public GearTracer(Humanbeing humanbeing)
        {
            this.Humanbeing = humanbeing;
        }
    }
}
