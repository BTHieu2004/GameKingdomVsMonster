using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RgButtonGoback : BtnLoadParenAbstract<RegisterHolderCtrl>
{
    protected override void OnClick()
    {
        base.OnClick();
        this.GoLogin();
    }
    public virtual void GoLogin()
    {
        HolderLoginUI.Instance.RegisterHolderCtrl.gameObject.SetActive(false);        
        HolderLoginUI.Instance.LoginHolderCtrl.gameObject.SetActive(true);
        HolderLoginUI.Instance.TopText("Login");
    }
}
