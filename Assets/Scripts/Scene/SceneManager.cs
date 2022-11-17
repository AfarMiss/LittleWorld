using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControllerManager : MonoSingleton<SceneControllerManager>
{
    private bool isFading;
    [SerializeField] public float fadeDuration;
    [SerializeField] private CanvasGroup faderCanvasGroup = null;
    [SerializeField] private Image faderImage;
    public SceneName startingSceneName;


    public void FadeAndLoadScene(string sceneName, Vector3 spawnPos)
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndSwitchScene(sceneName, spawnPos));
        }
    }

    private IEnumerator FadeAndSwitchScene(string sceneName, Vector3 spawnPos)
    {
        EventCenter.Instance.Trigger(EventEnum.BEFORE_FADE_OUT.ToString());

        yield return StartCoroutine(Fade(1f));
        FarmPlayer.Instance.gameObject.transform.position = spawnPos;

        EventCenter.Instance.Trigger(EventEnum.BEFORE_SCENE_UNLOAD.ToString());

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));

        EventCenter.Instance.Trigger(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString());

        yield return StartCoroutine(Fade(0f));

        EventCenter.Instance.Trigger(EventEnum.AFTER_FADE_IN.ToString());



    }
}
