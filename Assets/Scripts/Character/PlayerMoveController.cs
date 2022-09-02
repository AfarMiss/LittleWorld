using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed=1;

    private Vector3 destination;

    public void Move(Vector3 destination)
    {
        this.destination = destination;
    }

    private void Update()
    {
        var dir = destination - this.transform.position;
        this.transform.position += dir.normalized * moveSpeed * Time.deltaTime;
    }
}
