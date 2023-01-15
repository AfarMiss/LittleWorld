/* 使用 GUIContent 来显示图像、字符串和工具提示 */
using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour
{
    public Texture2D icon;

    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 100, 20), new GUIContent("Click me", icon, "This is the tooltip"));
        GUI.Label(new Rect(10, 40, 100, 20), GUI.tooltip);
    }
}