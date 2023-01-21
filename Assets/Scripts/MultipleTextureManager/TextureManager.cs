using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultipleTxture
{
    public class TextureManager : MonoSingleton<TextureManager>
    {
        [SerializeField]
        private SpriteDatabase database;


        public Sprite GetTerrain(string terrainName)
        {
            return database.Get(terrainName);
        }

    }
}
