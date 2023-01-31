using LittleWorld;
using LittleWorld.Item;
using LittleWorld.Message;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourTreeUtility
{
    public class DynamicLongWorkLeaf : Node
    {
        public Vector2Int destination;
        public Humanbeing human;
        public bool surround = true;
        public delegate Node.Status Tick(Vector2Int destination, Humanbeing human);
        public Tick ProcessMethod;
        public delegate Vector2Int GetPos();
        public GetPos getPos;

        public DynamicLongWorkLeaf(string name, Humanbeing human, Tick tick, GetPos getPos) : base(name)
        {
            this.human = human;
            this.ProcessMethod = tick;
            this.getPos = getPos;
        }

        public override Status Process()
        {
            if (getPos != null)
            {
                destination = getPos();
            }
            Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, human);
            return Status.FAILURE;
        }

    }
}
