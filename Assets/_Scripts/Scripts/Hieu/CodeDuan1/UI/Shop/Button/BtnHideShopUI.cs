using UnityEngine;

public class BtnHideShopUI : BtnLoadParenAbstract<ShopUI>
{    
    protected override void OnClick()
    {
        this.HideUI();
    }
    protected virtual void HideUI()
    {
        this.parentCtrl.Hide();
    }
}
