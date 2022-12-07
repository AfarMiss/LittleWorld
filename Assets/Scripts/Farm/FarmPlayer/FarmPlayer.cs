using UnityEngine;

public class FarmPlayer : MonoSingleton<FarmPlayer>
{
    public SpriteRenderer EquipRenderer => equipRenderer;
    [SerializeField] private SpriteRenderer equipRenderer;

    public Vector3 GetPlayrCentrePosition()
    {
        return new Vector3(transform.position.x, transform.position.y + FarmSetting.playerCentreYOffset, transform.position.z);
    }
}
