using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDamageSender : DamageSenderAbstract
{
    [SerializeField] protected EnemyAbstract enemyAbstract;
    [SerializeField] protected CircleCollider2D capsuleCollider2D;
    [SerializeField] protected bool isColliderPlant = false;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.isColliderPlant = false;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy();
        this.LoadCollider();
    }
    protected virtual void LoadEnemy()
    {
        if (this.enemyAbstract != null) return;
        this.enemyAbstract = GetComponentInParent<EnemyAbstract>();
    }
    protected virtual void LoadCollider()
    {
        if (this.capsuleCollider2D != null) return;
        this.capsuleCollider2D = GetComponent<CircleCollider2D>();
        this.capsuleCollider2D.isTrigger = true;
        this.capsuleCollider2D.radius = 0.3f;
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlantDamageReceive>() == null) return;
        PlantDamageReceive damageReceive = collider.GetComponent<PlantDamageReceive>();        
        damageReceive.TakeDamage(this.enemyAbstract.DamageDefault);
        this.isColliderPlant = true;
    }
    public virtual void PosDamgeSender(Vector2 pos)
    {
        transform.position = pos;
    }
}
