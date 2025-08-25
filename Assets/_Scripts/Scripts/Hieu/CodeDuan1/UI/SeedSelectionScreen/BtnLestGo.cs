using UnityEngine;

public class BtnLestGo : BtnLoadParenAbstract<SelectionUI>
{
    protected override void OnClick()
    {        
        this.HideUISelection();
    }
    protected virtual void HideUISelection()
    {
        if(this.parentCtrl.SelectedUI.countSelected < 1) return;
        this.parentCtrl.SelectionHolder.Hide();
        ProgressLevel.Instance.StartGame();
        gameObject.SetActive(false);
    }
}
