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
        GraphicsUtiliy.DrawMesh(material);
    }
}