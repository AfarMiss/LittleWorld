using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public interface IObjectRender
    {
        public abstract Sprite GetSprite(int itemCode, string importerPath);
    }
}
