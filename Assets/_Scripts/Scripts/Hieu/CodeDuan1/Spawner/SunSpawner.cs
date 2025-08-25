using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : Spawner<Sun>
{
    [SerializeField] protected LevelSO levelSO;
    [SerializeField] protected Sun sun;
    [SerializeField] protected float startTimeSpawn;
    [SerializeField] protected float spawnTime;
    public Sun Sun => sun;
    public bool isSpawn = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelData();
        this.LoadSun();
    }
    protected virtual void LoadLevelData()
    {
        if (levelSO != null) return;
        this.levelSO = Resources.Load<LevelSO>("Level/Level1");
    }
    protected virtual void LoadSun()
    {
        if (this.Sun != null) return;
        this.sun = this.levelSO.sun.objSun.GetComponent<Sun>();
    }
    protected virtual void Start()
    {
        if (isSpawn == false) return;
        InvokeRepeating(nameof(SpawnSun),startTimeSpawn, spawnTime);
    }
    protected virtual void SpawnSun()
    {        
        this.Spawn(Sun);        
    }            
}
