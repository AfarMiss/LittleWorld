using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UniBase
{
    public static class InputUtils
    {
        public static Vector3 GetMouseWorldPosition()
        {
#if ENABLE_INPUT_SYSTEM
            Vector2 mousePosition = Mouse.current.position.ReadValue();
#else
            Vector2 mousePosition=Input.mousePosition;
#endif
            var result = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log($"GetMouseWorldPosition:{result}");
            return result;
        }

        public static Vector3 GetMouseWorldPositionFixedZ(float z = 0)
        {
#if ENABLE_INPUT_SYSTEM
            Vector2 mousePosition = Mouse.current.position.ReadValue();
#else
            Vector2 mousePosition=Input.mousePosition;
#endif
            var result = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log($"GetMouseWorldPosition:{result}");
            return new Vector3(result.x, result.y, z);
        }

        public static Vector3 GetMousePosition()
        {
#if ENABLE_INPUT_SYSTEM
            Vector2 mousePosition = Mouse.current.position.ReadValue();
#else
            Vector2 mousePosition=Input.mousePosition;
#endif
            return mousePosition;
        }

        public static Vector3 GetScreenPosition(this Vector3 worldPos)
        {
            if (Camera.main == null)
            {
                Debug.LogError("Main Camera is null!");
                return Vector3.zero;
            }
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPos);
            return screenPoint;
        }

        public static bool OverlapBound(this Rect a, Bounds b)
        {
            var minPoint = Camera.main.WorldToScreenPoint(b.min);
            var maxPoint = Camera.main.WorldToScreenPoint(b.max);
            var Rectb = new Rect(minPoint, maxPoint - minPoint);

            return a.Overlaps(Rectb);
        }

        public static Vector3 GetMousePositionToWorldWithSameZ(this Vector3 a)
        {
#if ENABLE_INPUT_SYSTEM
            Vector2 mousePosition = Mouse.current.position.ReadValue();
#else
            Vector2 mousePosition=Input.mousePosition;
#endif
            var result = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log($"GetMouseWorldPosition:{result}");
            return new Vector3(result.x, result.y, a.z);
        }

        public static Vector3 GetMousePositionToWorldWithSpecificZ(float z)
        {
#if ENABLE_INPUT_SYSTEM
            Vector2 mousePosition = Mouse.current.position.ReadValue();
#else
            Vector2 mousePosition=Input.mousePosition;
#endif
            var result = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log($"GetMouseWorldPosition:{result}");
            return new Vector3(result.x, result.y, z);
        }

        public static List<Vector3> GetLinearDestinations(Vector3 originalDestination, int count, float interval)
        {
            var result = new List<Vector3>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Vector3(originalDestination.x + interval * i, originalDestination.y, originalDestination.z));
            }
            return result;
        }
    }


}
