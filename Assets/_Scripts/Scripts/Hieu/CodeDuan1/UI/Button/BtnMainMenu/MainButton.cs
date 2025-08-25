using UnityEngine;

public abstract class MainButton : BtnMenuAbstract
{
    [SerializeField] protected SubMenuUIHolder subMenuUIHolder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSubMenuHolder();
    }
    protected virtual void LoadSubMenuHolder()
    {        
        this.subMenuUIHolder = FindAnyObjectByType<SubMenuUIHolder>();
    }
}
