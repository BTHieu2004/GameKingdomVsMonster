using UnityEngine;

public class BtnNoBuy : BtnMenuAbstract
{
    [SerializeField] protected ConfirmPurChaseUI confirmPurChaseUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadConfirmUI();
    }
    protected virtual void LoadConfirmUI()
    {
        if (this.confirmPurChaseUI != null) return;
        this.confirmPurChaseUI = GetComponentInParent<ConfirmPurChaseUI>();
    }
    protected override void OnClick()
    {
        this.HideUI();
    }
    protected virtual void HideUI()
    {
        this.confirmPurChaseUI.Hide();
    }
}
