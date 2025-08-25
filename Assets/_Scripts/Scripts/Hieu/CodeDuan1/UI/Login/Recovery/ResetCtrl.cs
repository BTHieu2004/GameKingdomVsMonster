using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetCtrl : HieuMonoBehaviour
{
    [SerializeField] public TMP_InputField emailRecoverArea;    
    [SerializeField] protected RecoveryCheckInput recoveryCheck;
    public RecoveryCheckInput RecoveryCheck => recoveryCheck;    
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.EmailRecoverArea();
        this.LoadCheckInput();
    }  
    protected virtual void EmailRecoverArea()
    {
        if (this.emailRecoverArea != null) return;
        this.emailRecoverArea = transform.Find("EmailRecoverArea").GetComponentInChildren<TMP_InputField>();
    }
    protected virtual void LoadCheckInput()
    {
        if (recoveryCheck != null) return;
        this.recoveryCheck = transform.GetComponentInChildren<RecoveryCheckInput>();
    }
}
