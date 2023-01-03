using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
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
    [HideInInspector] public Vector3 Speed;

    private async void Start()
    {
        await TaskHelper.Wait(() => PathManager.Instance.Initialized == true);
    }

    public void AddMovePositionAndMove(Vector3 worldPos, UnityAction afterReached)
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
                curPath = PathManager.Instance.CalculatePath(new Vector2Int(currentPos.x, currentPos.y), target);

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
                    break;
                }
            }
            yield return null;
        }
        curScheduleIsReached = true;

        lineRenderer.enabled = false;
        targetPoint.gameObject.SetActive(false);
    }

    public void MoveTo(Vector2Int target)
    {
        StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Vector2Int target)
    {
        var worldPos = mapGrid.CellToWorld(new Vector3Int(target.x, target.y, 0));
        Vector3 dir = worldPos - transform.position;
        this.Speed = dir.normalized;

        while (Vector3.Distance(transform.position, worldPos) > 0.05)
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir.normalized * Time.fixedDeltaTime * 4f);
            yield return null;
        }
        curTargetIsReached = true;
        this.Speed = Vector3.zero;
    }

    private void Update()
    {
        DrawLine(curPath);
    }
}
