using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabEnemys : HieuMonoBehaviour
{
    [SerializeField] protected List<EnemyAbstract> enemyAbstract = new();
    public List<EnemyAbstract> EnemyAbstract => enemyAbstract;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbstact();
    }
    protected virtual void LoadEnemyAbstact()
    {
        if (this.enemyAbstract.Count > 0) return;
        this.enemyAbstract = GetComponentsInChildren<EnemyAbstract>().ToList();
    }
    public EnemyAbstract GetEnemyByName(string name)
    {
        foreach(EnemyAbstract enemy in this.enemyAbstract)
        {
            if (enemy.name != name) continue;
            return enemy;
        }
        return null;
    }
}
