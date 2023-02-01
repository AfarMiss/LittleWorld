using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public abstract class Work
    {
        public static int WorkIDSeed = 0;

        protected BehaviourTree tree;
        public int workID;
        private Node.Status treeStatus = Node.Status.RUNNING;

        public Work()
        {
            workID = WorkIDSeed++;
        }


        public Node.Status Tick()
        {
            if (tree != null)
            {
                if (tree.status != Node.Status.SUCCESS)
                {
                    treeStatus = tree.Process();
                    return treeStatus;
                }
                else
                {
                    return tree.status;
                }
            }
            else
            {
                Debug.LogError("behaviour tree has not been initialized");
                return Node.Status.FAILURE;
            }
        }

    }
}
