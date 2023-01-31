using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class HumanPointWork : Node
    {
        public Vector2Int destination;
        public Humanbeing human;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Humanbeing human);
        public Tick ProcessMethod;

        public HumanPointWork(string name, Vector2Int destination, Humanbeing human, Tick ProcessMethod)
        {
            this.destination = destination;
            this.human = human;
            this.name = name;
            this.ProcessMethod = GoToLoc;
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
