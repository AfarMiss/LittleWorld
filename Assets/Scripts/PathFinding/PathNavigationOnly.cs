using LittleWorld;
using LittleWorld.Extension;
using LittleWorld.Object;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PathNavigationOnly : MonoBehaviour
{
    public int lastStampFrameCount = -1;
    private Queue<Vector2Int> curPath;
    public Vector2Int curDestination;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    private Vector2Int curTarget;
    [SerializeField] private LineRenderer lineRenderer;

    private float walkLeftCost = 0;
    private float realTotalCost = 0;
    private float walkBaseTotalCost = 100;

    private bool curTargetIsReached = true;
    public bool atDestination = true;
    public Vector2 renderPos => transform.position;
    public Vector2 curRenderPos;
    private Vector3 dir;

    public bool isMoving => curPath.Safe().Any() || curTarget != null;
    private bool isMovingDiagonally => isMoving && curTarget.InStraightLine(human.GridPos);
    private float diagonalRate = 1.41f;

    /// <summary>
    /// 代表的itemInstanceID
    /// </summary>
    public int humanID;
    public Humanbeing human => SceneItemsManager.Instance.GetWorldObjectById(humanID) as Humanbeing;

    public void Initialize(int instanceID)
    {
        this.humanID = instanceID;
    }
    private void Start()
    {
        curPath = new Queue<Vector2Int>();
    }

    public void ResetPath()
    {
        curTargetIsReached = true;
        atDestination = true;
        curPath?.Clear();
        curTarget = default;
        curDestination = default;
        curRenderPos = default;
    }

    private void DrawLine(Queue<Vector2Int> path)
    {
        if (path == null) return;
        var pathArray = path.ToArray();
        lineRenderer.positionCount = pathArray.Length + 2;
        lineRenderer.SetPosition(0, this.transform.position + imageOffset);
        if (curTarget != null)
        {
            lineRenderer.SetPosition(1, new Vector3(curTarget.x, curTarget.y, 0) + imageOffset);
            for (int i = 0; i < path.Count; i++)
            {
                lineRenderer.SetPosition(i + 2, new Vector3(pathArray[i].x, pathArray[i].y, 0) + imageOffset);
            }
        }
        else
        {
            for (int i = 0; i < path.Count; i++)
            {
                lineRenderer.SetPosition(i + 1, new Vector3(pathArray[i].x, pathArray[i].y, 0) + imageOffset);
            }
        }

        lineRenderer.startColor = new Color(1, 1, 1, 0.3f);
        lineRenderer.endColor = new Color(1, 1, 1, 0.3f);
    }

    private void Tick()
    {
        MoveInPath();
    }

    private void MoveInPath()
    {
        lineRenderer.enabled = true;
        if (!atDestination)
        {
            if (curTargetIsReached)
            {
                if (curPath.Count > 0)
                {
                    curTarget = curPath.Dequeue();
                    dir = curTarget - renderPos;
                    realTotalCost = Vector2.Distance(renderPos, curTarget) * walkBaseTotalCost;
                    walkLeftCost += Vector2.Distance(renderPos, curTarget) * walkBaseTotalCost;
                    curRenderPos = renderPos;
                    curTargetIsReached = false;
                    return;
                }
                else
                {
                    atDestination = true;
                    lineRenderer.enabled = false;
                    //完成到达指定目的地后的工作
                    EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), humanID);
                    Debug.Log($"Reached {curTarget}");
                }
            }
            else
            {
                MoveTo(curTarget);
            }
        }
    }

    private void MoveTo(Vector2Int target)
    {
        SingleStep(target);
    }

    private void SingleStep(Vector2Int target)
    {
        var worldPos = GlobalPathManager.Instance.CellToWorld(new Vector3Int(target.x, target.y, 0));
        var human = SceneItemsManager.Instance.GetWorldObjectById(humanID);
        //Debug.Log("human.gridPos:" + human.GridPos);

        if (walkLeftCost > 0)
        {
            var speed = (human as Humanbeing).moveSpeed;
            walkLeftCost -= speed;
            transform.position = new Vector3(curRenderPos.x, curRenderPos.y) + (1 - walkLeftCost / realTotalCost) * dir;
        }
        else
        {
            curTargetIsReached = true;
            human.GridPos = worldPos.ToCell();
        }
    }

    private void FixedUpdate()
    {
        Tick();
        DrawLine(curPath);
    }

    private void OnEnable()
    {
        EventCenter.Instance.Register<SingleWork>(EventEnum.WORK_GOTO_WORK_POS.ToString(), OnGoToWorkPos);
    }

    private void OnGoToWorkPos(SingleWork work)
    {
        if (work.worker.instanceID != humanID)
        {
            return;
        }
        var human = SceneItemsManager.Instance.GetWorldObjectById(humanID);
        curPath = GlobalPathManager.Instance.CreateNewPath(human.GridPos, work.WorkerPos);
        curDestination = work.WorkerPos.ToWorldVector2Int();
        lastStampFrameCount = Time.frameCount;
        atDestination = false;
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_GOTO_WORK_POS.ToString(), OnGoToWorkPos);
    }
}
