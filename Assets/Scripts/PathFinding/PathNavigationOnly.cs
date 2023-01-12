using LittleWorld;
using LittleWorldObject;
using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using Unity.VisualScripting;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.Events;

public class PathNavigationOnly : MonoBehaviour
{
    private Grid mapGrid;
    private Queue<Vector2Int> curPath;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    private Vector2Int curTarget;
    private UnityAction afterReached;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject targetPoint;

    private bool curTargetIsReached = true;
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
        curPath = new Queue<Vector2Int>();
        await TaskHelper.Wait(() => GlobalPathManager.Instance.Initialized == true);
    }

    public void ResetPath()
    {
        curTargetIsReached = true;
        curPath?.Clear();
    }

    public void CreateNewPath(Vector3 worldPos, UnityAction afterReached = null)
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();
        var cellPosition = mapGrid.WorldToCell(worldPos);
        this.afterReached = afterReached;

        var currentPos = mapGrid.WorldToCell(transform.position);
        curPath = GlobalPathManager.Instance.CalculatePath(
            new Vector2Int(currentPos.x, currentPos.y),
            new Vector2Int(cellPosition.x, cellPosition.y)
            );
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

    private void Tick()
    {
        MoveInPath();
    }

    private void MoveInPath()
    {
        lineRenderer.enabled = true;
        targetPoint.gameObject.SetActive(true);

        if (curTargetIsReached)
        {
            if (curPath.Count > 0)
            {
                curTarget = curPath.Dequeue();
                MoveTo(curTarget);
            }
            else
            {
                lineRenderer.enabled = false;
                targetPoint.gameObject.SetActive(false);

                //完成到达指定目的地后的工作
                afterReached?.Invoke();
                afterReached = null;
            }
        }
        else
        {
            MoveTo(curTarget);
        }
    }

    private void MoveTo(Vector2Int target)
    {
        SingleStep(target);
    }

    private void SingleStep(Vector2Int target)
    {
        var worldPos = mapGrid.CellToWorld(new Vector3Int(target.x, target.y, 0));
        Vector3 dir = worldPos - transform.position;

        if (Vector3.Distance(transform.position, worldPos) > 0.05)
        {
            curTargetIsReached = false;
            this.Speed = dir.normalized * 4f;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + Speed * Time.fixedDeltaTime);
        }
        else
        {
            curTargetIsReached = true;
            this.Speed = Vector3.zero;
            var human = SceneItemsManager.Instance.GetWorldObjectById(humanID);
            human.GridPos = new Vector3Int((int)worldPos.x, (int)worldPos.y, 0);
        }
    }

    private void Update()
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
        CreateNewPath(work.WorkPos, () =>
        {
            EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), humanID);
        });
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_GOTO_WORK_POS.ToString(), OnGoToWorkPos);
    }
}
