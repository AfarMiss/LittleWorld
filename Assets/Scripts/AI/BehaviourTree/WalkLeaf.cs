using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTreeUtility
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

        public WalkLeaf(Vector2Int destination, Humanbeing human)
        {
            this.destination = destination;
            this.human = human;
            this.ProcessMethod = GoToLoc;
        }

        public override Status Process()
        {
            Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, human);
            return Status.FAILURE;
        }


        public Node.Status GoToLoc(Vector2Int destination, Humanbeing human)
        {
            if (human.motion == Humanbeing.MotionStatus.Idle)
            {
                human.GoToLoc(destination);
                human.motion = Humanbeing.MotionStatus.Running;
            }
            if (human.GridPos == destination)
            {
                human.motion = Humanbeing.MotionStatus.Idle;
                return Node.Status.SUCCESS;
            }
            return Node.Status.RUNNING;
        }
    }
}
