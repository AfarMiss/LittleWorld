using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
    GameObject soundPrefab;

    [Header("Audio Source")]
    [SerializeField] private AudioSource ambientSoundAudioSource = null;

    [SerializeField] private AudioSource gameMusicAudioSource = null;

    [Header("Audio Mixers")]
    [SerializeField] private AudioMixer gameAudioMixer = null;

    [Header("Audio Snapshots")]
    [SerializeField] private AudioMixerSnapshot gameMusicSnapshot = null;

    [SerializeField] private AudioMixerSnapshot gameAmbientSnapshot = null;


    private Dictionary<SoundName, SoundItem> soundDictionary;
    private Dictionary<SceneEnum, SceneSoundItem> sceneSoundDictionary;

    private Coroutine playSceneSoundsCoroutine;

    [SerializeField]
    private SO_SoundList so_soundList = null;
    [SerializeField]
    private SO_SceneSoundList so_sceneSoundsList = null;

    [SerializeField] private float defaultSceneMusicPlayTimeSeconds = 120f;
    [SerializeField] private float sceneMusicStartMinSecs = 20f;
    [SerializeField] private float sceneMusicStartMaxSecs = 40f;
    [SerializeField] private float musicTransitionSecs = 8f;



    protected override void Awake()
    {
        base.Awake();

        soundDictionary = new Dictionary<SoundName, SoundItem>();

        foreach (var soundItem in so_soundList.soundDetails)
        {
            soundDictionary.Add(soundItem.soundName, soundItem);
        }

        sceneSoundDictionary = new Dictionary<SceneEnum, SceneSoundItem>();

        foreach (var sceneItem in so_sceneSoundsList.sceneSoundsDetails)
        {
            sceneSoundDictionary.Add(sceneItem.sceneName, sceneItem);
        }
    }

    public void PlayerSceneSound()
    {
        SoundItem musicSoundItem = null;
        SoundItem ambientSoundItem = null;

        float musicPlayTime = defaultSceneMusicPlayTimeSeconds;

        if (Enum.TryParse<SceneEnum>(SceneManager.GetActiveScene().name, true, out SceneEnum currntSceneName))
        {
            if (sceneSoundDictionary.TryGetValue(currntSceneName, out SceneSoundItem sceneSoundsItem))
            {
                soundDictionary.TryGetValue(sceneSoundsItem.MusicForScene, out musicSoundItem);
                soundDictionary.TryGetValue(sceneSoundsItem.ambientSoundForScene, out ambientSoundItem);
            }
            else
            {
                return;
            }

            if (playSceneSoundsCoroutine != null)
            {
                StopCoroutine(playSceneSoundsCoroutine);
            }

            playSceneSoundsCoroutine = StartCoroutine(PlaySceneSoundsRoutine(musicPlayTime, musicSoundItem, ambientSoundItem));
        }
    }

    private IEnumerator PlaySceneSoundsRoutine(float musicPlayTime, SoundItem musicSoundItem, SoundItem ambientSoundItem)
    {
        if (musicSoundItem != null && ambientSoundItem != null)
        {
            PlayAmbientSoundClip(ambientSoundItem, 0f);
            yield return new WaitForSeconds(UnityEngine.Random.Range(sceneMusicStartMinSecs, sceneMusicStartMaxSecs));
            PlayMusicSoundClip(musicSoundItem, musicTransitionSecs);
            yield return new WaitForSeconds(musicPlayTime);
            PlayAmbientSoundClip(ambientSoundItem, musicTransitionSecs);
        }
    }

    private void PlayMusicSoundClip(SoundItem musicSoundItem, float musicTransitionSecs)
    {
        gameAudioMixer.SetFloat("MusicVolume", ConvertSoundVolumeDecimalFractionToDecibels(musicSoundItem.soundVolume));

        gameMusicAudioSource.clip = musicSoundItem.soundClip;
        gameMusicAudioSource.Play();

        gameMusicSnapshot.TransitionTo(musicTransitionSecs);
    }

    private void PlayAmbientSoundClip(SoundItem ambientSoundItem, float transitionTimeSeconds)
    {
        gameAudioMixer.SetFloat("AmbientVolume", ConvertSoundVolumeDecimalFractionToDecibels(ambientSoundItem.soundVolume));

        ambientSoundAudioSource.clip = ambientSoundItem.soundClip;
        ambientSoundAudioSource.Play();

        gameAmbientSnapshot.TransitionTo(transitionTimeSeconds);
    }

    private float ConvertSoundVolumeDecimalFractionToDecibels(float soundVolume)
    {
        return (soundVolume * 100f - 80f);
    }

    private void OnEnable()
    {
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), PlayerSceneSound, this);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), PlayerSceneSound);
    }

    void Start()
    {
        ObjectPoolManager.Instance.CreatePool(5, soundPrefab, PoolEnum.Sounds.ToString());
    }

    public void PlaySound(SoundName soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out SoundItem soundItem) && soundPrefab != null)
        {
            GameObject soundGameObject = ObjectPoolManager.Instance.GetNextObject(PoolEnum.Sounds.ToString());
            Sound sound = soundGameObject.AddComponent<Sound>();
            sound.SetSound(soundItem);
            soundGameObject.SetActive(true);
            StartCoroutine(DisableSound(soundGameObject, soundItem.soundClip.length));
        }
    }

    private IEnumerator DisableSound(GameObject soundGameObject, float length)
    {
        yield return new WaitForSeconds(length);
        ObjectPoolManager.Instance.Putback(PoolEnum.Sounds.ToString(), soundGameObject);
    }
}
