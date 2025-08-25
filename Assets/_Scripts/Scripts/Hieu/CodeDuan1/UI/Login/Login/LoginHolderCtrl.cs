using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginHolderCtrl : HieuMonoBehaviour
{
    [SerializeField] protected LoginCheckInput loginCheckInput;
    public LoginCheckInput LoginCheckInput => loginCheckInput;    
    public TMP_InputField EnmailLoginInput;
    public TMP_InputField PassWordLoginInput;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadCheckInput();
        this.LoadEmailLogin();
        this.LoadPasswordLogin();
    }   
    protected virtual void LoadCheckInput()
    {
        if (this.loginCheckInput != null) return;
        this.loginCheckInput = GetComponentInChildren<LoginCheckInput>();
    }
    protected virtual void LoadEmailLogin()
    {
        if (this.EnmailLoginInput != null) return;
        this.EnmailLoginInput = transform.Find("EmailLoginArea").GetComponentInChildren<TMP_InputField>();        
    }
    protected virtual void LoadPasswordLogin()
    {
        if (this.PassWordLoginInput != null) return;
        this.PassWordLoginInput = transform.Find("PasswordLoginArea").GetComponentInChildren<TMP_InputField>();        
    }
}
