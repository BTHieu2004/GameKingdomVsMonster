using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRegister : BtnLoadParenAbstract<RegisterHolderCtrl>
{
    protected override void OnClick()
    {        
        this.RegisterClick();
    }
    protected virtual void RegisterClick()
    {       
        if (this.parentCtrl.RegisterCheckInput.CheckNullInput()) return;
        LoginManager.Instance.RegisterUser.Register(this.parentCtrl.userNameRegiaterArea.text, this.parentCtrl.emailRegisterArea.text, this.parentCtrl.passwordLoginArea.text);
    }
}
