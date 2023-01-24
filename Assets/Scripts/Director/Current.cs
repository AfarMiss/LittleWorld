using UniBase;
using UnityEngine;

namespace LittleWorld
{
    /// <summary>
    /// 当前环境下的静态变量
    /// </summary>
    public static class Current
    {
        public static Vector2 MousePos => InputUtils.GetMousePosition();

        public static bool IsAdditionalMode => InputController.Instance.AdditionalAction;

        public static TileManager TileManager => TileManager.Instance;

        public static Rect ScreenSelectionArea => InputController.Instance.ScreenSelectionArea;
    }
}
