using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    /// <summary>
    /// 动态物体渲染追踪器
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class PathTracerRender : MonoBehaviour
    {
        private Animal animal;
        private Vector3 imageOffset = new Vector3(0.5f, 0.5f);
        [HideInInspector] public LineRenderer pathRender;

        private void Awake()
        {
            pathRender = GetComponent<LineRenderer>();
        }

        public void Init(Animal animal)
        {
            this.animal = animal;
        }

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

        private void FixedUpdate()
        {
            DrawLine(animal.PathTracer);
        }

        private void DrawLine(PathTracer pathTracer)
        {
            var path = pathTracer.CurPathInfo.curPath;
            pathRender.enabled = !pathTracer.atDestination && pathTracer.showPath;
            if (path == null || !pathTracer.showPath)
            {
                return;
            }
            var pathArray = path.ToArray();
            pathRender.positionCount = pathArray.Length + 2;
            pathRender.SetPosition(0, RenderPos.To3() + imageOffset);
            if (pathTracer.CurStepTarget != null)
            {
                pathRender.SetPosition(1, new Vector3(pathTracer.CurStepTarget.Value.x, pathTracer.CurStepTarget.Value.y, 0) + imageOffset);
                for (int i = 0; i < path.Count; i++)
                {
                    pathRender.SetPosition(i + 2, new Vector3(pathArray[i].x, pathArray[i].y, 0) + imageOffset);
                }
            }
            else
            {
                for (int i = 0; i < path.Count; i++)
                {
                    pathRender.SetPosition(i + 1, new Vector3(pathArray[i].x, pathArray[i].y, 0) + imageOffset);
                }
            }

            pathRender.startColor = new Color(1, 1, 1, 0.3f);
            pathRender.endColor = new Color(1, 1, 1, 0.3f);
        }

    }
}
