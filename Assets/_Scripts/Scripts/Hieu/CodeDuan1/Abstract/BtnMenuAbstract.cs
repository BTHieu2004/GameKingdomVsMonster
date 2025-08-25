using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnMenuAbstract : HieuMonoBehaviour
{
    [SerializeField] protected Button button;
    public Button Button => button;
    protected virtual void Start()
    {
        this.AddOnClickEvent();
    }
    protected abstract void OnClick();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }    
    private void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
    }
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(OnClick);
    }
}
