using LittleWorld.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

namespace LittleWorld.Graphics
{
    public static class GraphicsUtiliy
    {
        public static void DrawTexture(Rect rect, Texture2D texture2D, Rect sourceRect = default)
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
            var upperLeftPoint = (bottomLeftPoint + new Vector2(0, 1)).ToScreenPos();
            var screenRect = new Vector2(upperLeftPoint.x, Screen.height - upperLeftPoint.y);
            var textureWidthVector =
                (bottomLeftPoint + new Vector2(worldWidth, 0)).ToScreenPos()
                - bottomLeftPoint.ToScreenPos();
            var textureWidth = (int)textureWidthVector.x;

            var textureHeightVector =
    (bottomLeftPoint + new Vector2(0, worldHeight)).ToScreenPos()
    - bottomLeftPoint.ToScreenPos();
            var textureHeight = (int)textureHeightVector.y;

            Texture2D tex = GetTexture2D(UIPath.Image_Selected);
            DrawTexture(new Rect(screenRect, new Vector2(textureWidth, textureHeight)), tex, new Rect(0f, 0f, 0.5f, 1f));
        }

        public static void DrawDestinationIcon(Vector2 bottomLeftPoint, float worldWidth, float worldHeight, float alpha)
        {
            var upperLeftPoint = (bottomLeftPoint + new Vector2(0, 1)).ToScreenPos();
            var screenRect = new Vector2(upperLeftPoint.x, Screen.height - upperLeftPoint.y);
            var textureWidthVector =
                (bottomLeftPoint + new Vector2(worldWidth, 0)).ToScreenPos()
                - bottomLeftPoint.ToScreenPos();
            var textureWidth = (int)textureWidthVector.x;

            var textureHeightVector =
    (bottomLeftPoint + new Vector2(0, worldHeight)).ToScreenPos()
    - bottomLeftPoint.ToScreenPos();
            var textureHeight = (int)textureHeightVector.y;

            Texture2D tex = TextureDatabase.Image_Destination;

            DrawTexture(new Rect(screenRect, new Vector2(textureWidth, textureHeight)), tex);
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
