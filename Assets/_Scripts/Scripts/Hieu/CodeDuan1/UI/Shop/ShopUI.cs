using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : BaseUIAbstract
{
    [SerializeField] protected List<PlantSO> PlantSO = new List<PlantSO>();
    [SerializeField] protected List<BtnShop> btnShops = new List<BtnShop>();
    [SerializeField] protected ConfirmPurChaseUI confirmPurChaseUI;
    public ConfirmPurChaseUI ConfirmPurChaseUI => confirmPurChaseUI;
    [SerializeField] protected BtnShop btnShop;
    protected virtual void Start()
    {
        this.LoadKingdomSOs();
        this.InstanceBtnShop();
        this.btnShop.gameObject.SetActive(false);
    }
    protected override void LoadComponents()
    {

        base.LoadComponents();
        //this.LoadKingdomSOs();
        this.LoadBtnShop();
        this.LoadCfPurChase();
    }
    protected virtual void LoadKingdomSOs()
    {        
        this.PlantSO = ShopManager.Instance.PlantSOs;
    }
    protected virtual void LoadBtnShop() 
    {
        if (this.btnShop != null) return;
        this.btnShop = GetComponentInChildren<BtnShop>();
    }
    protected virtual void LoadCfPurChase()
    {
        if (this.confirmPurChaseUI != null) return;
        this.confirmPurChaseUI = GetComponentInChildren<ConfirmPurChaseUI>(); 
    }
    protected virtual void InstanceBtnShop()
    {
        foreach(PlantSO kingdomSO in this.PlantSO)
        {
            BtnShop btn = Instantiate(btnShop);
            btn.SetPlantSO(kingdomSO);
            btn.transform.SetParent(this.btnShop.transform.parent, false);
            btn.gameObject.SetActive(true);
            btn.name = kingdomSO.name;
            this.btnShops.Add(btn);
        }
    }
}
