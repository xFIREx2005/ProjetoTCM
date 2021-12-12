using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeStatic : MonoBehaviour
{
    private float volumeMusic = 1;
    private float volumeFx = 1;

    private static VolumeStatic instance = null;
    public static VolumeStatic Instance { get { return instance; } }

    private void Start()
    {
        if (instance) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }



    public void GravarVolumeMusic(float volume)
    {
        this.volumeMusic = volume;
    }
    public void GravarVolumeFx(float volume)
    {
        this.volumeFx = volume;
    }

    public float ConsutarVolumeMusic()
    {
        return this.volumeMusic;
    }
    public float ConsutarVolumeFx()
    {
        return this.volumeFx;
    }
}
