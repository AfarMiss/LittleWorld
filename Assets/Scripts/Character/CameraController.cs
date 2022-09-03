using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField, Range(0, 10)] private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Move(Vector2 dir)
    {
        this.dir = new Vector3(dir.x, dir.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += this.dir * Time.deltaTime * speed;
    }
}
