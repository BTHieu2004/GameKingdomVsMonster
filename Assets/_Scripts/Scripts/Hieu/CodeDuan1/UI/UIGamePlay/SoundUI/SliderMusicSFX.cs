using UnityEngine;

public class SliderMusicSFX : SliderAbstract
{
    protected override void OnChangeValueSlider(float value)
    {
        base.OnChangeValueSlider(value);
        SoundManager.Instance.SetMusicSFX(value);
    }
}
