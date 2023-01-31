using BehaviourTreeUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public abstract class Work
    {
        public static int WorkIDSeed = 0;

        protected BehaviourTree tree;
        Node.Status treeStatus = Node.Status.RUNNING;


        public Node.Status Tick()
        {
            if (tree != null)
            {
                if (tree.status != Node.Status.SUCCESS)
                {
                    treeStatus = tree.Process();
                }
                return tree.status;
            }
            return Node.Status.FAILURE;
        }

    }
}
