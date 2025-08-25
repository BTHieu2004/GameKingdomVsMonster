using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LoginUser : PlayFabAbstract
{
    
    [SerializeField] protected bool loginIsSuccess;
    public bool LoginIsSuccess => loginIsSuccess;
    protected virtual void Start()
    {
        
    }
    
    public void Login(string emailUser, string passwordUser)
    {
        
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailUser,
            Password = passwordUser
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnErrol);
    }

    private void OnErrol(PlayFabError error)
    {        
        base.OnError(error);
        this.loginIsSuccess = false;        
    }

    private void OnLoginSucces(LoginResult result)
    {
        this.Message("Login is successfully");
        this.loginIsSuccess = true;
        SceneManager.LoadScene(NameScene.SceneMainMenu);
    }        
}
