using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Extension
{
    public static class EnumExtensions
    {

        public static int ToInt(this System.Enum e)
        {
            return e.GetHashCode();
        }
    }
}
