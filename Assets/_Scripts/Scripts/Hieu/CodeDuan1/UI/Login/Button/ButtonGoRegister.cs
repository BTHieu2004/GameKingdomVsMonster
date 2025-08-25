using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGoRegister : BtnLoadParenAbstract<LoginHolderCtrl>
{
    protected override void OnClick()
    {
        base.OnClick();
        this.GoRegister();
    }
    protected virtual void GoRegister()
    {
        HolderLoginUI.Instance.LoginHolderCtrl.gameObject.SetActive(false);
        HolderLoginUI.Instance.RegisterHolderCtrl.gameObject.SetActive(true);
        HolderLoginUI.Instance.TopText("Register");
    }
}
