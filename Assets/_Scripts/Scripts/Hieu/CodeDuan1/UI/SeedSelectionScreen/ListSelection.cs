using System.Collections.Generic;
using UnityEngine;

public class ListSelection : BaseUIAbstract
{
    [SerializeField] protected List<PlantSO> listPlantSO = new();
    public List<PlantSO> ListPlantSO => listPlantSO;

    [SerializeField] protected BtnPlant btnPlant;    
    public BtnPlant BtnPlant => btnPlant;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnPlant();
    }
    protected virtual void LoadBtnPlant()
    {
        if (this.btnPlant != null) return;
        this.btnPlant = GetComponentInChildren<BtnPlant>();
    }

    protected virtual void Start()
    {
        this.LoadPlantSO();
        this.btnPlant.gameObject.SetActive(false);
        this.InstaceBntPlant();
    }
    protected virtual void LoadPlantSO()
    {
        if (this.listPlantSO.Count > 0) return;
        this.listPlantSO = PlayerManager.Instance.PlayerSO.plants;
    }
    protected virtual void InstaceBntPlant()
    {
        foreach (PlantSO child in this.listPlantSO)
        {
            child.selected = false;
            BtnPlant newBtn = Instantiate(btnPlant);            
            newBtn.transform.SetParent(this.btnPlant.transform.parent);
            newBtn.gameObject.SetActive(true);
            newBtn.transform.localScale = Vector3.one;
            newBtn.SetUpBtnInfo(child);
        }
    }
}
