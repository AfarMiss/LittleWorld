using LittleWorld;
using LittleWorld.Extension;
using LittleWorld.Item;
using LittleWorld.Path;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static AI.MoveLeaf;

[RequireComponent(typeof(LineRenderer))]
public class PathNavigation : MonoBehaviour
{
    public Face animalFace;
    public int lastStampFrameCount = -1;
    private PathInfo curPathInfo;
    public Vector2Int? curDestination;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    public Vector2Int? CurStepTarget => curStepTarget;
    public Vector2Int? CurDestination => curDestination;
    private Vector2Int? curStepTarget = null;
    private MoveType? curMoveType => curPathInfo?.moveType;
    [SerializeField] private LineRenderer lineRenderer;
    private bool showPath = false;
    public bool PathIsShow => showPath;

    private float walkLeftCost = 0;
    private float realTotalCost = 0;
    private float walkBaseTotalCost = 100;

    private bool curTargetIsReached = true;
    public bool atDestination = true;
    public Vector2 RenderPos
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
    public Vector2 curRenderPos;
    private Vector3 dir;

    public bool IsMoving => curPathInfo.curPath.Safe().Any() || curStepTarget != null;
    //private bool isMovingDiagonally => IsMoving && curTarget.InStraightLine(human.GridPos);
    private float diagonalRate = 1.41f;

    public void ShowPath()
    {
        showPath = true;
    }

    public void HidePath()
    {
        showPath = false;
    }

    /// <summary>
    /// 代表的itemInstanceID
    /// </summary>
    public int animalID;
    public Animal animal => SceneObjectManager.Instance.GetWorldObjectById(animalID) as Animal;

    public void Initialize(int instanceID)
    {
        this.animalID = instanceID;
    }
    private void Start()
    {
        curPathInfo = new PathInfo();
    }

    public void ResetPath()
    {
        curTargetIsReached = true;
        atDestination = true;
        curPathInfo.curPath?.Clear();
        curStepTarget = default;
        curDestination = default;
        curRenderPos = default;
    }

    private void DrawLine(Queue<Vector2Int> path)
    {
        lineRenderer.enabled = !atDestination && showPath;
        if (path == null || !showPath)
        {
            return;
        }
        var pathArray = path.ToArray();
        lineRenderer.positionCount = pathArray.Length + 2;
        lineRenderer.SetPosition(0, this.transform.position + imageOffset);
        if (curStepTarget != null)
        {
            lineRenderer.SetPosition(1, new Vector3(curStepTarget.Value.x, curStepTarget.Value.y, 0) + imageOffset);
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
        if (!atDestination)
        {
            if (curTargetIsReached)
            {
                curStepTarget = null;
                if (curPathInfo.curPath.Count > 0)
                {
                    curStepTarget = curPathInfo.curPath.Dequeue();
                    dir = curStepTarget.Value - RenderPos;
                    realTotalCost = Vector2.Distance(RenderPos, curStepTarget.Value) * walkBaseTotalCost;
                    walkLeftCost += Vector2.Distance(RenderPos, curStepTarget.Value) * walkBaseTotalCost;
                    curRenderPos = RenderPos;
                    curTargetIsReached = false;
                    return;
                }
                else
                {
                    atDestination = true;
                    //完成到达指定目的地后的工作
                    EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), animalID);
                    if (this.animal is Humanbeing)
                    {
                        animalFace = Face.Down;
                    }
                    Debug.Log($"Reached {curStepTarget}");
                }
            }
            else
            {
                MoveTo(curStepTarget.Value);
            }
        }
    }

    private void MoveTo(Vector2Int target)
    {
        SingleStep(target);
    }

    private void SingleStep(Vector2Int target)
    {
        var human = SceneObjectManager.Instance.GetWorldObjectById(animalID);
        //Debug.Log("human.gridPos:" + human.GridPos);

        if (walkLeftCost > 0)
        {
            animalFace = DirectionHelper.JudgeDirFace(RenderPos, curStepTarget.Value.To3());
            var speed = (human as Animal).MoveSpeed * PathInfo.GetSpeedRatio(curMoveType);
            walkLeftCost -= speed;
            transform.position = new Vector3(curRenderPos.x, curRenderPos.y) + (1 - walkLeftCost / realTotalCost) * dir;
        }
        else
        {
            curTargetIsReached = true;
            human.GridPos = target;
        }
        //Debug.Log("animalFace:" + animalFace);
    }

    private void FixedUpdate()
    {
        Tick();
        DrawLine(curPathInfo.curPath);
    }

    public void GoToLoc(Vector2Int target, MoveType moveType)
    {
        var human = SceneObjectManager.Instance.GetWorldObjectById(animalID);
        curPathInfo.curPath = MapManager.Instance.CreateNewPath(human.GridPos, target);
        curPathInfo.moveType = moveType;
        curDestination = target;
        lastStampFrameCount = Time.frameCount;
        atDestination = false;
    }

    public PathNavigation()
    {
        animalFace = Face.Up;
    }
}
