using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            //Debug.Log($"dirmousePosition:{mousePosition}");
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

    public static class OverlapHelper
    {
        /// <summary>
        /// 判断矩形范围内是否含有T类型组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listComponentsAtBoxPosition"></param>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static bool GetComponentsAtBoxLocation<T>(out List<T> listComponentsAtBoxPosition, Vector2 point, Vector2 size, float angle)
        {
            bool found = false;
            List<T> listComponents = new List<T>();

            Collider2D[] colliders = Physics2D.OverlapBoxAll(point, size, angle);

            for (int i = 0; i < colliders.Length; i++)
            {
                //我认为这一段中两个Add有可能重复添加同一个组件
                T tComponent = colliders[i].gameObject.GetComponentInParent<T>();
                if (tComponent != null)
                {
                    found = true;
                    listComponents.Add(tComponent);
                }
                else
                {
                    tComponent = colliders[i].gameObject.GetComponentInChildren<T>();
                    if (tComponent != null)
                    {
                        found = true;
                        listComponents.Add(tComponent);
                    }
                }
            }

            listComponentsAtBoxPosition = listComponents;

            return found;
        }

        /// <summary>
        /// 判断矩形范围内是否含有T类型组件(不分配内存)
        /// 不分配内存而使用自己指定的变量会产生有效数据居中，而两边数据为null的情况。
        /// 如给予一个长度为5的数组存储数据，那么获得的结果有可能为{null,4,null,null,null}，有效数据只有一个，且下标为1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numberOfCollidersToTest"></param>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static T[] GetComponentsAtBoxLocationNonAlloc<T>(int numberOfCollidersToTest, Vector2 point, Vector2 size, float angle)
        {
            Collider2D[] collider2DArray = new Collider2D[numberOfCollidersToTest];
            Physics2D.OverlapBoxNonAlloc(point, size, angle, collider2DArray);

            T tComponent = default(T);

            T[] componentArray = new T[collider2DArray.Length];

            for (int i = collider2DArray.Length - 1; i >= 0; i--)
            {
                if (collider2DArray[i] != null)
                {
                    tComponent = collider2DArray[i].gameObject.GetComponentInParent<T>();
                    if (tComponent != null)
                    {
                        componentArray[i] = tComponent;
                    }
                }
            }

            return componentArray;
        }

        /// <summary>
        /// 判断鼠标点位置是否含有T类型组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentsAtPositionList"></param>
        /// <param name="positionToCheck"></param>
        /// <returns></returns>
        public static bool GetComponentsAtCursorLocation<T>(out List<T> componentsAtPositionList, Vector3 positionToCheck)
        {
            bool found = false;

            List<T> componentList = new List<T>();

            Collider2D[] collider2DArray = Physics2D.OverlapPointAll(positionToCheck);
            T tComponent = default(T);

            for (int i = 0; i < collider2DArray.Length; i++)
            {
                tComponent = collider2DArray[i].gameObject.GetComponentInParent<T>();
                if (tComponent != null)
                {
                    found = true;
                    componentList.Add(tComponent);
                }
                else
                {
                    tComponent = collider2DArray[i].gameObject.GetComponentInChildren<T>();
                    if (tComponent != null)
                    {
                        found = true;
                        componentList.Add(tComponent);
                    }
                }
            }

            componentsAtPositionList = componentList;

            return found;
        }
    }

    public static class TaskHelper
    {
        /// <summary>
        /// 等待bool条件达成
        /// </summary>
        /// <param name="func">条件函数</param>
        /// <returns></returns>
        public static async Task<bool> Wait(Func<bool> func)
        {
            try
            {
                if (func == null) return false;
                while (!func.Invoke())
                {
                    //Debug.Log("条件未达成!");
                    await Task.Delay(1000);
                }
                //Debug.Log("条件达成!");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                throw;
            }
        }
    }
}
