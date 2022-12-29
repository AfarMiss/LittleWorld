using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNavigation : MonoBehaviour
{
    public List<NPCSchedule> nPCSchedules;
    private Grid mapGrid;
    private Stack<Vector2Int> curPath;

    private void Start()
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();

        curPath = PathManager.Instance.CalculatePath((Vector2Int)mapGrid.WorldToCell(transform.position), nPCSchedules[0].targetPos);
        while (curPath.Count > 0)
        {
            var curTarget = curPath.Pop();
            MoveTo(curTarget);
        }
    }

    public void MoveTo(Vector2Int target)
    {
        StartCoroutine(MoveCoroutine(target));
    }

    private IEnumerator MoveCoroutine(Vector2Int target)
    {
        var worldPos = mapGrid.CellToWorld((Vector3Int)target);
        var dir = worldPos - transform.position;
        while (Vector3.Distance(transform.position, (Vector3Int)target) > 0.0625f)
        {
            GetComponent<Rigidbody2D>().MovePosition(dir * Time.fixedDeltaTime * 4f);
            yield return null;
        }
    }
}
