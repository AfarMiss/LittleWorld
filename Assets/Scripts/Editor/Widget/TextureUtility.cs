using UnityEditor;
using UnityEngine;

namespace LittleWorld.TextureUtility
{
    using UnityEngine;
    using UnityEditor;

    public class TestSaveSprite
    {
        [MenuItem("Tools/导出切割图片")]
        static void SaveSprite()
        {
            string resourcesPath = "Assets/Resources/";
            object[] textures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
            foreach (Texture2D texture in textures)
            {
                string selectionPath = AssetDatabase.GetAssetPath(texture);

                // 必须最上级是"Assets/Resources/"
                if (selectionPath.StartsWith(resourcesPath))
                {
                    string selectionExt = System.IO.Path.GetExtension(selectionPath);
                    if (selectionExt.Length == 0)
                    {
                        continue;
                    }

                    // 从路径"Assets/Resources/UI/testUI.png"得到路径"UI/testUI"
                    string loadPath = selectionPath.Remove(selectionPath.Length - selectionExt.Length);
                    loadPath = loadPath.Substring(resourcesPath.Length);

                    // 加载此文件下的所有资源
                    Sprite[] sprites = Resources.LoadAll<Sprite>(loadPath);
                    if (sprites.Length > 0)
                    {
                        // 创建导出文件夹
                        string outPath = Application.dataPath + "/outSprite/" + loadPath;
                        System.IO.Directory.CreateDirectory(outPath);

                        foreach (Sprite sprite in sprites)
                        {
                            // 创建单独的纹理
                            Texture2D tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                            tex.SetPixels(sprite.texture.GetPixels((int)sprite.rect.xMin, (int)sprite.rect.yMin,
                                (int)sprite.rect.width, (int)sprite.rect.height));
                            tex.Apply();

                            // 写入成PNG文件
                            System.IO.File.WriteAllBytes(outPath + "/" + sprite.name + ".png", tex.EncodeToPNG());
                        }
                        Debug.Log("SaveSprite to " + outPath);
                    }
                }
            }
            Debug.Log("SaveSprite Finished");
        }
        [MenuItem("Tools/导出单个切割图片")]
        static void SaveSingleSprite()
        {
            string resourcesPath = "Assets/Resources/";
            foreach (Object obj in Selection.objects)
            {
                string selectionPath = AssetDatabase.GetAssetPath(obj);

                // 必须最上级是"Assets/Resources/"
                if (selectionPath.StartsWith(resourcesPath))
                {
                    string selectionExt = System.IO.Path.GetExtension(selectionPath);
                    if (selectionExt.Length == 0)
                    {
                        continue;
                    }

                    // 从路径"Assets/Resources/UI/testUI.png"得到路径"UI/testUI"
                    string loadPath = selectionPath.Remove(selectionPath.Length - selectionExt.Length);
                    loadPath = loadPath.Substring(resourcesPath.Length);

                    // 加载此文件下的所有资源
                    Sprite[] sprites = Resources.LoadAll<Sprite>(loadPath);
                    if (sprites.Length > 0)
                    {
                        // 创建导出文件夹
                        string outPath = Application.dataPath + "/outSprite/" + loadPath;
                        System.IO.Directory.CreateDirectory(outPath);

                        foreach (Sprite sprite in sprites)
                        {
                            // 创建单独的纹理
                            Texture2D tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
                            tex.SetPixels(sprite.texture.GetPixels((int)sprite.rect.xMin, (int)sprite.rect.yMin,
                                (int)sprite.rect.width, (int)sprite.rect.height));
                            tex.Apply();

                            // 写入成PNG文件
                            System.IO.File.WriteAllBytes(outPath + "/" + sprite.name + ".png", tex.EncodeToPNG());
                        }
                        Debug.Log("SaveSprite to " + outPath);
                    }
                }
                else
                {
                    Debug.LogError("Not in Resources folder!");
                }
            }
            Debug.Log("SaveSprite Finished");
        }
    }
    public class SetTextureInfo : EditorWindow
    {
        /// <summary>
        /// 循环设置选择的图片
        /// </summary>
        [MenuItem("Tools/设置图片属性")]
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
                    texImporter.spritePixelsPerUnit = 16;
                    texImporter.spriteImportMode = SpriteImportMode.Single;
                    texImporter.filterMode = FilterMode.Point;

                    ////修改Aniso Level
                    //texImporter.anisoLevel = 0;
                    ////修改Read/Write enabled 
                    texImporter.isReadable = true;
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
