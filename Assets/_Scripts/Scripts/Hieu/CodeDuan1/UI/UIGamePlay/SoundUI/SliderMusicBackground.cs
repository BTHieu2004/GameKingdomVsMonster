using Unity.VisualScripting;
using UnityEngine;

public class SliderMusicBackground : SliderMusisicAbstract
{
    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.HasKey("MusicBackGround"))
        {
            float value = PlayerPrefs.GetFloat("MusicBackGround");
            this.slider.value = value;
        }
    }
    protected override void OnChangeValueSlider(float value)
    {        
        SoundManager.Instance.SetMusicBackGround(value);
    }
}
