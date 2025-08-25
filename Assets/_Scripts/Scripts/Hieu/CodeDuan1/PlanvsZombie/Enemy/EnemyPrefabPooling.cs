using System.Linq;
using UnityEngine;

public class EnemyPrefabPooling : PrefabPooling
{
    protected override void LoadListPooling()
    {
        if (this.listPoolingObj.Count > 0) return;

        LevelSO levelSO = Resources.Load<LevelSO>("Level/Level1");
        foreach (EnemySO child in levelSO.typeEnemyInLevel)
        {
            if (child.objEnemy.GetComponent<PoolingObj>() == null) return;
            this.listPoolingObj.Add(child.objEnemy.GetComponent<PoolingObj>());
        }
    }
}
