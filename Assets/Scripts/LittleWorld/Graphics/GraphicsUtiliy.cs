﻿using LittleWorld.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

namespace LittleWorld.Graphics
{
    public static class GraphicsUtiliy
    {
        public static void DrawMesh(Material material, string layerName = "Default")
        {
            UnityEngine.Graphics.DrawMesh(MeshUtility.MeshUtil.Quad(Vector3.zero), Vector3.zero, Quaternion.identity, material, LayerMask.NameToLayer(layerName));
        }

        public static void DrawSelectedPlantZoom(Vector3 pos, Material material, int zoomLayer, string layerName = "Default")
        {
            var mesh = MeshUtility.MeshUtil.GreenZoom(pos - Vector3.forward * zoomLayer);
            UnityEngine.Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, LayerMask.NameToLayer(layerName));
            foreach (var item in mesh.vertices)
            {
                Debug.Log($"grids.info.vertice: {item}");
            }
        }

        public static void DrawColorQuadMesh(Color color, Vector3 pos, int zoomLayer, string layerName = "Default")
        {
            var material = MaterialDatabase.Instance.PlantZoomMaterial;
            material.color = color;
            UnityEngine.Graphics.DrawMesh(MeshUtility.MeshUtil.Quad(pos - Vector3.forward * zoomLayer), Vector3.zero, Quaternion.identity, material, LayerMask.NameToLayer(layerName));
        }

        private static void DrawTextureInternal(Rect rect, Texture2D texture2D, Rect sourceRect = default)
        {
            if (sourceRect == default)
            {
                UnityEngine.Graphics.DrawTexture(rect, texture2D);
            }
            else
            {
                UnityEngine.Graphics.DrawTexture(rect, texture2D, sourceRect, 0, 0, 0, 0);
            }
        }

        public static Texture2D GetTexture2D(string selectedPath)
        {
            var rawData = System.IO.File.ReadAllBytes(selectedPath);
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(rawData);
            return tex;
        }

        public static void DrawSelectedIcon(Vector2 bottomLeftPoint, float worldWidth, float worldHeight)
        {
            Rect resultRect = GetScreenRect(bottomLeftPoint, worldWidth, worldHeight);
            Texture2D tex = GetTexture2D(UIPath.Image_Selected);
            DrawTextureInternal(resultRect, tex, new Rect(0f, 0f, 0.5f, 1f));
        }

        public static void DrawDestinationIcon(Vector2 bottomLeftPoint, float worldWidth, float worldHeight)
        {
            Rect resultRect = GetScreenRect(bottomLeftPoint, worldWidth, worldHeight);
            Texture2D tex = TextureDatabase.Tex_Destination;
            DrawTextureInternal(resultRect, tex);
        }

        /// <summary>
        /// 绘制Texture
        /// </summary>
        /// <param name="bottomLeftPoint"></param>
        /// <param name="worldWidth"></param>
        /// <param name="worldHeight"></param>
        /// <param name="texture2D"></param>
        public static void DrawTexture(Vector2 bottomLeftPoint, float worldWidth, float worldHeight, Texture2D texture2D)
        {
            Rect resultRect = GetScreenRect(bottomLeftPoint, worldWidth, worldHeight);
            DrawTextureInternal(resultRect, texture2D);
        }

        /// <summary>
        /// 绘制子Texture
        /// </summary>
        /// <param name="bottomLeftPoint"></param>
        /// <param name="worldWidth"></param>
        /// <param name="worldHeight"></param>
        /// <param name="texture2D"></param>
        /// <param name="rect">(起始点x，起始点y，宽度占比（总值为1），高度占比（总值为1）)</param>
        public static void DrawSubTexture(Vector2 bottomLeftPoint, float worldWidth, float worldHeight, Texture2D texture2D, Rect rect)
        {
            Rect resultRect = GetScreenRect(bottomLeftPoint, worldWidth, worldHeight);
            DrawTextureInternal(resultRect, texture2D, rect);
        }

        private static Rect GetScreenRect(Vector2 worldBottomLeftPoint, float worldWidth, float worldHeight)
        {
            var upperLeftPoint = (worldBottomLeftPoint + new Vector2(0, 1)).ToScreenPos();
            var screenRect = new Vector2(upperLeftPoint.x, Screen.height - upperLeftPoint.y);
            var textureWidthVector =
                (worldBottomLeftPoint + new Vector2(worldWidth, 0)).ToScreenPos()
                - worldBottomLeftPoint.ToScreenPos();
            var textureWidth = (int)textureWidthVector.x;

            var textureHeightVector =
    (worldBottomLeftPoint + new Vector2(0, worldHeight)).ToScreenPos()
    - worldBottomLeftPoint.ToScreenPos();
            var textureHeight = (int)textureHeightVector.y;
            var resultRect = new Rect(screenRect, new Vector2(textureWidth, textureHeight));
            return resultRect;
        }

        public static void DrawPlantZoom(Vector2 bottomLeftPoint)
        {
            //默认alpha值为1f
            DrawColorQuadMesh(new Color(Color.red.r, Color.red.g, Color.red.b, 0.2f), bottomLeftPoint, 1);
        }

        public static Texture2D SpriteToTexture(Sprite sprite)
        {
            var targetTex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var pixels = sprite.texture.GetPixels(
                (int)sprite.textureRect.x,
                (int)sprite.textureRect.y,
                (int)sprite.textureRect.width,
                (int)sprite.textureRect.height);
            targetTex.SetPixels(pixels);
            targetTex.Apply();

            return targetTex;
        }

        public static Sprite TextureToSprite(Texture2D t2d)
        {
            return Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), Vector2.zero);
        }

        public static Texture2D CloneTexture(Texture2D originTex)
        {
            Texture2D newTex;
            newTex = new Texture2D(originTex.width, originTex.height);
            Color[] colors = originTex.GetPixels(0, 0, originTex.width, originTex.height);
            newTex.SetPixels(colors);
            newTex.Apply();

            return newTex;
        }

    }
}
