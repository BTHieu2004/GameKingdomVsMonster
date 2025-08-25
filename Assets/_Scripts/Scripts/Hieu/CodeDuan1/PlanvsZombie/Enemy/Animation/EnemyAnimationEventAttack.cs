using UnityEngine;

public class EnemyAnimationEventAttack : HieuMonoBehaviour
{
    [SerializeField] protected EnemyAbstract enemyAbstract;       
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbstract();
    }
    protected virtual void LoadEnemyAbstract()
    {
        if (this.enemyAbstract != null) return;
        this.enemyAbstract = GetComponentInParent<EnemyAbstract>();
    }
    public virtual void StartEventDamageShender()
    {                        
        this.enemyAbstract.EnemyDamageSender.gameObject.SetActive(true);
    }
    public virtual void EndEventDamageSender()
    {        
        this.enemyAbstract.EnemyDamageSender.gameObject.SetActive(false);
    }
}
