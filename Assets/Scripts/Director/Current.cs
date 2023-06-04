using LittleWorld.MapUtility;
using UniBase;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace LittleWorld
{
    /// <summary>
    /// 当前环境下的静态变量
    /// </summary>
    public static class Current
    {
        public static MouseState MouseState
        {
            get
            {
                return InputController.Instance.MouseState;
            }
            set
            {
                InputController.Instance.MouseState = value;
            }
        }
        public static Vector2 MousePos => InputUtils.GetMousePosition();

        public static bool IsAdditionalMode => InputController.Instance.AdditionalAction;

        public static TileManager TileManager => TileManager.Instance;

        public static Rect ScreenSelectionArea => InputController.Instance.ScreenSelectionArea;

        public static Map CurMap => MapManager.Instance.curDisplayMap;

        public static Game CurGame;

        public static void Hint(string hintContent)
        {
            CurGame.Hint(hintContent);
        }
    }
}
