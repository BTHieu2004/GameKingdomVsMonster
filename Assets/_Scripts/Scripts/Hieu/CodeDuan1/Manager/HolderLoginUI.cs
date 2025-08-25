using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class HolderLoginUI : HieuSingleton<HolderLoginUI>
{
    [SerializeField] protected Transform loginHolderCtrl;
    public Transform LoginHolderCtrl => loginHolderCtrl;

    [SerializeField] protected Transform registerHolderCtrl;
    public Transform RegisterHolderCtrl => registerHolderCtrl;

    [SerializeField] protected Transform resetCtrl;
    public Transform ResetCtrl => resetCtrl;

    [SerializeField] protected TextMeshProUGUI topText;
    [SerializeField] protected TextMeshProUGUI systemText;
    protected override void OnDisable()
    {
        base.OnDisable();
        CancelInvoke();
    }
    protected override void LoadInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if (instance == null)
        {
            instance = this;                        
            return;
        }        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLoginCtrl();
        this.LoadRegisterCtrl();
        this.LoadResetCtrl();
        this.LoadTopText();
        this.LoadSystemText();
    }
    protected virtual void LoadLoginCtrl()
    {
        if (this.loginHolderCtrl != null) return;
        this.loginHolderCtrl = transform.Find("LoginHolder");
    }
    protected virtual void LoadRegisterCtrl()
    {
        if (this.registerHolderCtrl != null) return;
        this.registerHolderCtrl = transform.Find("RegisterHolder");
    }
    protected virtual void LoadResetCtrl()
    {
        if (this.resetCtrl != null) return;
        this.resetCtrl = transform.Find("ResetPassHolder");
    }   
    protected virtual void LoadTopText()
    {
        if (this.topText != null) return;
        this.topText = transform.Find("TopText").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadSystemText()
    {
        if (this.systemText != null) return;
        this.systemText = transform.Find("SystemText").GetComponent<TextMeshProUGUI>();
    }
    public void TopText(string empty)
    {
        this.topText.text = empty;
    }
    public void MessageText(string text)
    {
        this.systemText.text = text;
        CancelInvoke(nameof(ResetMessage));
        Invoke(nameof(ResetMessage),3f);        
    }    
    protected virtual void ResetMessage()
    {        
        systemText.text = string.Empty;
    }
}
