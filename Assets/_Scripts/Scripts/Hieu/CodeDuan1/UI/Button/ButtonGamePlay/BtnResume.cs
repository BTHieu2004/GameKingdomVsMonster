using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : BtnLoadParenAbstract<PauseUI>
{
    protected override void OnClick()
    {
        this.ResumeGame();
    }
    protected virtual void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
        this.parentCtrl.Hide();
    }
}
