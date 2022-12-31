using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
    GameObject soundPrefab;

    [SerializeField]
    private Dictionary<SoundName, SoundItem> soundDictionary;

    [SerializeField]
    private SO_SoundList so_soundList = null;

    protected override void Awake()
    {
        base.Awake();

        soundDictionary = new Dictionary<SoundName, SoundItem>();

        foreach (var soundItem in so_soundList.soundDetails)
        {
            soundDictionary.Add(soundItem.soundName, soundItem);
        }
    }

    void Start()
    {
        PoolManager.Instance.CreatePool(5, soundPrefab, PoolEnum.Sounds.ToString());
    }

    public void PlaySound(SoundName soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out SoundItem soundItem) && soundPrefab != null)
        {
            GameObject soundGameObject = PoolManager.Instance.GetNextObject(PoolEnum.Sounds.ToString());
            Sound sound = soundGameObject.AddComponent<Sound>();
            sound.SetSound(soundItem);
            soundGameObject.SetActive(true);
            StartCoroutine(DisableSound(soundGameObject, soundItem.soundClip.length));
        }
    }

    private IEnumerator DisableSound(GameObject soundGameObject, float length)
    {
        yield return new WaitForSeconds(length);
        PoolManager.Instance.Putback(PoolEnum.Sounds.ToString(), soundGameObject);
    }
}
