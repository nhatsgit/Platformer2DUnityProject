using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType{
    click =999,
    clap =1,
    jump=2,
    opendoor=3,
    opendoor2=4,
    collect=5,
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource soundEffect;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(this.gameObject);
        }
        soundEffect = GetComponent<AudioSource>();
    }
    public void OnPlaySound(SoundType soundType)
    {
        AudioClip audio = Resources.Load<AudioClip>($"SoundEffects/{soundType.ToString()}");
        soundEffect.PlayOneShot(audio);
    }
    public void OnStopSound()
    {
        soundEffect.Stop();
    }
    public void OnSoundVolumeChange(float volumeBarValue)
    {
        soundEffect.volume = volumeBarValue;
    }
}
