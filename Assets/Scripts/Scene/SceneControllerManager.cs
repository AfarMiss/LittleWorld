using LittleWorld.Interface;
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
    public SceneEnum startingSceneName;


    public void TryChangeScene(string sceneName, Vector3 spawnPos)
    {
        if (!isFading)
        {
            StartCoroutine(ChangeScene(sceneName, spawnPos));
        }
    }

    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;

        faderCanvasGroup.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        isFading = false;
        faderCanvasGroup.blocksRaycasts = false;
    }

    private IEnumerator LoadActiveScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    private IEnumerator ChangeScene(string sceneName, Vector3 spawnPos)
    {
        EventCenter.Instance.Trigger(EventEnum.BEFORE_FADE_OUT.ToString());

        yield return StartCoroutine(Fade(1f));

        SaveLoadManager.Instance.StoreCurrentSceneData();

        EventCenter.Instance.Trigger(EventEnum.BEFORE_SCENE_UNLOAD.ToString());

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return StartCoroutine(LoadActiveScene(sceneName));

        EventCenter.Instance.Trigger(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString());

        SaveLoadManager.Instance.RestoreCurrentSceneData();

        yield return StartCoroutine(Fade(0f));

        EventCenter.Instance.Trigger(EventEnum.AFTER_FADE_IN.ToString());

    }

    private IEnumerator Start()
    {
        faderImage.color = new Color(0f, 0f, 0f, 1f);
        faderCanvasGroup.alpha = 1f;

        yield return StartCoroutine(LoadActiveScene(startingSceneName.ToString()));

        EventCenter.Instance.Trigger(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString());

        SaveLoadManager.Instance.RestoreCurrentSceneData();

        StartCoroutine(Fade(0f));
    }

    [ContextMenu("LoadFarm")]
    public void LoadFarm()
    {
        var curPlayerPoint = GameObject.FindGameObjectWithTag(Tags.PlayerRespawnPoint);
        SceneControllerManager.Instance.TryChangeScene(SceneEnum.Scene1_Farm.ToString(), curPlayerPoint.transform.position);
    }
}
