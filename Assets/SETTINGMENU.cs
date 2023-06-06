using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SETTINGMENU : MonoBehaviour
{
   
    [SerializeField] public Slider musicslider;
    [SerializeField] public Slider VFXSLIDER;
    [SerializeField] public AudioSource BG;
    [SerializeField] public AudioSource vfxMusic;
    private const string MusicVolumeKey = "MusicVolume";
    private const string VFXVolumeKey = "VFXVolume";
    private void Start()
    {
        LoadSettings();
    }


    public void BACKGROUND()
    {
        Debug.Log("BACKGROUND method called");
        float volume = musicslider.value;
        BG.volume = volume;
        BG.Play();
    }
    public void  vfx()
    {
        Debug.Log("VFX method called");
        float volume = VFXSLIDER.value;
        vfxMusic.volume = volume;
        vfxMusic.Play();
    }
    public void Save()
    {
        float musicVolume = musicslider.value;
        float vfxVolume = VFXSLIDER.value;

        PlayerPrefs.SetFloat(MusicVolumeKey, musicVolume);
        PlayerPrefs.SetFloat(VFXVolumeKey, vfxVolume);
        PlayerPrefs.Save();
        Debug.Log("Saving settings - Music Volume: " + musicVolume + ", VFX Volume: " + vfxVolume);
        gameObject.SetActive(false);
    }
    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
            Debug.Log("Loaded Music Volume: " + musicVolume);
            musicslider.value = musicVolume;
            BG.volume = musicVolume;
        }

        if (PlayerPrefs.HasKey(VFXVolumeKey))
        {
            float vfxVolume = PlayerPrefs.GetFloat(VFXVolumeKey);
            Debug.Log("Loaded VFX Volume: " + vfxVolume);
            VFXSLIDER.value = vfxVolume;
            vfxMusic.volume = vfxVolume;
        }
    }

}
