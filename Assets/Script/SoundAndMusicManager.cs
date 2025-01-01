using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusicManager : MonoBehaviour
{
    public AudioSource SoundAudioSource;
    public AudioSource MusicAudioSource;

    [HideInInspector]
    public static SoundAndMusicManager instance;
    [Space]
    [Header("SoundAndMusic Clip")]
    public AudioClip Button_Clip;
    public AudioClip BgMusic_Clip;

    #region Unity Function
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        StartSetData();
    }
    #endregion

    #region Get/Set Data 
    public void StartSetData()
    {
        SetSound_Volume(StaticData.Sound);
        SetMusic_Volume(StaticData.Music);
    }
    #endregion 

    #region Sound Function
    public void PlaySound(AudioClip clip)
    {
        SoundAudioSource.clip = clip;
        SoundAudioSource.Play();
    }


    public void SoundMute(bool mute)
    {

        SoundAudioSource.mute = mute;
    }
    public void SetSound_Volume(float Volume)
    {
        SoundAudioSource.volume = Volume;
    }
    #endregion

    #region Music Function
    public void PlayMusic(AudioClip clip)
    {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void MuiscMute(bool mute)
    {
        MusicAudioSource.mute = mute;
    }

    public void SetMusic_Volume(float Volume)
    {
        MusicAudioSource.volume = Volume;
    }
    #endregion




    #region Other Function
    public void PauseSoundAndMusic(bool IsPuse)
    {
        if (IsPuse)
        {
            SoundAudioSource.Pause();
            MusicAudioSource.Pause();
        }
        else
        {
            SoundAudioSource.UnPause();
            MusicAudioSource.UnPause();
        }
    }
    #endregion
}
