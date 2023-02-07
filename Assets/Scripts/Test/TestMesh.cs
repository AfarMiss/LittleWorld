using UnityEngine;
using System.Collections;
using LittleWorld.Graphics;

public class TestMesh : MonoBehaviour
{
    public Material material;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        // GraphicsUtiliy.DrawColorMesh(Color.blue, new Vector3(1, 1, -1));
    }
}