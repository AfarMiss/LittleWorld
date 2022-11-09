using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlayer : MonoSingleton<FarmPlayer>
{
    public SpriteRenderer EquipRenderer => equipRenderer;
    [SerializeField] private SpriteRenderer equipRenderer;
}
