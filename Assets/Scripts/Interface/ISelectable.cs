using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Interface
{
    public interface ISelectable
    {
        public bool IsSelected { get; set; }
        public void OnSelect();
        public void OnUnselect();
        public bool IsSelectedOnly { get; }
    }
}
