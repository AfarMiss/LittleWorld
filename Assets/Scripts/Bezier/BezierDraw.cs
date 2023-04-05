using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BezierHelper
{

    public class BezierDraw : MonoBehaviour
    {
        public GameObject v0, v1, a0;
        LineRenderer lineRenderer;
        //Vector3 v0, v1;//顶点
        //Vector3 a0;
        float gap = 0.05f;//绘制的0-1的间隙 越小曲线越接近曲线，

        // Update is called once per frame
        void Update()
        {
            for (float i = 0; i < 1; i += gap)
            {
                Debug.DrawLine(po(i, v0, v1, a0), po(i + gap, v0, v1, a0), Color.red);
                Debug.DrawLine(v0.transform.position, a0.transform.position, Color.green);
                Debug.DrawLine(a0.transform.position, v1.transform.position, Color.green);
            }
        }

        private Vector3 po(float t, GameObject v0, GameObject v1, GameObject a0)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点 
        {
            Vector3 a;
            a.x = t * t * (v1.transform.position.x - 2 * a0.transform.position.x + v0.transform.position.x) + v0.transform.position.x + 2 * t * (a0.transform.position.x - v0.transform.position.x);//公式为B(t)=(1-t)^2*v0+2*t*(1-t)*a0+t*t*v1 其中v0为起点 v1为终点 a为中间点 
            a.y = t * t * (v1.transform.position.y - 2 * a0.transform.position.y + v0.transform.position.y) + v0.transform.position.y + 2 * t * (a0.transform.position.y - v0.transform.position.y);
            a.z = t * t * (v1.transform.position.z - 2 * a0.transform.position.z + v0.transform.position.z) + v0.transform.position.z + 2 * t * (a0.transform.position.z - v0.transform.position.z);
            return a;
        }
    }
}
