using UnityEngine;

public class BtnBuy : BtnMenuAbstract
{
    [SerializeField] protected ConfirmPurChaseUI confirmPurChaseUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadConfirmUI();
    }
    protected virtual void LoadConfirmUI()
    {
        if (this.confirmPurChaseUI != null) return;
        this.confirmPurChaseUI = GetComponentInParent<ConfirmPurChaseUI>();
    }
    protected override void OnClick()
    {        
        if (this.confirmPurChaseUI.PlantSO.unLock) return;
        if (PlayerManager.Instance.PlayerSO.money < this.confirmPurChaseUI.PlantSO.Price) return;
        PlayerManager.Instance.PlayerSO.money -= this.confirmPurChaseUI.PlantSO.Price;        
        this.BuyKindom();
        this.confirmPurChaseUI.Hide();
    }
    protected virtual void BuyKindom()
    {
        this.confirmPurChaseUI.PlantSO.unLock = true;
        PlayerManager.Instance.PlayerSO.plants.Add(this.confirmPurChaseUI.PlantSO);
        AchivementManager.Instance.GetAchivementTypeID(EnumAchiverment.Hidden,3);
    }
}
