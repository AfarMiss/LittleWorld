/// <summary>
/// 角色属性
/// </summary>
[System.Serializable]
public struct CharacterAttribute
{
    /// <summary>
    /// 身体部位
    /// </summary>
    public CharacterPartAnimator characterPart;
    /// <summary>
    /// 部位颜色
    /// </summary>
    public PartVariantColour partVariantColour;
    /// <summary>
    /// 动画类型
    /// </summary>
    public PartVariantType partVariantType;

    public CharacterAttribute(CharacterPartAnimator characterPart, PartVariantColour partVariantColour, PartVariantType partVariantType)
    {
        this.characterPart = characterPart;
        this.partVariantColour = partVariantColour;
        this.partVariantType = partVariantType;
    }
}
