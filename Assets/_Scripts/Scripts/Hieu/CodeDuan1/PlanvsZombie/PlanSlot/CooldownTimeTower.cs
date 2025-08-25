using UnityEngine;
using UnityEngine.UI;

public class CooldownTimeTower : HieuMonoBehaviour
{
    [SerializeField] protected Slider sliderCooldown;
    [SerializeField] protected Slot slot;
    [SerializeField] protected float cooldownCounter;
    [SerializeField] protected float cooldownTime;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Resetvalue();
    }
    protected virtual void Start()
    {
        this.Resetvalue();

    }
    protected virtual void Update()
    {
        if (!this.slot.isstartcounting) return;
        this.CountingTime();
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();   
        if (this.slot == null) return;
        this.cooldownTime = this.slot.PlantSO.cooldownTimeTower;
        this.cooldownCounter = this.cooldownTime;
        this.sliderCooldown.maxValue = cooldownTime;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        this.LoadSlot();
    }    
    protected virtual void LoadSlider()
    {
        if (this.sliderCooldown != null) return;
        this.sliderCooldown = GetComponent<Slider>();
    }
    protected virtual void LoadSlot()
    {
        if (this.slot != null) return;
        this.slot = GetComponentInParent<Slot>();
    }
    protected virtual void CountingTime()
    {
        this.cooldownCounter -= Time.deltaTime;
        this.OnChangeSlider(this.cooldownCounter);
        if (this.cooldownCounter > 0) return;
        this.cooldownCounter = this.cooldownTime;
        this.slot.isstartcounting = false;        
        this.slot.Button.interactable = true;
        gameObject.SetActive(false);
    }
    protected virtual void OnChangeSlider(float currentTime)
    {
        this.sliderCooldown.value = currentTime;
    }
}
