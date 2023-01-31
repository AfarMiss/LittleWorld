using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Holder : MonoBehaviour
    {
        public bool hasDiamond => transform.childCount > 0;
    }
}
