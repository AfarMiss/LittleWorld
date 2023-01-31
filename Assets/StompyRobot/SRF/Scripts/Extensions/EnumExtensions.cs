using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Littleworld.Extension
{
    public static class EnumExtensions
    {

        public static int ToInt(this System.Enum e)
        {
            return e.GetHashCode();
        }
    }
}
