using NUnit.Framework.Interfaces;
using UnityEngine;

public class SpawnEnemy : Spawner<EnemyAbstract>
{
    [SerializeField] protected PointHolder spawnPointHolder;    
    [SerializeField] protected float startTimeSpawn;
    [SerializeField] protected float spawnTime;
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadSpawnPointHolder();        
    }   
    protected virtual void LoadSpawnPointHolder()
    {
        if (this.spawnPointHolder != null) return;
        this.spawnPointHolder = FindAnyObjectByType<PointHolder>();
    }        
    protected virtual void Start()
    {
        InvokeRepeating(nameof(Sp), this.startTimeSpawn, spawnTime);
    }
    protected virtual void Sp()
    {        
        if (!ProgressLevel.Instance.isSpawnEnemy) return;
        PoolingObj spawn = this.Spawn(RandomEnemy(),RandomPos(),Quaternion.identity);        
        spawn.gameObject.SetActive(true);
        spawn.transform.parent = this.holder;
        ProgressLevel.Instance.CountEnemySpawn(1);
    }
    protected virtual Vector2 RandomPos()
    {
        int random = Random.Range(0, this.spawnPointHolder.Points.Count);
        Vector2 pos = this.spawnPointHolder.Points[random].transform.position;
        return pos;
    }
    protected virtual EnemyAbstract RandomEnemy()
    {
        int randomEnemy = Random.Range(0, ProgressLevel.Instance.LevelSO.typeEnemyInLevel.Count);
        EnemyAbstract enemy = ProgressLevel.Instance.LevelSO.typeEnemyInLevel[randomEnemy].objEnemy.GetComponent<EnemyAbstract>();
        return enemy;     
    }   
}
