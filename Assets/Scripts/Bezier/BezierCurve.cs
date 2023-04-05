using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BezierHelper
{
    public class BezierCurve : MonoBehaviour
    {
        public Transform startPoint;
        public Transform endPoint;

        private Vector3[] points = new Vector3[4];
        //private Vector3 currentTargetPosition;
        private List<Vector3> drawPoints;

        private void Start()
        {
            drawPoints = new List<Vector3>();
        }

        private void OnDrawGizmos()
        {
            foreach (var item in points)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(item, Vector3.one);
            }
        }

        private void Update()
        {
            UpdateLine();
        }

        private void UpdateLine()
        {
            drawPoints.Clear();
            points[0] = startPoint.position;
            points[1] = startPoint.position + Vector3.up * 5f;
            points[2] = endPoint.position + Vector3.down * 5f;
            points[3] = endPoint.position;

            DrawCurve();
            GetComponent<LineRenderer>().positionCount = drawPoints.Count;
            GetComponent<LineRenderer>().SetPositions(drawPoints.ToArray());

        }

        private void DrawCurve()
        {
            // 绘制曲线
            for (float t = 0f; t <= 1f; t += 0.03f)
            {
                drawPoints.Add(CalculateBezierPoint(t, points));
            }
        }

        private Vector3 CalculateBezierPoint(float t, Vector3[] points)
        {
            int n = points.Length - 1;
            Vector3 point = Vector3.zero;

            for (int i = 0; i <= n; i++)
            {
                float factor = BinomialCoefficient(n, i) * Mathf.Pow(1 - t, n - i) * Mathf.Pow(t, i);
                point += points[i] * factor;
            }

            return point;
        }

        private float BinomialCoefficient(int n, int k)
        {
            float result = 1;

            for (int i = 1; i <= k; i++)
            {
                result *= (n - i + 1.0f) / i;
            }

            return result;
        }
    }

}
