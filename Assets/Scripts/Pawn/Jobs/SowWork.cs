using BehaviourTreeUtility;
using LittleWorld.Item;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class SowWork : Work
    {
        protected void CreateWorkSequence(Vector2Int[] gridsPos, Humanbeing humanbeing)
        {
            workBehaviourTree = new BehaviourTree();
            //cut
            CutArea cutArea = new CutArea(gridsPos, humanbeing);
            foreach (var item in gridsPos)
            {
                cutArea.AddChild(AddCutAt(humanbeing, item));
            }
            workBehaviourTree.AddChild(cutArea);
            //dig
            //sow
        }

        private CutAt AddCutAt(Humanbeing humanbeing, Vector2Int targetPos)
        {
            WalkLeaf walkLeaf = new WalkLeaf(targetPos, humanbeing);
            CutLeaf cutLeaf = new CutLeaf(targetPos, humanbeing);
            CutAt cutAt = new CutAt(targetPos, humanbeing);
            cutAt.AddChild(walkLeaf);
            cutAt.AddChild(cutLeaf);
            return cutAt;
        }

        public SowWork(List<Vector2Int> gridsPos, Humanbeing humanbeing)
        {

        }
    }
}
