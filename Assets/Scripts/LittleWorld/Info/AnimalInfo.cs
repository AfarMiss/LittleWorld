using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class AnimalInfo : BaseInfo
    {
        public string itemType;
        public float mass;
        public int maxHealth;
        public float moveSpeed;
        public List<Sprite> itemSprites;
    }
}
