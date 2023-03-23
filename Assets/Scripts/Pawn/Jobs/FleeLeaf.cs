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
        /// <summary>
        /// 可以重新选择逃离点
        /// </summary>
        private bool fleeResting = true;

        public override Status Process()
        {
            if (fleeResting)
            {
                fleeTo = SelectFleeDestination();
                fleeResting = false;
            }
            if (fleeTo != null)
            {
                var fleeProcess = Node.GoToLoc(fleeTo.Value, animal, MoveType.dash);
                switch (fleeProcess)
                {
                    case Status.Success:
                        parent.Priority = -1;
                        fleeResting = true;
                        return Status.Running;
                    case Status.Running:
                        return Status.Running;
                    default:
                        return Status.Failure;
                }
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
            this.fleeFromName = fleeFromName;
        }

        /// <summary>
        /// 选择逃离点
        /// </summary>
        /// <returns></returns>
        private Vector2Int? SelectFleeDestination()
        {
            Debug.LogWarning("选择逃离点！");
            var targetPos = animal.GridPos;
            this.fleeFrom = (Vector2Int)Blackboard.GetVariable(fleeFromName);
            for (int i = 0; i < 50; i++)
            {
                var randomPoint = (Random.insideUnitCircle * 10).ToCell();
                targetPos += randomPoint;
                targetPos.x = Mathf.Clamp(targetPos.x, 0, Current.CurMap.MapSize.x);
                targetPos.y = Mathf.Clamp(targetPos.y, 0, Current.CurMap.MapSize.y);
                if (Current.CurMap.GetGrid(targetPos).isLand)
                {
                    Debug.LogWarning("逃离点->" + targetPos);
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
