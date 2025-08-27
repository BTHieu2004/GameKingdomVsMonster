using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveUI : HieuMonoBehaviour
{
    [SerializeField] protected Transform winPanelUI;
    [SerializeField] protected Transform losePanelUI;

    protected virtual void Start()
    {        
        GameManager.Instance.onPlayerWin += ShowWinUI;
        GameManager.Instance.onPlayerLose += ShowLoseUI;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.Instance.onPlayerWin -= ShowWinUI;
        GameManager.Instance.onPlayerLose -= ShowLoseUI;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWinUI();
        this.LoadLoseUI();
    }
    protected virtual void LoadWinUI()
    {
        if (this.winPanelUI != null) return;
        this.winPanelUI = transform.Find("WinHolder").transform;
    }
    protected virtual void LoadLoseUI()
    {
        if (this.losePanelUI != null) return;
        this.losePanelUI = transform.Find("LoseHolder").transform;
    }
    protected virtual void ShowWinUI()
    {        
        winPanelUI?.gameObject.SetActive(true);        
    }
    protected virtual void ShowLoseUI()
    {
        losePanelUI?.gameObject.SetActive(true);        
    }
}
