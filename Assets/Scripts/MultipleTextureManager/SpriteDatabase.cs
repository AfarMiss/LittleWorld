using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultipleTxture
{
    [CreateAssetMenu(fileName = "SpriteDatabase", menuName = "ScriptableObject/SpriteDatabase")]
    public class SpriteDatabase : ScriptableObject
    {
        public List<SpriteDetail> textureDetailList;

        public Sprite Get(string terrainName)
        {
            var item = textureDetailList.Find(x => x.spriteName == terrainName);
            if (item == null)
            {
                return null;
            }
            var itemSprite = item.sprite;
            if (itemSprite == null)
            {
                return null;
            }
            return itemSprite;
        }
    }
}
