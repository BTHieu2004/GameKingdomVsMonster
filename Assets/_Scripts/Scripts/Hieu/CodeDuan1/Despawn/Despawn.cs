using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : PoolingObj
{
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected T parent;
    [SerializeField] protected float currenTime;
    [SerializeField] protected float timeLife;
    [SerializeField] protected bool isDespawnByTime;
    protected override void OnEnable()
    {
        base.OnEnable();       
        this.Resetvalue();
    }
    protected virtual void Update()
    {
        if (!this.isDespawnByTime) return;
        currenTime += Time.deltaTime;
        if (currenTime <= timeLife) return;
        this.currenTime = 0;
        this.DoDespawn();
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.currenTime = 0;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadSpawner();
        this.LoadSun();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<Spawner<T>>();
    }
    protected virtual void LoadSun()
    {
        if (this.parent != null) return;
        this.parent = GetComponentInParent<T>();
    }
    public override void DoDespawn()
    {
        this.spawner.Despawn(this.parent);
    }        
}
