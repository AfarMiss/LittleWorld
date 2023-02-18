using AI;
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
            if (tree == null)
            {
                tree = new BehaviourTree();
            }
            tree = new BehaviourTree();
        }


        public Node.Status Tick()
        {
            if (tree != null)
            {
                if (tree.status == Node.Status.RUNNING)
                {
                    treeStatus = tree.Process();
                }
                return treeStatus;
            }
            else
            {
                Debug.LogError("behaviour tree has not been initialized");
                return Node.Status.FAILURE;
            }
        }

        //public virtual BehaviourTree CreateWorkSequence()
        //{
        //    return new BehaviourTree();
        //}

    }
}
