using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : HieuSingleton<SoundManager>
{
    [SerializeField] protected AudioMixer audioMixer;    
    public virtual void SetMusicBackGround(float value)
    {        
        this.audioMixer.SetFloat("MusicBackGround", Mathf.Log10(value) * 20);
    }
    public virtual void SetMusicSFX(float value)
    {
        this.audioMixer.SetFloat("MusixSFX",Mathf.Log(value)*20);
    }
}
