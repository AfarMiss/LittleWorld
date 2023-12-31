﻿using System.Collections;
using Unity.Burst;
using Unity.Mathematics;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Jobs.LowLevel.Unsafe;
using System.CodeDom.Compiler;

namespace ProcedualWorld
{
    public class Chunk : MonoBehaviour
    {
        public Material atlas;
        public int width = 2;
        public int height = 2;
        public int depth = 2;

        public Block[,,] blocks;
        private void Start()
        {
            MeshFilter mf = gameObject.AddComponent<MeshFilter>();
            MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
            mr.material = atlas;
            blocks = new Block[width, height, depth];

            var inputMeshes = new List<Mesh>(width * height * depth);
            int vertexStart = 0;
            int triStart = 0;
            int meshCount = width * height * depth;
            int m = 0;
            var jobs = new ProcessMeshDataJob();
            jobs.vertexStart = new NativeArray<int>(meshCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
            jobs.triStart = new NativeArray<int>(meshCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);

            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        blocks[x, y, z] = new Block(new Vector3(x, y, z), MeshUtils.BlockType.DIRT);
                        inputMeshes.Add(blocks[x, y, z].mesh);
                        var vcount = blocks[x, y, z].mesh.vertexCount;
                        var icount = (int)blocks[x, y, z].mesh.GetIndexCount(0);
                        jobs.vertexStart[m] = triStart;
                        jobs.triStart[m] = triStart;
                        vertexStart += vcount;
                        triStart += icount;
                        m++;
                    }
                }
            }

            jobs.meshData = Mesh.AcquireReadOnlyMeshData(inputMeshes);
            var outputMeshData = Mesh.AllocateWritableMeshData(1);
            jobs.outputMesh = outputMeshData[0];
            jobs.outputMesh.SetIndexBufferParams(triStart, IndexFormat.UInt32);
            jobs.outputMesh.SetVertexBufferParams(vertexStart,
                new VertexAttributeDescriptor(VertexAttribute.Position),
                new VertexAttributeDescriptor(VertexAttribute.Normal, stream: 1),
                new VertexAttributeDescriptor(VertexAttribute.TexCoord0, stream: 2));

            var handle = jobs.Schedule(meshCount, 4);
            var newMesh = new Mesh();
            newMesh.name = "Chunk";
            var sm = new SubMeshDescriptor(0, triStart, MeshTopology.Triangles);
            sm.firstVertex = 0;
            sm.vertexCount = vertexStart;

            handle.Complete();

            jobs.outputMesh.subMeshCount = 1;
            jobs.outputMesh.SetSubMesh(0, sm);

            Mesh.ApplyAndDisposeWritableMeshData(outputMeshData, new[] { newMesh });
            jobs.meshData.Dispose();
            jobs.vertexStart.Dispose();
            jobs.triStart.Dispose();
            newMesh.RecalculateBounds();

            mf.mesh = newMesh;
        }

        [BurstCompile]
        struct ProcessMeshDataJob : IJobParallelFor
        {
            [ReadOnly]
            public Mesh.MeshDataArray meshData;
            public Mesh.MeshData outputMesh;
            public NativeArray<int> vertexStart;
            public NativeArray<int> triStart;

            public void Execute(int index)
            {
                var data = meshData[index];
                var vCount = data.vertexCount;
                var vStart = vertexStart[index];

                var verts = new NativeArray<float3>(vCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
                data.GetVertices(verts.Reinterpret<Vector3>());

                var normals = new NativeArray<float3>(vCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
                data.GetNormals(normals.Reinterpret<Vector3>());

                var uvs = new NativeArray<float3>(vCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
                data.GetUVs(0, uvs.Reinterpret<Vector3>());

                var outputVerts = outputMesh.GetVertexData<Vector3>();
                var outputNormals = outputMesh.GetVertexData<Vector3>(stream: 1);
                var outputUVs = outputMesh.GetVertexData<Vector3>(stream: 2);

                for (int i = 0; i < vCount; i++)
                {
                    outputVerts[i + vStart] = verts[i];
                    outputNormals[i + vStart] = normals[i];
                    outputUVs[i + vStart] = uvs[i];
                }

                verts.Dispose();
                normals.Dispose();
                uvs.Dispose();

                var tStart = triStart[index];
                var tCount = data.GetSubMesh(0).indexCount;
                var outputTris = outputMesh.GetIndexData<int>();
                if (data.indexFormat == IndexFormat.UInt16)
                {
                    var tris = data.GetIndexData<ushort>();
                    for (int i = 0; i < tCount; i++)
                    {
                        int idx = tris[i];
                        outputTris[i + tStart] = vStart + idx;
                    }
                }
                else
                {
                    var tris = data.GetIndexData<int>();
                    for (int i = 0; i < tCount; i++)
                    {
                        int idx = tris[i];
                        outputTris[i + tStart] = vStart + idx;
                    }
                }
            }
        }

        private void Update()
        {

        }
    }
}
