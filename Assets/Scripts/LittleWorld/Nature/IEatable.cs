using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public interface IEatable
    {
        bool eatable { get; }
        float nutrition { get; }
        string itemName { get; }
        void Eat();
    }
}
