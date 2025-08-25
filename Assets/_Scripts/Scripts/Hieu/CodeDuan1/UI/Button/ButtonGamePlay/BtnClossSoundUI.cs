using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClossSoundUI : BtnLoadParenAbstract<SoundUI>
{
    protected override void OnClick()
    {
        this.HideSoundUI();
    }
    protected virtual void HideSoundUI()
    {
        this.parentCtrl.Hide();
    }
}
