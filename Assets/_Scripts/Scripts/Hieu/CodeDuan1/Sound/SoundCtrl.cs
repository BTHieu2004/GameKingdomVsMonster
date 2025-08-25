using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundCtrl : PoolingObj
{
    [SerializeField] protected AudioSource audioSource;
    public override string NameObj()
    {
        return "SoundCtrl";
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        if (this.audioSource != null) return;
        this.audioSource = GetComponent<AudioSource>();
    }
}
