using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource musics;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
        musics = GetComponent<AudioSource>();
    }
    public void OnMusicVolumeChange(float volumeBarValue)
    {
        musics.volume = volumeBarValue;
    }
}
