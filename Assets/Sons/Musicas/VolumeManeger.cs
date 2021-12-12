using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManeger : MonoBehaviour
{
    
    public static float volumeMaster, volumeMusic, volumeFx;
    public Slider sliderMaster, sliderMusic, sliderFx;

    void Awake()
    {
        volumeFx = 1;
        volumeMaster = 1;
        volumeMusic = 1;
    }
    private void Start()
    {
        volumeMusic = VolumeStatic.Instance.ConsutarVolumeMusic();
        GameObject[] Musics = GameObject.FindGameObjectsWithTag("Musics");
        for (int i = 0; i < Musics.Length; i++)
        {
            Musics[i].GetComponent<AudioSource>().volume = volumeMusic;
            VolumeStatic.Instance.GravarVolumeMusic(volumeMusic);
        }

        volumeFx = VolumeStatic.Instance.ConsutarVolumeFx();
        GameObject[] Fx = GameObject.FindGameObjectsWithTag("AudioFx");
        for (int i = 0; i < Fx.Length; i++)
        {
            Fx[i].GetComponent<AudioSource>().volume = volumeFx;
            VolumeStatic.Instance.GravarVolumeFx(volumeFx);
        }

        sliderMaster.value = volumeMaster;
        sliderMusic.value = volumeMusic;
        sliderFx.value = volumeFx;
    }

    void Update()
    {
        
    }

    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
    }

    public void VolumeMusic(float volume)
    {
        volumeMusic = volume;
        GameObject[] Musics = GameObject.FindGameObjectsWithTag("Musics");
        for(int i=0; i < Musics.Length; i++)
        {
            Musics[i].GetComponent<AudioSource>().volume = volumeMusic;
            VolumeStatic.Instance.GravarVolumeMusic(volumeMusic);
        }
    }

    public void VolumeFx(float volume)
    {
        volumeFx = volume;
        GameObject[] Fx = GameObject.FindGameObjectsWithTag("AudioFx");
        for (int i = 0; i < Fx.Length; i++)
        {
            Fx[i].GetComponent<AudioSource>().volume = volumeFx;
            VolumeStatic.Instance.GravarVolumeFx(volumeFx);
        }
    }
}
