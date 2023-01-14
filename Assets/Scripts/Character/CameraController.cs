using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 dir;
    public Transform referencePoint;
    [SerializeField, Range(0, 10)] private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Move(Vector2 dir)
    {
        this.dir = new Vector3(dir.x, dir.y, 0);
    }

    void Update()
    {
        Camera.main.transform.position += this.dir * Time.deltaTime * speed * 2;
    }
}
