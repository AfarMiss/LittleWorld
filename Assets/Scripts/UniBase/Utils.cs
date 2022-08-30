using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UniBase
{
    public static class Utils
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
    }


}
