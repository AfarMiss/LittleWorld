using ProcedualWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MeshUtility
{
    public static class MeshUtil
    {
        private static Dictionary<string, Mesh> meshDictionary = new Dictionary<string, Mesh>();
        public static Mesh Quad(Vector3 pos)
        {
            Mesh mesh;
            var key = $"MeshUtil_Quad_{pos}";
            if (meshDictionary.ContainsKey(key))
            {
                mesh = meshDictionary[key];
            }
            else
            {
                mesh = CreateNewMesh(pos);
                meshDictionary.Add(key, mesh);
            }

            return mesh;
        }

        private static Mesh CreateNewMesh(Vector3 pos)
        {
            Mesh mesh;
            {
                mesh = new Mesh();
                mesh.vertices = new Vector3[4]
{
                new Vector3(0.0f, 0.0f, 0.0f)+pos,
                new Vector3(0.0f, 1.0f, 0.0f)+pos,
                new Vector3(1.0f, 0.0f, 0.0f)+pos,
                new Vector3(1.0f, 1.0f, 0.0f)+pos,
};
                mesh.triangles = new int[6]
                {
                0,1,3,
                0,3,2,
                };
                mesh.RecalculateBounds();
                mesh.RecalculateNormals();
            }

            return mesh;
        }

        public static Mesh GreenZoom(Vector3 pos)
        {
            Mesh mesh;
            var key = $"MeshUtil_Quad_Green_{pos}";
            if (meshDictionary.ContainsKey(key))
            {
                mesh = meshDictionary[key];
            }
            else
            {
                mesh = CreateNewMesh(pos);
                mesh.uv = new Vector2[]
                {
                new Vector2(0.2f,0),
                new Vector2(0.4f,0),
                new Vector2(0.2f,1f),
                new Vector2(0.4f,1f),
                };
                meshDictionary.Add(key, mesh);
            }
            return mesh;
        }
    }
}
