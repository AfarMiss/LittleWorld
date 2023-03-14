using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class MoveLeaf : Node
    {
        public Vector2Int destination;
        public Animal animal;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Animal animal, MoveType moveType);
        public Tick ProcessMethod;
        private MoveType moveType;

        public MoveLeaf(string name, Vector2Int destination, Animal animal, MoveType moveType = MoveType.walk)
        {
            this.destination = destination;
            this.animal = animal;
            this.name = name;
            this.ProcessMethod = GoToLoc;
            this.moveType = moveType;
        }

        public override Status Process()
        {
            //Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, animal, moveType);
            return Status.Failure;
        }

        public enum MoveType
        {
            wander,
            walk,
            dash,
            idle,
            order
        }
    }
}
