using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class SeedInfo : IObjectRender
    {
        public int itemCode;
        public string itemName;
        public float mass;
        public int sowWorkAmount;
        public int maxHealth;
        public int plantItem;
        public float nutrition;

        public Sprite GetSprite(int itemCode, string importerPath)
        {
        }
    }
}
