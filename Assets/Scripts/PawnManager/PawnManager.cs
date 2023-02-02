using LittleWorld.Item;
using SRF;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnManager : Singleton<PawnManager>
{
    private PawnManager()
    {
    }

    public List<Humanbeing> Pawns
    {
        get
        {
            var result = new List<Humanbeing>();
            foreach (var item in SceneObjectManager.Instance.WorldObjects)
            {
                if (item.Value is Humanbeing)
                {
                    result.Add(item.Value as Humanbeing);
                }
            }
            return result;
        }
    }
}
