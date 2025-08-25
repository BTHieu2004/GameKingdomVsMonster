using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnHideAchivement : BtnLoadParenAbstract<AchivementUI>
{
    protected override void OnClick()
    {        
        this.HideUI();
    }
    protected virtual void HideUI()
    {
        this.parentCtrl.Hide();
    }
}
