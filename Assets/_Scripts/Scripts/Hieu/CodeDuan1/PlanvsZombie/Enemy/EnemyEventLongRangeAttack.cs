using System.Collections;
using UnityEngine;

public class EnemyEventLongRangeAttack : EnemyDamageSender
{
    [SerializeField] protected EffectMonsterSpawner effectMonsterSpawner;
    [SerializeField] protected ExplosionEnemy explosionEnemy;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.InstanceEffect();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffect();
        this.LoadExplosion();
    }
    protected virtual void LoadEffect()
    {
        if (this.effectMonsterSpawner != null) return;
        this.effectMonsterSpawner = FindAnyObjectByType<EffectMonsterSpawner>();
    }
    protected virtual void LoadExplosion()
    {
        if (this.explosionEnemy != null) return;
        EffectEnemySO effectEnemySO = this.enemyAbstract.EnemySO.GetEffectByName(EnumEffect.vfx);
        this.explosionEnemy = effectEnemySO.effect.GetComponent<ExplosionEnemy>();
    }
    protected virtual void InstanceEffect()
    {
        this.effectMonsterSpawner.Spawn(explosionEnemy, transform.position, Quaternion.identity);
    }
}
