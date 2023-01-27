using ProcedualWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MeshUtility
{
    public static class MeshUtil
    {
        public static Mesh Quad(Vector3 pos)
        {
            var mesh = new Mesh();
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
            return mesh;
        }

        public static Mesh GreenZoom(Vector3 pos)
        {
            var quad = Quad(pos);
            quad.uv = new Vector2[]
            {
                new Vector2(0.4f,0),
                new Vector2(0.6f,0),
                new Vector2(0.4f,1f),
                new Vector2(0.6f,1f),
        };
            return quad;
        }
    }
}
