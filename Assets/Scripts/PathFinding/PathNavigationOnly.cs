using LittleWorld;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.Events;

public class PathNavigationOnly : MonoBehaviour
{
    private Queue<Vector2Int> curPath;
    private Vector3 imageOffset = new Vector3(0.5f, 0.5f, 0);
    private Vector2Int curTarget;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject targetPoint;

    private bool curTargetIsReached = true;
    private bool AtDestination = true;
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
    private void Start()
    {
        curPath = new Queue<Vector2Int>();
    }

    public void ResetPath()
    {
        curTargetIsReached = true;
        AtDestination = true;
        curPath?.Clear();
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
        targetPoint.gameObject.SetActive(true);

        if (!AtDestination)
        {
            if (curTargetIsReached)
            {
                if (curPath.Count > 0)
                {
                    curTarget = curPath.Dequeue();
                    curTargetIsReached = false;
                    return;
                }
                else
                {
                    AtDestination = true;
                    lineRenderer.enabled = false;
                    targetPoint.gameObject.SetActive(false);
                    //完成到达指定目的地后的工作
                    EventCenter.Instance.Trigger(EventEnum.REACH_WORK_POINT.ToString(), humanID);
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
        curPath = GlobalPathManager.Instance.CreateNewPath(transform.position, work.WorkPos);
        AtDestination = false;
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_GOTO_WORK_POS.ToString(), OnGoToWorkPos);
    }
}
