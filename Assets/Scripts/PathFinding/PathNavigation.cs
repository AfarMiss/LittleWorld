using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class PathNavigation : MonoBehaviour
{
    public List<NPCSchedule> nPCSchedules;
    private Grid mapGrid;
    private Queue<Vector2Int> curPath;

    private bool curTargetIsReached = true;

    private async void Start()
    {
        await TaskHelper.Wait(() => PathManager.Instance.Initialized == true);
        Move();
    }

    public void Move()
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();
        var currentPos = mapGrid.WorldToCell(transform.position);
        curPath = PathManager.Instance.CalculatePath(new Vector2Int(currentPos.x, currentPos.y), nPCSchedules[0].targetPos);
        StartCoroutine(MoveInPath());
    }

    private IEnumerator MoveInPath()
    {
        while (curPath.Count > 0)
        {
            if (curTargetIsReached)
            {
                curTargetIsReached = false;
                var curTarget = curPath.Dequeue();
                MoveTo(curTarget);
            }
            yield return null;
        }
    }

    public void MoveTo(Vector2Int target)
    {
        StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Vector2Int target)
    {
        var worldPos = mapGrid.CellToWorld(new Vector3Int(target.x, target.y, 0));
        var dir = worldPos - transform.position;
        while (Vector3.Distance(transform.position, worldPos) > 0.2)
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir.normalized * Time.fixedDeltaTime * 2f);
            yield return null;
        }
        curTargetIsReached = true;
    }
}
