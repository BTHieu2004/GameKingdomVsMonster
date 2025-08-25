using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnNext : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.NextLevel();
    }
    protected virtual void NextLevel()
    {
        this.NextLevelSO();
        GameManager.Instance.LoadScene(NameScene.SceneGamePlay);
    }
    protected virtual void NextLevelSO()
    {
        LevelDataSO levelDataSO = ProgressLevel.Instance.LevelDataSO;
        int indexLevelSO = levelDataSO.listLevelSO.IndexOf(levelDataSO.currentLevelSO);
        if (indexLevelSO + 1 == levelDataSO.listLevelSO.Count) return;
        levelDataSO.currentLevelSO = levelDataSO.listLevelSO[indexLevelSO + 1];
    }
}
