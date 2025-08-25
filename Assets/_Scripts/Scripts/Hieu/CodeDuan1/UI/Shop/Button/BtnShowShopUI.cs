using UnityEngine;

public class BtnShowShopUI : MainButton
{            
    protected override void OnClick()
    {
        this.ShowShopUI();
    }
    protected virtual void ShowShopUI()
    {
        this.subMenuUIHolder.ShopUI.Show();
    }
}
