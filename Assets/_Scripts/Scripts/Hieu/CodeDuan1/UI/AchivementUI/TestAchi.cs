using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAchi : BtnMenuAbstract
{
    protected override void OnClick()
    {
        AchivementManager.Instance.GetAchivementTypeID(EnumAchiverment.Hidden, 1);
    }
}
