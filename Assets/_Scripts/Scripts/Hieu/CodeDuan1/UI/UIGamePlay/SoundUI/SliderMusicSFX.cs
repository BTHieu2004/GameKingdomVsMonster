using UnityEngine;

public class SliderMusicSFX : SliderAbstract
{
    protected override void Start()
    {
        base.Start();        
        if (PlayerPrefs.HasKey("SFX"))
        {
            float value = PlayerPrefs.GetFloat("SFX");
            this.slider.value = value;
        }
    }
    protected override void OnChangeValueSlider(float value)
    {
        base.OnChangeValueSlider(value);
        SoundManager.Instance.SetMusicSFX(value);
    }
}
