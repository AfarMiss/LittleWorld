using LittleWorld.Graphics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.UI
{
    public class TextureDatabase
    {
        public static readonly Texture2D Tex_Destination = GraphicsUtiliy.GetTexture2D(UIPath.Image_Destination);
        public static readonly Texture2D Tex_Zoom_Green = GetZoomSubTex(1);
        public static readonly Texture2D Tex_Zoom_Plant_Area = GetIndictorSubTex(2);


        private static Texture2D GetZoomSubTex(int index)
        {
            var texture = GraphicsUtiliy.GetTexture2D(UIPath.Image_ZoomDynamic);
            var resultTexture = new Texture2D(16, 16);
            Color[] colors = texture.GetPixels(index * 16, 0, 16, 16);
            resultTexture.SetPixels(0, 0, 16, 16, colors);
            resultTexture.Apply();
            return resultTexture;
        }

        private static Texture2D GetIndictorSubTex(int index)
        {
            var texture = GraphicsUtiliy.GetTexture2D(UIPath.Image_ZoomIndictor);
            var resultTexture = new Texture2D(16, 16);
            Color[] colors = texture.GetPixels(index * 16, 0, 16, 16);
            resultTexture.SetPixels(0, 0, 16, 16, colors);
            resultTexture.Apply();
            return resultTexture;
        }
    }
}
