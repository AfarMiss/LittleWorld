using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class MaterialDatabase : MonoSingleton<MaterialDatabase>
    {
        /// <summary>
        /// 种植区Material
        /// </summary>
        public Material[] PlantZoomMaterials;
        /// <summary>
        /// 选择种植区时的Material
        /// </summary>
        public Material selectMaterial;
    }
}
