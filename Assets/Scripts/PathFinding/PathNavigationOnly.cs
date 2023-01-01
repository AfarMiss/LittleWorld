using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class PathNavigationOnly : MonoBehaviour
{
    public Queue<Vector2Int> pathSchedules = new Queue<Vector2Int>();
    private Grid mapGrid;
    private Queue<Vector2Int> curPath;

    private bool curTargetIsReached = true;
    private bool curScheduleIsReached = true;
    [HideInInspector] public Vector3 Speed;

    private bool managerInitialized = false;

    private async void Start()
    {
        await TaskHelper.Wait(() => PathManager.Instance.Initialized == true);
    }

    public void AddMovePositionAndMove(Vector3 worldPos)
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();
        var cellPosition = mapGrid.WorldToCell(worldPos);
        pathSchedules.Enqueue(new Vector2Int(cellPosition.x, cellPosition.y));
        StopAllCoroutines();
        StartCoroutine(Move());
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
                StartCoroutine(MoveInPath(target));
            }
            yield return null;
        }
    }

    private IEnumerator MoveInPath(Vector2Int nPCSchedule)
    {
        while (curPath.Count > 0)
        {
            if (curTargetIsReached)
            {
                if (curPath.Count > 0)
                {
                    curTargetIsReached = false;
                    var curTarget = curPath.Dequeue();
                    MoveTo(curTarget);
                }
                else
                {
                    //完成到达指定目的地后的工作
                }
            }
            yield return null;
        }
        curScheduleIsReached = true;
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

        while (Vector3.Distance(transform.position, worldPos) > 0.2)
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir.normalized * Time.fixedDeltaTime * 4f);
            yield return null;
        }
        curTargetIsReached = true;
        this.Speed = Vector3.zero;
    }
}
