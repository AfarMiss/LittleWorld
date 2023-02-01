using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class WalkLeaf : Node
    {
        public Vector2Int destination;
        public Humanbeing human;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Humanbeing human);
        public Tick ProcessMethod;

        public WalkLeaf(string name, Vector2Int destination, Humanbeing human)
        {
            this.destination = destination;
            this.human = human;
            this.name = name;
            this.ProcessMethod = GoToLoc;
        }

        public WalkLeaf(string name, Vector2Int destination, Humanbeing human, Tick ProcessMethod)
        {
            this.destination = destination;
            this.human = human;
            this.name = name;
            this.ProcessMethod = ProcessMethod;
        }

        public override Status Process()
        {
            Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, human);
            return Status.FAILURE;
        }
    }
}
