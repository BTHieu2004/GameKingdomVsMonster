using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : HieuSingleton<SoundManager>
{
    [SerializeField] protected AudioMixer audioMixer;
    public AudioMixer AudioMixer => audioMixer;
    public virtual void SetMusicBackGround(float value)
    {        
        this.audioMixer.SetFloat("MusicBackGround", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicBackGround", value);
    }
    public virtual void SetMusicSFX(float value)
    {
        this.audioMixer.SetFloat("SFX",Mathf.Log(value)*20);
        PlayerPrefs.SetFloat("SFX", value);
    }
}
