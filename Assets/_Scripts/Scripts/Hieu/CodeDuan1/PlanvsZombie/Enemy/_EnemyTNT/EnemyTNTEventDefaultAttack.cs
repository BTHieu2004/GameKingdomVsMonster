using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EnemyTNTEventDefaultAttack : EnemyEventCloseRangeAttack
{
    [SerializeField] protected Spawner<EffectMonsterCtrt> effectSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
    }
    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = FindAnyObjectByType<Spawner<EffectMonsterCtrt>>();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
        if (!this.isColliderPlant) return;
        this.InstanceEffect();
        this.PlayMusicSFX();
        ProgressLevel.Instance.CountEnemyDead(1);
        this.enemyAbstract.Spawner.Despawn(this.enemyAbstract);
    }
    protected virtual void InstanceEffect()
    {
        EffectEnemySO effectEnemy = this.GetEffectEnemySO();
        if (effectEnemy == null) return;
        ExplosionFireWork explosionFireWork = effectEnemy.effect.GetComponent<ExplosionFireWork>();
        this.effectSpawner.Spawn(explosionFireWork, transform.position, Quaternion.identity);
    }
    protected virtual void PlayMusicSFX()
    {
        SoundSO soundSO = this.GetSoundSO();
        if (soundSO == null) return;
        SoundCtrl soundCtrl = soundSO.objSound.GetComponent<SoundCtrl>();
        if (soundCtrl == null)
        {
            Debug.Log("SoundtrlNull");
            return;
        }
        this.enemyAbstract.SoundSpawner.Spawn(soundCtrl,transform.position,Quaternion.identity);
    }
    protected EffectEnemySO GetEffectEnemySO()
    {
        return this.enemyAbstract.EnemySO.GetEffectByName(EnumEffect.vfx);
    }
    protected SoundSO GetSoundSO()
    {
        return this.enemyAbstract.EnemySO.GetSoundSO(SoundName.SoundExplosin);
    }
}
