using System.Collections;
using UnityEngine;

public class EnemyDamageReceive : DamageReceiveAbstract
{    
    [SerializeField] protected EnemyAbstract enemyAbstract;
    [SerializeField] protected EnemySO enemySO;    
    [SerializeField] protected AnimationClip aniClipDead;
    public float waitingTime = 0;
    protected override void OnEnable()
    {
        base.OnEnable();
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = true;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbtract();        
        this.LoadEnemySO();        
        this.LoadAniClip();
    }
    protected virtual void LoadEnemyAbtract()
    {
        if (this.enemyAbstract != null) return;
        this.enemyAbstract = GetComponentInParent<EnemyAbstract>();
    }
    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        this.enemySO = this.enemyAbstract.EnemySO;        
    }   
    protected virtual void LoadAniClip()
    {
        if (this.aniClipDead != null) return;
        this.aniClipDead = this.enemyAbstract.EnemyAnimationCtrl.GetAniClip("Dead");
        this.waitingTime = this.aniClipDead.length;
    }    
    public override void TakeDamage(int damage)
    {
        this.enemyAbstract.EnemyHp(damage);
        if (this.enemyAbstract.HpEnemy > 0) return;
        this.enemyAbstract.EnemyAnimationCtrl.PlayAniDead();
        this.enemyAbstract.EnemySpeed(0);        
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;        
        Invoke(nameof(CdTimeDespawner),waitingTime+1);
    }
    protected virtual void CdTimeDespawner()
    {
        this.Despawn();
    }
    protected virtual void Despawn()
    {
        ProgressLevel.Instance.CountEnemyDead(1);
        this.enemyAbstract.Spawner.Despawn(enemyAbstract);
    }
    
}
