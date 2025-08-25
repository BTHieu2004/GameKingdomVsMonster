using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : BtnMenuAbstract
{    
    [SerializeField] protected PlantSO plantSO;    
    public PlantSO PlantSO => plantSO;
    [SerializeField] protected CooldownTimeTower cooldownTimeTower;
    [SerializeField] protected SetDownPlant setDownPlant;
    [SerializeField] protected Image icon;
    [SerializeField] protected TextMeshProUGUI textPrice;        
    public bool isstartcounting;    
    protected override void Start()
    {
        base.Start();
        this.cooldownTimeTower.gameObject.SetActive(false);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();                
        this.LoadImage();
        this.LoadTextPrice();
        this.LoadSetdownPlant();
        this.LoadCooldownTimeTower();
   }
        
    protected virtual void LoadImage()
    {
        if(this.icon != null) return;
        this.icon = transform.Find("Icon").GetComponent<Image>();        
    }
    protected virtual void LoadTextPrice()
    {
        if (this.textPrice != null) return;
        this.textPrice = GetComponentInChildren<TextMeshProUGUI>();        
    }
    protected virtual void LoadSetdownPlant()
    {
        if (this.setDownPlant != null) return;
        this.setDownPlant = FindAnyObjectByType<SetDownPlant>();
    }
    protected virtual void LoadCooldownTimeTower()
    {
        if (this.cooldownTimeTower != null) return;
        this.cooldownTimeTower = GetComponentInChildren<CooldownTimeTower>();
    }
    public virtual void AddPlantSlot(PlantSO plant)
    {
        this.plantSO = plant;       
        this.plantSO.selected = true;
        this.textPrice.text = this.plantSO.Price.ToString();
        this.icon.sprite = this.plantSO.sprite;
    }
    protected override void OnClick()
    {           
        this.CancelSelected();                
        this.BuyPlant();
    }
    protected virtual void CancelSelected()
    {
        if (ProgressLevel.Instance.isStart) return;
        if (this.plantSO == null) return;
        this.plantSO.selected = false;
        this.plantSO = null;
        this.textPrice.text = null;
        this.icon.sprite = null;
    }
    protected virtual void BuyPlant()
    {
        if (this.plantSO == null) return;           
        if (this.plantSO.Price > ProgressLevel.Instance.QuantitySun) return;         
        setDownPlant.PlantSelected(plantSO,this.icon.sprite);
        this.setDownPlant.setDownPlant += StartCounting;
    }
    public virtual void StartCounting(PlantSO plantSO)
    {
        if (this.plantSO != plantSO) return;
        this.isstartcounting = true;
        this.button.interactable = false;
        this.cooldownTimeTower.gameObject.SetActive(true);
    }
}
