using UnityEngine;

public class SliderMusicBackground : SliderAbstract
{
    protected override void OnChangeValueSlider(float value)
    {        
        SoundManager.Instance.SetMusicBackGround(value);
    }
}
