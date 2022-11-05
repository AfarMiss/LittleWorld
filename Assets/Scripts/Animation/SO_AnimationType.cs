using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "so_AnimationType", menuName = "Scriptable Object/Animation/Animation Type")]
public class SO_AnimationType : ScriptableObject
{
    /// <summary>
    /// 动画clip
    /// </summary>
    public Animation animationClip;
    public AnimationName animationName;
    public AnimationPartAnimator characterPart;
    public PartVariantColour partVariantColour;
    public PartVariantType partVariantType;
}
