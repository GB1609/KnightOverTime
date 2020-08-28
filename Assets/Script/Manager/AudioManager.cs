﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] public string transitionSound;

    [FormerlySerializedAs("menuBGMusic")] [SerializeField]
    public string menuBgMusic;

    [FormerlySerializedAs("medievalBGMusic")] [SerializeField]
    public string medievalBgMusic;

    [FormerlySerializedAs("mayaBGMusic")] [SerializeField]
    public string mayaBgMusic;

    private AudioClip _transitionAudioClip;
    private AudioClip _menuAudioClip;
    private AudioClip _medievalAudioClip;
    private AudioClip _mayaAudioClip;

    public void Startup()
    {
        UpdateVolumes();
        status = ManagerStatus.Started;
        _menuAudioClip = Resources.Load<AudioClip>(menuBgMusic);
        Debug.Log("length=" + _mayaAudioClip.length);
        _transitionAudioClip = (AudioClip) Resources.Load(transitionSound);
        _medievalAudioClip = (AudioClip) Resources.Load(medievalBgMusic);
        _mayaAudioClip = (AudioClip) Resources.Load(mayaBgMusic);
    }

    public void UpdateMusicVolume()
    {
        masterMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void UpdateVolumes()
    {
        UpdateMusicVolume();
    }

    public void PlayBeginSceneMusic()
    {
        Debug.Log("entro");
        PlayMusic(_menuAudioClip);
    }

    public void PlayTransitionSound()
    {
        PlayMusic(_transitionAudioClip);
    }

    private void PlayMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }
}