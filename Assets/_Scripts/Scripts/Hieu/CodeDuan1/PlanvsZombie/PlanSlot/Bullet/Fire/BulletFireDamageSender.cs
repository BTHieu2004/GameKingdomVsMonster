using UnityEngine;

public class BulletFireDamageSender : BulletDamageSender
{
    [SerializeField] protected EffectPlantSpawner effectSpawner;    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
    }
    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = FindAnyObjectByType<EffectPlantSpawner>();
    }    
    protected override void SpawnEffect(Collider2D collider)
    {
        GameObject objEffectSO = this.bullet.BulletSO.effectBulletSO.objEffect;
        Explosion explosion = this.effectSpawner.Spawn(objEffectSO.GetComponent<Explosion>(), collider.transform.position, Quaternion.identity);                
    }    
}
