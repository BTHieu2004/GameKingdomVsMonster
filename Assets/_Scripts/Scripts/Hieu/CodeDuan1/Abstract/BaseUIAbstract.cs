using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIAbstract : HieuMonoBehaviour
{
    [SerializeField] protected bool isShow = false;
    public bool IsShow => isShow;

    public virtual void Show()
    {
        gameObject.SetActive(true);
        isShow = true;
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
        isShow = false;
    }
    public virtual void Toggle()
    {
        if (!isShow) Show();
        else Hide();
    }
}
