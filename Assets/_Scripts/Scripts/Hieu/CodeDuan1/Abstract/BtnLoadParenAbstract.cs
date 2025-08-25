using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnLoadParenAbstract<T> : BtnMenuAbstract where T : HieuMonoBehaviour
{    
    [SerializeField] protected T parentCtrl;   
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadParentCtrl();
    }    
    protected virtual void LoadParentCtrl()
    {
        if (this.parentCtrl != null) return;
        this.parentCtrl = transform.GetComponentInParent<T>();
    }
    protected override void OnClick()
    {
        CheckInputEmptyAbstract<T> checkInput = this.parentCtrl.GetComponentInChildren<CheckInputEmptyAbstract<T>>();        
        checkInput.ResetInput();
    }
}
