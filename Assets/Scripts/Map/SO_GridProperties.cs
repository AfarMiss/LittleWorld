using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一整张地图
/// </summary>
[CreateAssetMenu(fileName = "so_GridProperties", menuName = "Scriptable Object/Grid Properties")]
public class SO_GridProperties : ScriptableObject
{
    public SceneEnum sceneName;
    public int gridWidth;
    public int gridHeight;
    public int originX;
    public int originY;

    [SerializeField]
    public List<GridProperty> gridPropertyList;
}
