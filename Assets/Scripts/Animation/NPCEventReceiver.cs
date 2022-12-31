using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEventReceiver : MonoBehaviour
{
    private void AnimationEventPlayFootstepSound()
    {
        AudioManager.Instance.PlaySound(SoundName.effectFootstepHardGround);
    }
}
