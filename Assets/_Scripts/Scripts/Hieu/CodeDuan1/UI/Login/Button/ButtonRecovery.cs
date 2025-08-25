using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRecovery : BtnLoadParenAbstract<ResetCtrl>
{
    protected override void OnClick()
    {        
        this.RecoveryClick();
    }
    protected virtual void RecoveryClick()
    {        
        if (this.parentCtrl.RecoveryCheck.CheckNullInput()) return;
        LoginManager.Instance.RecoveryUser.Recovery(this.parentCtrl.emailRecoverArea.text);                   
    }
}
