using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnShowAchivement : MainButton
{
    protected override void OnClick()
    {        
        this.ShowAchivementUI();
    }
    protected virtual void ShowAchivementUI()
    {
        this.subMenuUIHolder.AchivementUI.Show();    
    }
}
