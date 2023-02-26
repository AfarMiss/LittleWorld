using LittleWorld;
using LittleWorld.Extension;
using LittleWorld.Item;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class PathNavigation : MonoBehaviour
{
    public Face animalFace;
    public int lastStampFrameCount = -1;
    private Queue<Vector2Int> curPath;
    public Vector2Int curDestination;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    public Vector2Int? CurTarget => curTarget;
    private Vector2Int? curTarget = null;
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

    public bool IsMoving => curPath.Safe().Any() || curTarget != null;
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
    public Animal human => SceneObjectManager.Instance.GetWorldObjectById(animalID) as Animal;

    public void Initialize(int instanceID)
    {
        this.animalID = instanceID;
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
        lineRenderer.enabled = !atDestination && showPath;
        if (path == null || !showPath)
        {
            return;
        }
        var pathArray = path.ToArray();
        lineRenderer.positionCount = pathArray.Length + 2;
        lineRenderer.SetPosition(0, this.transform.position + imageOffset);
        if (curTarget != null)
        {
            lineRenderer.SetPosition(1, new Vector3(curTarget.Value.x, curTarget.Value.y, 0) + imageOffset);
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
                curTarget = null;
                if (curPath.Count > 0)
                {
                    curTarget = curPath.Dequeue();
                    dir = curTarget.Value - RenderPos;
                    realTotalCost = Vector2.Distance(RenderPos, curTarget.Value) * walkBaseTotalCost;
                    walkLeftCost += Vector2.Distance(RenderPos, curTarget.Value) * walkBaseTotalCost;
                    curRenderPos = RenderPos;
                    curTargetIsReached = false;
                    return;
                }
                else
                {
                    atDestination = true;
                    //完成到达指定目的地后的工作
                    EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), animalID);
                    animalFace = Face.Down;
                    Debug.Log($"Reached {curTarget}");
                }
            }
            else
            {
                MoveTo(curTarget.Value);
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
            animalFace = DirectionHelper.JudgeDirFace(RenderPos, curTarget.Value.To3());
            var speed = (human as Animal).MoveSpeed;
            walkLeftCost -= speed;
            transform.position = new Vector3(curRenderPos.x, curRenderPos.y) + (1 - walkLeftCost / realTotalCost) * dir;
        }
        else
        {
            curTargetIsReached = true;
            human.GridPos = target;
        }
        Debug.Log("animalFace:" + animalFace);
    }

    private void FixedUpdate()
    {
        Tick();
        DrawLine(curPath);
    }

    public void GoToLoc(Vector2Int target)
    {
        var human = SceneObjectManager.Instance.GetWorldObjectById(animalID);
        curPath = MapManager.Instance.CreateNewPath(human.GridPos, target);
        curDestination = target;
        lastStampFrameCount = Time.frameCount;
        atDestination = false;
    }

    public PathNavigation()
    {
        animalFace = Face.Up;
    }
}
