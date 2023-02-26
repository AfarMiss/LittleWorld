using LittleWorld.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Object : ISelectable
    {
        public int itemCode;
        public int instanceID;
        public string ItemName;
        public bool isSelected;

        public bool IsSelected
        {
            get => isSelected;
            set => isSelected = value;
        }

        public void OnSelect()
        {
            isSelected = true;
        }

        public void OnUnselect()
        {
            isSelected = false;
        }

        public bool IsSelectedOnly => InputController.Instance.SelectedObjects.Count == 1 && IsSelected;
    }
}
