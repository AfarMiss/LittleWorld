using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画信息
/// </summary>
[CreateAssetMenu(fileName = "so_AnimationType", menuName = "Scriptable Object/Animation/Animation Type")]
public class SO_AnimationType : ScriptableObject
{
    /// <summary>
    /// 动画clip
    /// </summary>
    public AnimationClip animationClip;
    /// <summary>
    /// 动画名称
    /// </summary>
    public AnimationName animationName;
    /// <summary>
    /// 身体部位
    /// </summary>
    public CharacterPartAnimator characterPart;
    /// <summary>
    /// 动画颜色
    /// </summary>
    public PartVariantColour partVariantColour;
    /// <summary>
    /// 动画种类
    /// </summary>
    public PartVariantType partVariantType;

    IEnumerator test()
    {
        yield return null;
    }
}
