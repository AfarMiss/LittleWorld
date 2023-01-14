using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Graphics
{
    public static class GraphicsUtiliy
    {
        public static void DrawTexture(Rect rect, Texture2D texture2D)
        {
            UnityEngine.Graphics.DrawTexture(rect, texture2D);
        }

        private static Texture2D GetTexture2D(string selectedPath)
        {
            var rawData = System.IO.File.ReadAllBytes(selectedPath);
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(rawData);
            return tex;
        }

        public static void DrawSelectedIcon(Vector2 bottomLeftPoint, float worldWidth, float worldHeight)
        {
            var screenPos = bottomLeftPoint.ToScreenPos();
            var GUIPos = new Vector2(screenPos.x, Screen.height - screenPos.y);
            var textureWidthVector =
                (bottomLeftPoint + new Vector2(worldWidth, 0)).ToScreenPos()
                - bottomLeftPoint.ToScreenPos();
            var textureWidth = (int)textureWidthVector.x;

            var textureHeightVector =
    (bottomLeftPoint + new Vector2(0, worldHeight)).ToScreenPos()
    - bottomLeftPoint.ToScreenPos();
            var textureHeight = (int)textureHeightVector.y;

            Texture2D tex = GetTexture2D(UIPath.Image_Selected);
            var desColor = tex.GetPixels(0, 0, tex.width / 2, tex.height);
            Texture2D desTex = new Texture2D(tex.width / 2, tex.height);
            desTex.SetPixels(desColor);
            desTex.Apply();
            DrawTexture(new Rect(GUIPos, new Vector2(textureWidth, textureHeight)), desTex);
        }
    }
}
