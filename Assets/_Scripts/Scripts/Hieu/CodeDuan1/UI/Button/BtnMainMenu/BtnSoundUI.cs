using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSoundUI : MainButton
{      
    protected override void OnClick()
    {
        this.ShowSoundUI();
    }
    protected virtual void ShowSoundUI()
    {
        this.subMenuUIHolder.SoundUI.Show();
    }
}
