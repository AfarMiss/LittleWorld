﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class SeedInfo : BaseInfo, IObjectRender
    {
        public float mass;
        public int sowWorkAmount;
        public int maxHealth;
        public int plantItem;
        public float nutrition;

        public Sprite GetSprite(int itemCode, string importerPath)
        {
            return null;
        }
    }
}
