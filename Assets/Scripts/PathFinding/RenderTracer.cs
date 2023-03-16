using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    [RequireComponent(typeof(LineRenderer))]
    public class RenderTracer : MonoBehaviour
    {
        public LineRenderer pathRender;
        /// <summary>
        /// 实际指向偏离渲染锚点(-0.5,-0.5)的位置
        /// </summary>
        public Vector2 RenderPos
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = value;
            }
        }
    }
}
