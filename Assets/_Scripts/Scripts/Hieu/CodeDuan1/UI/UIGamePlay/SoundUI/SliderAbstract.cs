using UnityEngine;
using UnityEngine.UI;

public class SliderAbstract : HieuMonoBehaviour
{
    [SerializeField] protected Slider slider;
    protected virtual void Start()
    {
        this.slider.onValueChanged.AddListener(OnChangeValueSlider);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
    }
    protected virtual void OnChangeValueSlider(float value)
    {

    }
}
