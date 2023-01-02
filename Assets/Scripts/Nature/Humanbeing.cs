using LittleWorldObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        public void Pick(Brush brush)
        {
            var navi = GetComponent<PathNavigationOnly>();
            navi.AddMovePositionAndMove(brush.transform.position);
        }
    }
}