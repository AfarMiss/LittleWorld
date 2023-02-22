using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace UniBase.NodeEditor
{
    public class RoomNodeSO : ScriptableObject
    {
        [HideInInspector] public string id;
        [HideInInspector] public List<string> parentRoomNodeIDList = new List<string>();
        [HideInInspector] public List<string> childRoomNodeIDList = new List<string>();
        [HideInInspector] public RoomNodeGraphSO roomNodeGraph;
        public RoomNodeTypeSO roomNodeType;
        [HideInInspector] public RoomNodeTypeListSO roomNodeTypeList;

        #region EditorCode
#if UNITY_EDITOR
        [HideInInspector] public Rect rect;
        [HideInInspector] public bool isLeftClickDragging = false;
        [HideInInspector] public bool isSelected = false;

        public void Initialise(Rect rect, RoomNodeGraphSO currentRoomNodeGraph, RoomNodeTypeSO roomNodeTypeSO)
        {
            this.rect = rect;
            this.id = Guid.NewGuid().ToString();
            this.name = "RoomNode";
            this.roomNodeGraph = currentRoomNodeGraph;
            this.roomNodeType = roomNodeTypeSO;

            roomNodeTypeList = GameResources.Instance.roomNodeTypeList;
        }

        public void Draw(GUIStyle roomNodeStyle)
        {
            GUILayout.BeginArea(rect, roomNodeStyle);
            EditorGUI.BeginChangeCheck();
            int selected = roomNodeTypeList.list.FindIndex(x => x == roomNodeType);
            int selection = EditorGUILayout.Popup("", selected, GetRoomNodeTypesToDisplay());
            roomNodeType = roomNodeTypeList.list[selection];
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(this);
            }

            GUILayout.EndArea();

        }

        private string[] GetRoomNodeTypesToDisplay()
        {
            string[] roomArray = new string[roomNodeTypeList.list.Count];
            for (int i = 0; i < roomNodeTypeList.list.Count; i++)
            {
                if (roomNodeTypeList.list[i].displayInNodeGraphEditor)
                {
                    roomArray[i] = roomNodeTypeList.list[i].roomNodeTypeName;
                }
            }

            return roomArray;
        }

        public void ProcessEvents(Event current)
        {
            switch (current.type)
            {
                case EventType.MouseDown:
                    ProcessMouseDownEvent(current);
                    break;
                case EventType.MouseUp:
                    ProcessMouseUpEvent(current);
                    break;
                case EventType.MouseDrag:
                    ProcessMouseDragEvent(current);
                    break;
                default:
                    break;
            }
        }

        private void ProcessMouseDragEvent(Event current)
        {
            if (current.button == 0)
            {
                ProcessLeftClickDragEvent(current);
            }
        }

        private void ProcessLeftClickDragEvent(Event current)
        {
            isLeftClickDragging = true;
            DragNode(current.delta);
            GUI.changed = true;
        }

        private void DragNode(Vector2 delta)
        {
            rect.position += delta;
            EditorUtility.SetDirty(this);
        }

        private void ProcessMouseUpEvent(Event current)
        {
            if (current.button == 0)
            {
                ProcessLeftClickUpEvent(current);
            }
        }

        private void ProcessLeftClickUpEvent(Event current)
        {
            isLeftClickDragging = false;
        }

        private void ProcessMouseDownEvent(Event current)
        {
            if (current.button == 0)
            {
                ProcessLeftClickDownEvent(current);
            }
        }

        private void ProcessLeftClickDownEvent(Event current)
        {
            Selection.activeObject = this;
            isSelected = !isSelected;
        }

#endif
        #endregion

    }
}
