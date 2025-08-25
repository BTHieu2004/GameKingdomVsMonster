using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public abstract class CheckInputEmptyAbstract<T> : HieuMonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T parentCtrl;
    [SerializeField] protected List<TMP_InputField> Tmp_Input;
    [SerializeField] protected bool isNullEmpty = false;
    public bool IsNullEmpty => isNullEmpty;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParentCtrl();
        this.LoadTmp_Input();
    }
    protected virtual void LoadParentCtrl()
    {
        if (this.parentCtrl != null) return;
        this.parentCtrl = transform.GetComponentInParent<T>();
    }
    protected virtual void LoadTmp_Input()
    {
        this.Tmp_Input = this.parentCtrl.GetComponentsInChildren<TMP_InputField>().ToList();
    }
    public virtual bool CheckNullInput()
    {
        foreach(TMP_InputField child in this.Tmp_Input)
        {
            if (!string.IsNullOrEmpty(child.text)) continue;
            HolderLoginUI.Instance.MessageText("Vui lòng nhập đầy đủ thông tin");            
            return isNullEmpty = true;
        }
        return isNullEmpty = false;
    }
    public virtual void ResetInput()
    {
        foreach (TMP_InputField child in this.Tmp_Input)
        {
            if (string.IsNullOrEmpty(child.text)) continue;
            child.text = string.Empty;
        }
    }    
}
