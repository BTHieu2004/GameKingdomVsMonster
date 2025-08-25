using UnityEngine;

public class EnemyMoving : HieuMonoBehaviour
{    
    protected virtual void Start()
    {
        this.enemyAbstract.EnemyAnimationCtrl.PlayAniWalk();
    }
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
    protected virtual void FixedUpdate()
    {
        if (this.enemyAbstract.SpeedEnemy <= 0) return;
        transform.parent.Translate(Vector2.left * this.enemyAbstract.SpeedEnemy * Time.fixedDeltaTime);        
    }
}
