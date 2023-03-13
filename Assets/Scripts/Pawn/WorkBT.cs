using AI;
using LittleWorld.Message;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Jobs
{
    /// <summary>
    /// 封装工作行为树的类
    /// </summary>
    public abstract class WorkBT
    {

        public bool isSuspended = false;
        public bool isAborted = false;
        public static int WorkIDSeed = 0;

        protected BehaviourTree tree;
        public int workID;
        private Node.Status treeStatus = Node.Status.RUNNING;

        public void OnSuspend()
        {
            isSuspended = true;
        }

        public virtual void OnAbort()
        {
            isAborted = true;
            EventCenter.Instance.Trigger(EventEnum.FORCE_ABORT.ToString(), new WorkAbortMessage(this));
        }

        public void OnResume()
        {
            isSuspended = false;
        }


        public WorkBT()
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
            if (isAborted)
            {
                return Node.Status.FAILURE;
            }
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

        protected virtual void OnDestroy()
        {

        }

    }
}
