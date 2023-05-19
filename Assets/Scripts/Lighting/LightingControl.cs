using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingControl : MonoBehaviour
{
    [SerializeField] private LightingSchedule lightingSchedule;
    [SerializeField] private bool isLightFlicker = false;
    [SerializeField][Range(0f, 1f)] private float lightFlickerIntensity;
    [SerializeField][Range(0f, 0.2f)] private float lightFlickerTimeMin;
    [SerializeField][Range(0f, 0.2f)] private float lightFlickerTimeMax;

    private Light2D light2D;
    private Dictionary<string, float> lightingBrightnessDictionary = new Dictionary<string, float>();
    private float currentLightIntensity;
    private float lightFlickerTimer = 0f;
    private Coroutine fadeInLightRoutine;

    private void Awake()
    {
        light2D = GetComponentInChildren<Light2D>();

        if (light2D == null)
            enabled = false;

        foreach (LightingBrightness lightingBrightness in lightingSchedule.lightingBrightnesses)
        {
            string key = lightingBrightness.quarter.ToString() + "_" + lightingBrightness.hour.ToString();
            lightingBrightnessDictionary.Add(key, lightingBrightness.lightIntensity);
        }
    }

    private void OnEnable()
    {
        EventCenter.Instance.Register<GameTime>(EventName.HOUR_CHANGE, OnHourChange, this);
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded, this);
    }

    private void OnSceneLoaded()
    {
        int quarter = TimeManager.Instance.CurGameTime.quad;
        int hour = TimeManager.Instance.CurGameTime.hour;

        SetLightingIntensity(quarter, hour, false);
    }

    private void SetLightingIntensity(int quarter, int hour, bool fadeIn)
    {
        int i = 0;
        while (i < 23)
        {
            string key = quarter.ToString() + "_" + hour.ToString();
            if (lightingBrightnessDictionary.TryGetValue(key, out float targetLightingIntensity))
            {
                if (fadeIn)
                {
                    if (fadeInLightRoutine != null)
                    {
                        StopCoroutine(fadeInLightRoutine);
                    }
                    fadeInLightRoutine = StartCoroutine(FadeInLightRoutine(targetLightingIntensity));
                }
                else
                {
                    currentLightIntensity = targetLightingIntensity;
                }
                break;
            }
            i++;
            hour--;
            if (hour < 0)
            {
                hour = 23;
            }
        }
    }

    private IEnumerator FadeInLightRoutine(float targetLightingIntensity)
    {
        float fadeDuration = 5f;

        float fadeSpeed = MathF.Abs(currentLightIntensity - targetLightingIntensity) / fadeDuration;

        while (MathF.Abs(currentLightIntensity - targetLightingIntensity) > 0.01f)
        {
            currentLightIntensity = Mathf.MoveTowards(currentLightIntensity, targetLightingIntensity, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        currentLightIntensity = targetLightingIntensity;
    }

    private void OnHourChange(GameTime arg0)
    {
        SetLightingIntensity(arg0.quad, arg0.hour, true);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<GameTime>(EventName.HOUR_CHANGE, OnHourChange);
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
    }

    private void Update()
    {
        if (isLightFlicker)
        {
            lightFlickerTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (lightFlickerTimer <= 0f && isLightFlicker)
        {
            LightFlicker();
        }
        else
        {
            light2D.intensity = currentLightIntensity;
        }
    }

    private void LightFlicker()
    {
        light2D.intensity = UnityEngine.Random.Range(currentLightIntensity, currentLightIntensity + currentLightIntensity * lightFlickerIntensity);
    }
}
