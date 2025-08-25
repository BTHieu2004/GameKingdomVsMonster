using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogin : BtnLoadParenAbstract<LoginHolderCtrl>
{
    protected override void OnClick()
    {        
        this.LoginClick();
    }
    protected virtual void LoginClick()
    {        
        if (this.parentCtrl.LoginCheckInput.CheckNullInput()) return;
        LoginManager.Instance.LoginUser.Login(this.parentCtrl.EnmailLoginInput.text, this.parentCtrl.PassWordLoginInput.text);                
    }
}
