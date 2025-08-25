using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGoRecover : BtnLoadParenAbstract<LoginHolderCtrl>
{
    protected override void OnClick()
    {
        base.OnClick();
        this.GoRecovery();
    }
    protected virtual void GoRecovery()
    {
        HolderLoginUI.Instance.LoginHolderCtrl.gameObject.SetActive(false);
        HolderLoginUI.Instance.ResetCtrl.gameObject.SetActive(true);
        HolderLoginUI.Instance.TopText("Recovery");
    }
}
