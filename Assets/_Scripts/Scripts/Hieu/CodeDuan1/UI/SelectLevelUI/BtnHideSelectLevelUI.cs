using UnityEngine;
using UnityEngine.UIElements;

public class BtnHideSelectLevelUI : BtnLoadParenAbstract<SelectLevelUI>
{
    protected override void OnClick()
    {        
        this.HideSelectUI();
    }
    protected virtual void HideSelectUI()
    {
        this.parentCtrl.Hide();
    }
}
