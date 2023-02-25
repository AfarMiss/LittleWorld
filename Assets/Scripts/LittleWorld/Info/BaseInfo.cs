﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class BaseInfo
    {
        public int itemCode;
        public string itemName;
        public bool canPile;
        public int maxPileCount;
        public bool isBlock;
        public List<Sprite> itemSprites;

        public Sprite defaultSprite => itemSprites[0];
    }
}