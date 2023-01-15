using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObscuringItemFader : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderers;

    private void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// 淡入
    /// </summary>
    public void FadeIn()
    {
        foreach (var item in spriteRenderers)
        {
            StartCoroutine(FadeInRoutine(item));
        }
    }

    /// <summary>
    /// 淡出
    /// </summary>
    public void FadeOut()
    {
        foreach (var item in spriteRenderers)
        {
            StartCoroutine(FadeOutRoutine(item));
        }
    }

    private IEnumerator FadeOutRoutine(SpriteRenderer spriteRenderer)
    {
        var curAlpha = spriteRenderer.color.a;
        var fadeOutVelocity = (1 - FarmSetting.targetAlpha) / FarmSetting.fadeOutSeconds;
        while (curAlpha - FarmSetting.targetAlpha > 0.01f)
        {
            curAlpha -= fadeOutVelocity;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, curAlpha);
            yield return null;
        }
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, FarmSetting.targetAlpha);
    }

    private IEnumerator FadeInRoutine(SpriteRenderer spriteRenderer)
    {
        var curAlpha = spriteRenderer.color.a;
        var fadeInVelocity = (1 - FarmSetting.targetAlpha) / FarmSetting.fadeInSeconds;
        while (1 - curAlpha > 0.01f)
        {
            curAlpha += fadeInVelocity;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, curAlpha);
            yield return null;
        }
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    }
}
