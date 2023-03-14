using LittleWorld.Item;
using LittleWorld;
using LittleWorld.Jobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;
using NodeCanvas.Tasks.Actions;

namespace AI
{
    public class FleeLeaf : Node
    {
        private Animal animal;
        public Vector2Int curWanderPos;
        private Vector2Int fleeFrom;
        private Vector2Int? fleeTo;

        public override Status Process()
        {
            if (fleeTo != null)
            {
                return Node.GoToLoc(fleeTo.Value, animal, MoveType.dash);
            }
            else
            {
                return Status.Failure;
            }
        }

        public FleeLeaf(Animal animal, Vector2Int fleeFrom)
        {
            this.curWanderPos = animal.GridPos;
            this.animal = animal;
            this.fleeFrom = fleeFrom;
            fleeTo = SelectFleeDestination(fleeFrom, animal.GridPos);
        }

        private Vector2Int? SelectFleeDestination(Vector2Int fleeFrom, Vector2Int curPos)
        {
            var targetPos = curPos;
            for (int i = 0; i < 50; i++)
            {
                var randomPoint = (Random.insideUnitCircle * 5).ToCell();
                targetPos += randomPoint;
                targetPos.x = Mathf.Clamp(targetPos.x, 0, Current.CurMap.MapSize.x);
                targetPos.y = Mathf.Clamp(targetPos.y, 0, Current.CurMap.MapSize.y);
                if (Current.CurMap.GetGrid(targetPos).isLand)
                {
                    return targetPos;
                }
                else
                {
                    targetPos = curPos;
                    continue;
                }
            }
            return null;
        }
    }
}
