using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class RegisterHolderCtrl : HieuMonoBehaviour
{
    [SerializeField] protected RegisterCheckInput registerCheckInput;
    public RegisterCheckInput RegisterCheckInput => registerCheckInput;
    [Header("Input")]
    [SerializeField] public TMP_InputField userNameRegiaterArea;    
    [SerializeField] public TMP_InputField emailRegisterArea; 
    [SerializeField] public TMP_InputField passwordLoginArea;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCheckInput();
        this.LoadUserNameRegister();
        this.LoadEmailRegister();
        this.LoadPasswordRegister();                
    }
    protected virtual void LoadCheckInput()
    {
        if (this.registerCheckInput != null) return;
        this.registerCheckInput = GetComponentInChildren<RegisterCheckInput>();
    }
    protected virtual void LoadUserNameRegister()
    {
        if (this.userNameRegiaterArea != null) return;
        this.userNameRegiaterArea = transform.Find("UserNameRegiaterArea").GetComponentInChildren<TMP_InputField>();
    }
    protected virtual void LoadEmailRegister()
    {
        if (this.emailRegisterArea != null) return;
        this.emailRegisterArea = transform.Find("EmailRegisterArea").GetComponentInChildren<TMP_InputField>();
    }  
    protected virtual void LoadPasswordRegister()
    {
        if (this.passwordLoginArea != null) return;
        this.passwordLoginArea = transform.Find("PasswordLoginArea").GetComponentInChildren<TMP_InputField>();
    }        
}
