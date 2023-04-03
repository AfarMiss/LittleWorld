using LittleWorld.Item;
using SRF;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnManager : Singleton<PawnManager>
{
    public int AlivePawnsCount
    {
        get
        {
            var result = 0;
            foreach (var item in SceneObjectManager.Instance.WorldObjects)
            {
                if (item.Value is Humanbeing humanbeing && !humanbeing.IsDead)
                {
                    result++;
                }
            }
            return result;
        }
    }
    private PawnManager()
    {
    }

    public IEnumerable<Humanbeing> Pawns()
    {
        foreach (var item in SceneObjectManager.Instance.WorldObjects)
        {
            if (item.Value is Humanbeing humanbeing)
            {
                yield return humanbeing;
            }
        }
    }

}
