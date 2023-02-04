﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LittleWorld.Widget
{
    public class SetTextureInfo : EditorWindow
    {
        /// <summary>
        /// 循环设置选择的图片
        /// </summary>
        [MenuItem("SetTextureInfo/SetTextureInfo")]
        private static void LoopSetTexture()
        {
            object[] textures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);

            foreach (Texture2D texture in textures)
            {
                string path = AssetDatabase.GetAssetPath(texture);
                TextureImporter texImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                //不处理类型为“Lightmap”的Texture
                if ("Lightmap" != texImporter.textureType.ToString())
                {
                    //修改Texture Type
                    texImporter.textureType = TextureImporterType.Sprite;
                    ////修改Aniso Level
                    //texImporter.anisoLevel = 0;
                    ////修改Read/Write enabled 
                    //texImporter.isReadable = false;
                    ////修改Generate Mip Maps
                    //texImporter.mipmapEnabled = false;

                    //string texName = texture.name;
                    //int maxSize[2];
                    //TextureImporterFormat texFormat;
                    //texImporter.GetPlatformTextureSettings("Android", out maxSize[0], out texFormat);
                    //texImporter.GetPlatformTextureSettings("iPhone", out maxSize[1], out texFormat);
                    //if (texName.Contains("alpha"))
                    //{
                    //    texImporter.SetPlatformTextureSettings("Android", maxSize[0], TextureImporterFormat.ETC2_RGBA8);
                    //    texImporter.SetPlatformTextureSettings("iPhone", maxSize[1], TextureImporterFormat.PVRTC_RGBA4);
                    //}
                    //else
                    //{
                    //    texImporter.SetPlatformTextureSettings("Android", maxSize[0], TextureImporterFormat.ETC2_RGB4);
                    //    texImporter.SetPlatformTextureSettings("iPhone", maxSize[1], TextureImporterFormat.PVRTC_RGB4);
                    //}
                    AssetDatabase.ImportAsset(path);
                }
            }
        }
    }
}