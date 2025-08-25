using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStart : MainButton
{
    protected override void OnClick()
    {
        this.ShowUISelectLevel();
    }
    protected virtual void ShowUISelectLevel()
    {
        this.subMenuUIHolder.SelectLevelUI.Show();
    }
}
