using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 dir;
    private Transform referencePoint;
    [SerializeField, Range(0, 10)] private float speed = 3;
    private void Awake()
    {
        referencePoint = new GameObject("referencePoint").transform;
        referencePoint.transform.position = Vector3.zero;
    }

    public void Move(Vector2 dir)
    {
        this.dir = new Vector3(dir.x, dir.y, 0);
    }

    public void MoveDelta(Vector2 delta)
    {
        Camera.main.transform.position += new Vector3(delta.x / 25, delta.y / 25, 0);
    }

    void Update()
    {
        Camera.main.transform.position += this.dir * Time.deltaTime * speed * 2;
    }
}
