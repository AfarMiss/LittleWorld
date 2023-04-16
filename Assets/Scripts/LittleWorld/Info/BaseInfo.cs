using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace LittleWorld.Item
{
    public class BaseInfo
    {
        public int itemCode;
        public string itemName;
        public int maxPileCount;
        public bool isBlock = false;
        public string imagesPath;
        public Sprite[] ItemSprites
        {
            get
            {
                if (itemSprites == null)
                {
                    itemSprites = CreateItemSpritesList(imagesPath);
                }
                return itemSprites;
            }
        }

        private Sprite[] itemSprites;

        public Sprite defaultSprite => ItemSprites[0];
        public bool CanPile => maxPileCount > 0;

        private static Sprite[] CreateItemSpritesList(string imagesPath)
        {
            var splits = imagesPath.Split(',');
            var sprites = new List<Sprite>();
            foreach (var loadPath in splits)
            {
                if (!string.IsNullOrEmpty(loadPath))
                {
                    var actualLoadPath = loadPath;
                    if (string.IsNullOrEmpty(loadPath))
                    {
                        continue;
                    }
                    var prefix = "Assets/Resources/";
                    if (loadPath.StartsWith(prefix))
                    {
                        actualLoadPath = loadPath.Substring(prefix.Length);
                    }
                    string selectionExt = System.IO.Path.GetExtension(loadPath);
                    if (selectionExt.Length != 0)
                    {
                        actualLoadPath = loadPath.Remove(loadPath.Length - selectionExt.Length);
                    }
                    var curSprite = Resources.Load<Sprite>(actualLoadPath);
                    if (curSprite != null)
                    {
                        sprites.Add(curSprite);
                    }
                    else
                    {
                        Debug.LogError($"路径{loadPath}加载图片为空，请检查路径。");
                    }
                }
            }
            return sprites.ToArray();
        }
    }
}
