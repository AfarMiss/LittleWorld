using LittleWorld.Item;
using LittleWorld;
using UnityEngine;
using static AI.MoveLeaf;

namespace AI
{
    public class FleeLeaf : Node
    {
        private Animal animal;
        public Vector2Int curWanderPos;
        private Vector2Int? fleeFrom;
        private Vector2Int? fleeTo;
        private string fleeFromName;

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

        public FleeLeaf(Animal animal, string fleeFromName)
        {
            this.curWanderPos = animal.GridPos;
            this.animal = animal;
            fleeTo = SelectFleeDestination();
            this.fleeFromName = fleeFromName;
        }

        /// <summary>
        /// 选择逃离点
        /// </summary>
        /// <returns></returns>
        private Vector2Int? SelectFleeDestination()
        {
            var targetPos = animal.GridPos;
            this.fleeFrom = (Vector2Int)Blackboard.GetVariable(fleeFromName);
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
                    targetPos = animal.GridPos;
                    continue;
                }
            }
            return null;
        }
    }
}
