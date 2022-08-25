using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [Range(1, 80)] public float Mult;
    public GameObject Sun;
    private void Update()
    {
        Sun.transform.Rotate(Vector3.left * Mult * Time.deltaTime, Space.World);
    }
}
