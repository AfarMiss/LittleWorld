using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Callbacks;
using UniBase.NodeEditor;
using UnityEditor.MPE;
using System;

namespace UniBase.Editor.NodeEditor
{
    public class RoomNodeGraphEditor : EditorWindow
    {
        private GUIStyle roomNodeStyle;
        private static RoomNodeGraphSO currentRoomNodeGraph;
        private RoomNodeTypeListSO roomNodeTypeList;

        private const float nodeWidth = 160f;
        private const float nodeHeight = 75f;
        private const int nodePadding = 25;
        private const int nodeBorder = 12;

        [MenuItem("Room Node Graph Editor", menuItem = "Tools/Dungeon Editor/Room Node Graph Editor")]
        private static void OpenWindow()
        {
            GetWindow<RoomNodeGraphEditor>("RoomNodeGraphEditor");
        }

        [OnOpenAsset(0)]
        public static bool OnDoubleClickAsset(int instanceID, int line)
        {
            RoomNodeGraphSO roomNodeGraph = EditorUtility.InstanceIDToObject(instanceID) as RoomNodeGraphSO;
            if (roomNodeGraph != null)
            {
                OpenWindow();
                currentRoomNodeGraph = roomNodeGraph;
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            roomNodeStyle = new GUIStyle();
            roomNodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;
            roomNodeStyle.normal.textColor = Color.white;
            roomNodeStyle.padding = new RectOffset(nodePadding, nodePadding, nodePadding, nodePadding);
            roomNodeStyle.border = new RectOffset(nodeBorder, nodeBorder, nodeBorder, nodeBorder);

            roomNodeTypeList = GameResources.Instance.roomNodeTypeList;
        }

        private void OnGUI()
        {
            if (currentRoomNodeGraph != null)
            {
                ProcessEvents(Event.current);

                DrawRoomNodes();
            }

            if (GUI.changed)
            {
                Repaint();
            }
            //GUILayout.BeginArea(new Rect(new Vector2(100f, 100f), new Vector2(nodeWidth, nodeHeight)), roomNodeStyle);
            //EditorGUILayout.LabelField("Node 1");
            //GUILayout.EndArea();

            //GUILayout.BeginArea(new Rect(new Vector2(300f, 300f), new Vector2(nodeWidth, nodeHeight)), roomNodeStyle);
            //EditorGUILayout.LabelField("Node 2");
            //GUILayout.EndArea();
        }

        private void ProcessEvents(Event current)
        {
            ProcessRoomNodeGraphEvents(current);
        }

        private void ProcessRoomNodeGraphEvents(Event current)
        {

            switch (current.type)
            {
                case EventType.MouseDown:
                    ProcessMouseDownEvent(current);
                    break;
                default:
                    break;
            }
        }

        private void ProcessMouseDownEvent(Event current)
        {
            if (current.button == 1)
            {
                ShowContextMenu(current.mousePosition);
            }
        }

        private void ShowContextMenu(Vector2 mousePosition)
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Create Room Node"), false, CreateRoomNode, mousePosition);
            menu.ShowAsContext();
        }

        private void CreateRoomNode(object mousePositionObject)
        {
            CreateRoomNode(mousePositionObject, roomNodeTypeList.list.Find(x => x.isNone));
        }

        private void CreateRoomNode(object mousePositionObject, RoomNodeTypeSO roomNodeTypeSO)
        {
            Vector2 mousePosition = (Vector2)mousePositionObject;
            RoomNodeSO roomNode = ScriptableObject.CreateInstance<RoomNodeSO>();
            currentRoomNodeGraph.roomNodeList.Add(roomNode);
            roomNode.Initialise(new Rect(mousePosition, new Vector2(nodeWidth, nodeHeight)), currentRoomNodeGraph, roomNodeTypeSO);
            AssetDatabase.AddObjectToAsset(roomNode, currentRoomNodeGraph);
            AssetDatabase.SaveAssets();
        }

        private void DrawRoomNodes()
        {
            foreach (RoomNodeSO item in currentRoomNodeGraph.roomNodeList)
            {
                item.Draw(roomNodeStyle);
            }

            GUI.changed = true;
        }
    }
}
