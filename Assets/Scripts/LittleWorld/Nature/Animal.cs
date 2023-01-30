using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Animal : WorldObject
    {
        public float moveSpeed;
        public Animal(Vector3Int gridPos) : base(gridPos)
        {
        }
    }
}

