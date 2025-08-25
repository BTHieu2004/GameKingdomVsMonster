using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : BtnMenuAbstract
{
    [SerializeField] protected PauseUI pauseUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPauseUI();
    }
    protected virtual void LoadPauseUI()
    {
        if (this.pauseUI != null) return;
        this.pauseUI = transform.Find("PauseUI").GetComponent<PauseUI>();
    }
    protected override void OnClick()
    {        
        this.PauseGame();        
        this.ShowUI();
    }
    protected virtual void PauseGame()
    {
        GameManager.Instance.PauseGame();
    }
    protected virtual void ShowUI()
    {
        this.pauseUI.Show();
    }
}

