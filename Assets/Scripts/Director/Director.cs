using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoSingleton<Director>
{
    public FarmPlayer GetPlayer()
    {
        return FindObjectOfType<FarmPlayer>();
    }
}
