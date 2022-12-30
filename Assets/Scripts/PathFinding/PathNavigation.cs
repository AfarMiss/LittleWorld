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
    private bool curScheduleIsReached = true;
    public Vector3 Speed;

    private async void Start()
    {
        await TaskHelper.Wait(() => PathManager.Instance.Initialized == true);
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();

        while (nPCSchedules.Count > 0)
        {
            if (curScheduleIsReached)
            {
                curScheduleIsReached = false;
                var currentPos = mapGrid.WorldToCell(transform.position);
                curPath = PathManager.Instance.CalculatePath(new Vector2Int(currentPos.x, currentPos.y), nPCSchedules[0].targetPos);
                StartCoroutine(MoveInPath(nPCSchedules[0]));
                nPCSchedules.RemoveAt(0);
            }
            yield return null;
        }
    }

    private IEnumerator MoveInPath(NPCSchedule nPCSchedule)
    {
        var ac = GetComponent<NPCMovementAnimationParameterControl>();
        while (curPath.Count >= 0)
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
                    ac.ResetMovement();
                    switch (nPCSchedule.workType)
                    {
                        case WorkType.dug:
                            ac.isUsingToolRight = true;
                            break;
                        case WorkType.water:
                            ac.isLiftingToolRight = true;
                            break;
                        default:
                            break;
                    }

                    yield return new WaitForSeconds(nPCSchedule.lastTime * FarmSetting.gameTick * 60 * 60);

                    switch (nPCSchedule.workType)
                    {
                        case WorkType.dug:
                            ac.isUsingToolRight = false;
                            break;
                        case WorkType.water:
                            ac.isLiftingToolRight = false;
                            break;
                        default:
                            break;
                    }
                    break;
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
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir.normalized * Time.fixedDeltaTime * 2f);
            yield return null;
        }
        curTargetIsReached = true;
        this.Speed = Vector3.zero;
    }
}
