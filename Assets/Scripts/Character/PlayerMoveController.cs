using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    /// <summary>
    /// 目标点移动允许误差
    /// </summary>
    public float bias = 0.05f;
    public bool isMoving = false;
    [SerializeField] private float moveSpeed = 1;

    private Vector3 destination;

    public void Move(Vector3 destination)
    {
        this.destination = destination;
        if (!isMoving) isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            var dir = destination - this.transform.position;
            if (dir.magnitude > bias)
            {
                this.transform.position += dir.normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
