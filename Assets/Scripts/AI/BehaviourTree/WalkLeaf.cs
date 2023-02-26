using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class WalkLeaf : Node
    {
        public Vector2Int destination;
        public Animal human;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Animal human);
        public Tick ProcessMethod;

        public WalkLeaf(string name, Vector2Int destination, Animal human)
        {
            this.destination = destination;
            this.human = human;
            this.name = name;
            this.ProcessMethod = GoToLoc;
        }

        public override Status Process()
        {
            //Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, human);
            return Status.FAILURE;
        }
    }
}
