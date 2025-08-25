using Unity.VisualScripting;
using UnityEngine;

public class BulletDamageSender : DamageSenderAbstract
{
    [SerializeField] protected Bullet bullet;    
    [SerializeField] protected Spawner<Bullet> spawner;    
    [SerializeField] protected bool isColliderEnemy;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.isColliderEnemy = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
        this.LoadSpawner();                
    }
    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponentInParent<Bullet>();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<Spawner<Bullet>>();  
    }    
    
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;
        this.isColliderEnemy = true;
        this.SpawnEffect(collider);
        this.DamgageSenderEnemy(collider);
        this.spawner.Despawn(this.bullet);
    }    
    protected virtual void DamgageSenderEnemy(Collider2D collider)
    {
        EnemyDamageReceive damageReceive = collider.GetComponent<EnemyDamageReceive>();        
        damageReceive.TakeDamage(this.bullet.BulletSO.damage);
    }
    protected virtual void SpawnEffect(Collider2D collider)
    {

    }
}
