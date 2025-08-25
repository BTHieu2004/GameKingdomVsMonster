using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.ExitGame();
    }
    protected virtual void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
