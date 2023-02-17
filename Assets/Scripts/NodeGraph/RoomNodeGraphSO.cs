using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniBase.NodeEditor
{
    [CreateAssetMenu(fileName = "RoomNodeGraph", menuName = "Scriptable Object/Dungeon/Room Node Graph")]
    public class RoomNodeGraphSO : ScriptableObject
    {
        [HideInInspector] public RoomNodeTypeListSO roomNodeTypeList;
        [HideInInspector] public List<RoomNodeSO> roomNodeList;
        [HideInInspector] public Dictionary<string, RoomNodeSO> roomNodeDictionary;
    }
}
