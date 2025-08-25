using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class DetectPlant : HieuMonoBehaviour
{    
    [SerializeField] protected EnemyAbstract enemyAbstract;
    [SerializeField] protected CapsuleCollider2D capsuleCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbstract();
        this.LoadCollider();
    }
    protected virtual void LoadEnemyAbstract()
    {
        if (this.enemyAbstract != null) return;
        this.enemyAbstract = GetComponentInParent<EnemyAbstract>();
    }
    protected virtual void LoadCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider2D>();
        this.capsuleCollider.isTrigger = true;
    }
    protected virtual void OnTriggerStay2D(Collider2D collider)
    {        
        if (collider.GetComponent<PlantDamageReceive>() == null) return;
        this.enemyAbstract.EnemySpeed(0);                
        this.enemyAbstract.EnemyAnimationCtrl.PlayAniAttack();
        this.enemyAbstract.EnemyDamageSender.PosDamgeSender(collider.transform.position);
    }   
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlantDamageReceive>() == null) return;        
        this.enemyAbstract.EnemySpeed(this.enemyAbstract.SpeedStart);
        this.enemyAbstract.EnemyAnimationCtrl.PlayAniWalk();
    }
}
