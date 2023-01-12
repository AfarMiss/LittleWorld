using LittleWorld;
using LittleWorldObject;
using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.Events;

public class PathNavigationOnly : MonoBehaviour
{
    public Queue<Vector2Int> pathSchedules = new Queue<Vector2Int>();
    private Grid mapGrid;
    private Queue<Vector2Int> curPath;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    private Vector2Int curTarget;
    private UnityAction afterReached;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject targetPoint;

    private bool curTargetIsReached = true;
    private bool curScheduleIsReached = true;
    private Vector3 Speed;

    public bool isMoving => Speed.magnitude != 0;

    /// <summary>
    /// 代表的itemInstanceID
    /// </summary>
    public int humanID;

    public void Initialize(int instanceID)
    {
        this.humanID = instanceID;
    }
    private async void Start()
    {
        await TaskHelper.Wait(() => GlobalPathManager.Instance.Initialized == true);
    }

    public void AddMovePositionAndMove(Vector3 worldPos, UnityAction afterReached = null)
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();
        curScheduleIsReached = true;
        curTargetIsReached = true;
        pathSchedules?.Clear();
        curPath?.Clear();

        var cellPosition = mapGrid.WorldToCell(worldPos);
        pathSchedules.Enqueue(new Vector2Int(cellPosition.x, cellPosition.y));
        StopAllCoroutines();
        StartCoroutine(Move());

        this.afterReached = afterReached;
    }

    private void DrawLine(Queue<Vector2Int> path)
    {
        if (path == null) return;
        var pathArray = path.ToArray();
        if (pathArray.Length != 0)
        {
            targetPoint.transform.SetPositionAndRotation(
                new Vector3(pathArray[pathArray.Length - 1].x, pathArray[pathArray.Length - 1].y, 0) + imageOffset,
                Quaternion.identity
                );
        }
        else if (curTarget != null)
        {
            targetPoint.transform.SetPositionAndRotation(
    new Vector3(curTarget.x, curTarget.y, 0) + imageOffset,
    Quaternion.identity
    );
        }
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



    }

    private IEnumerator Move()
    {
        while (pathSchedules.Count > 0)
        {
            if (curScheduleIsReached)
            {
                curScheduleIsReached = false;
                var currentPos = mapGrid.WorldToCell(transform.position);
                var target = pathSchedules.Dequeue();
                curPath = GlobalPathManager.Instance.CalculatePath(new Vector2Int(currentPos.x, currentPos.y), target);

                //如果路径不止一个点时，去掉起点
                if (curPath.Count > 1)
                {
                    curPath.Dequeue();
                }

                StartCoroutine(MoveInPath(target));
            }
            yield return null;
        }
    }

    private IEnumerator MoveInPath(Vector2Int nPCSchedule)
    {
        lineRenderer.enabled = true;
        targetPoint.gameObject.SetActive(true);

        while (curPath.Count >= 0)
        {
            if (curTargetIsReached)
            {
                if (curPath.Count > 0)
                {
                    curTargetIsReached = false;
                    curTarget = curPath.Dequeue();
                    MoveTo(curTarget);
                }
                else
                {
                    //完成到达指定目的地后的工作
                    afterReached?.Invoke();
                    afterReached = null;
                    break;
                }
            }
            yield return null;
        }
        curScheduleIsReached = true;

        lineRenderer.enabled = false;
        targetPoint.gameObject.SetActive(false);
    }

    private void MoveTo(Vector2Int target)
    {
        StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Vector2Int target)
    {
        var worldPos = mapGrid.CellToWorld(new Vector3Int(target.x, target.y, 0));
        Vector3 dir = worldPos - transform.position;
        this.Speed = dir.normalized * 4f;

        while (Vector3.Distance(transform.position, worldPos) > 0.05)
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + Speed * Time.fixedDeltaTime);
            yield return null;
        }
        curTargetIsReached = true;
        var human = SceneItemsManager.Instance.GetWorldObjectById(humanID);
        human.GridPos = new Vector3Int((int)worldPos.x, (int)worldPos.y, 0);
        this.Speed = Vector3.zero;
    }

    private void Update()
    {
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
        AddMovePositionAndMove(work.WorkPos, () =>
        {
            EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), humanID);
        });
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_GOTO_WORK_POS.ToString(), OnGoToWorkPos);
    }
}
